using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SupplierService(ApplicationDbContext dbContext, ILogger<SupplierService> logger) : ISupplierService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<SupplierService> _logger = logger;

    private static readonly string[] AllowedSupplierSortColumns = ["Name", "DebtBalance", "CreatedAt"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SupplierResponse>> AddSupplierAsync(
        CreateSupplierRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var supplier = new Supplier
            {
                Name = request.Name,
                Type = request.Type,
                Phone = request.Phone,
                Address = request.Address,
                CreatedByUserId = userId
            };

            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync(ct);

            var response = new SupplierResponse(
                supplier.Id, supplier.Name, supplier.Type, supplier.Phone, supplier.Address,
                supplier.DebtBalance, 0, 0, supplier.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating supplier for user {UserId}", userId);
            return Result.Failure<SupplierResponse>(SupplierErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Supplier By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SupplierResponse>> GetSupplierAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Suppliers
            .Where(s => s.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SupplierResponse>(SupplierErrors.SupplierNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Suppliers
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<SupplierResponse>>> GetAllSuppliersAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Suppliers
                .Where(s => !s.IsDeleted)
                .ApplyFilters(filters,
                    searchPredicate: x => (x.Name != null && x.Name.Contains(filters.SearchValue!)) ||
                                          (x.Phone != null && x.Phone.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedSupplierSortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for suppliers");
            return Result.Failure<PaginatedList<SupplierResponse>>(SupplierErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Update Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SupplierResponse>> UpdateSupplierAsync(
        string id, UpdateSupplierRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var updated = await _dbContext.Suppliers
                .Where(s => s.Id == id && !s.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(s => s.Name, request.Name)
                    .SetProperty(s => s.Type, request.Type)
                    .SetProperty(s => s.Phone, request.Phone)
                    .SetProperty(s => s.Address, request.Address)
                    .SetProperty(s => s.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(s => s.UpdatedByUserId, userId), ct);

            if (updated == 0)
                return Result.Failure<SupplierResponse>(SupplierErrors.SupplierNotFound);

            var response = await _dbContext.Suppliers
                .Where(s => s.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating supplier {SupplierId}", id);
            return Result.Failure<SupplierResponse>(SupplierErrors.UpdateFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Soft Delete Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<bool>> DeleteSupplierAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Suppliers
                .Where(s => s.Id == id && !s.IsDeleted && s.DebtBalance == 0)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(s => s.IsDeleted, true)
                    .SetProperty(s => s.DeletedAt, DateTime.UtcNow), ct);

            if (deleted > 0)
                return Result.Success(true);

            var exists = await _dbContext.Suppliers.AnyAsync(s => s.Id == id && !s.IsDeleted, ct);
            return Result.Failure<bool>(exists ? SupplierErrors.HasOutstandingDebt : SupplierErrors.SupplierNotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting supplier {SupplierId}", id);
            return Result.Failure<bool>(SupplierErrors.DeleteFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Supplier Statement (already reasonably lean - kept structurally
    //  the same: only an existence check, then flat per-source projections)
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<List<SupplierStatementItemResponse>>> GetSupplierStatementAsync(
        string id, RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var supplierExists = await _dbContext.Suppliers.AnyAsync(s => s.Id == id && !s.IsDeleted, ct);
            if (!supplierExists)
                return Result.Failure<List<SupplierStatementItemResponse>>(SupplierErrors.SupplierNotFound);

            var rawInvoices = await _dbContext.PurchaseInvoices
                .AsNoTracking()
                .Where(i => i.SupplierId == id && !i.IsDeleted)
                .Select(i => new { i.InvoiceDate, i.Id, i.TotalAmount, i.PaidAmount, i.Notes })
                .ToListAsync(ct);

            var invoices = rawInvoices
                .Select(i => new { Date = i.InvoiceDate, Type = "PurchaseInvoice", i.Id, Debit = 0m, Credit = i.TotalAmount, i.Notes })
                .ToList();

            var invoicePayments = rawInvoices
                .Where(i => i.PaidAmount > 0)
                .Select(i => new { Date = i.InvoiceDate, Type = "InvoicePayment", i.Id, Debit = i.PaidAmount, Credit = 0m, Notes = "سداد نقدي للفاتورة" })
                .ToList();

            var payments = await _dbContext.SupplierPayments
                .AsNoTracking()
                .Where(p => p.SupplierId == id && !p.IsDeleted)
                .Select(p => new
                {
                    Date = p.PaymentDate,
                    Type = p.Amount >= 0 ? "Payment" : "Receipt",
                    p.Id,
                    Debit = p.Amount >= 0 ? p.Amount : 0m,
                    Credit = p.Amount < 0 ? Math.Abs(p.Amount) : 0m,
                    Notes = (string?)p.Notes
                })
                .ToListAsync(ct);

            var returns = await _dbContext.SupplierReturns
                .AsNoTracking()
                .Where(r => r.SupplierId == id && !r.IsDeleted)
                .Select(r => new { Date = r.ReturnDate, Type = "Return", r.Id, Debit = r.TotalReturnedAmount, Credit = 0m, Notes = (string?)r.Notes })
                .ToListAsync(ct);

            var allTransactions = invoices.Concat(invoicePayments).Concat(payments).Concat(returns).AsEnumerable();

            if (filters.StartDate.HasValue)
                allTransactions = allTransactions.Where(t => t.Date >= filters.StartDate.Value);

            if (filters.EndDate.HasValue)
                allTransactions = allTransactions.Where(t => t.Date <= filters.EndDate.Value);

            var runningBalance = 0m;
            var result = new List<SupplierStatementItemResponse>();

            foreach (var t in allTransactions.OrderBy(t => t.Date))
            {
                runningBalance += t.Credit - t.Debit;
                result.Add(new SupplierStatementItemResponse(t.Date, t.Type, t.Id, t.Debit, t.Credit, runningBalance, t.Notes));
            }

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting statement for supplier {SupplierId}", id);
            return Result.Failure<List<SupplierStatementItemResponse>>(SupplierErrors.SupplierNotFound);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Available Batches for a Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<IReadOnlyList<SupplierBatchResponse>>> GetSupplierAvailableBatchesAsync(
        string supplierId, CancellationToken ct = default)
    {
        var supplierExists = await _dbContext.Suppliers.AnyAsync(s => s.Id == supplierId && !s.IsDeleted, ct);
        if (!supplierExists)
            return Result.Failure<IReadOnlyList<SupplierBatchResponse>>(SupplierErrors.SupplierNotFound);

        var batches = await _dbContext.ProductBatches
            .Where(b => b.SupplierId == supplierId)
            .ProjectToResponse()
            .ToListAsync(ct);

        return Result.Success<IReadOnlyList<SupplierBatchResponse>>(batches);
    }


}