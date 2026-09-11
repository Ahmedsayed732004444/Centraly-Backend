using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SupplierTransactionService(
    ApplicationDbContext dbContext,
    ILogger<SupplierTransactionService> logger,
    ITransactionRouterService transactionRouter,
    INotificationService notificationService) : ISupplierTransactionService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<SupplierTransactionService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly INotificationService _notificationService = notificationService;

    private static readonly string[] AllowedPaymentSortColumns = ["PaymentDate", "Amount"];
    private static readonly string[] AllowedReturnSortColumns = ["ReturnDate", "TotalReturnedAmount"];

    // ══════════════════════════════════════════════════════════════
    //  PAYMENTS
    // ══════════════════════════════════════════════════════════════

    public async Task<Result<SupplierPaymentResponse>> AddPaymentAsync(
        CreateSupplierPaymentRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var supplier = await _dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.SupplierId && !s.IsDeleted, ct);

            if (supplier is null)
                return Result.Failure<SupplierPaymentResponse>(SupplierTransactionErrors.SupplierNotFound);

            var payment = new SupplierPayment
            {
                SupplierId = supplier.Id,
                Amount = request.Amount,
                Notes = request.Notes,
                CreatedByUserId = userId
            };

            // Reduce the supplier's debt by the payment amount
            supplier.DebtBalance -= request.Amount;
            supplier.UpdatedAt = DateTime.UtcNow;
            supplier.UpdatedByUserId = userId;

            var category = request.Amount >= 0 ? GlobalTransactionCategory.SupplierPayment : GlobalTransactionCategory.SupplierReceipt;
            var routeResult = await _transactionRouter.RouteTransactionAsync(category, Math.Abs(request.Amount), 0, request.PaymentSource, request.Notes, null, userId ?? "", ct);

            if (routeResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<SupplierPaymentResponse>(routeResult.Error);
            }

            _dbContext.SupplierPayments.Add(payment);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            var response = new SupplierPaymentResponse(
                payment.Id,
                new SupplierSummary(supplier.Id, supplier.Name, supplier.Phone),
                payment.Amount,
                payment.PaymentDate,
                payment.Notes);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating supplier payment");
            return Result.Failure<SupplierPaymentResponse>(SupplierTransactionErrors.PaymentCreationFailed);
        }
    }

    public async Task<Result<SupplierPaymentResponse>> GetPaymentAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.SupplierPayments
            .Where(p => p.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SupplierPaymentResponse>(SupplierTransactionErrors.PaymentNotFound)
            : Result.Success(response);
    }

    public async Task<Result<PaginatedList<SupplierPaymentResponse>>> GetAllPaymentsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.SupplierPayments
                .Where(p => !p.IsDeleted)
                .Where(p => filters.SupplierId == null || p.SupplierId == filters.SupplierId)
                .Where(p => filters.StartDate == null || p.PaymentDate >= filters.StartDate)
                .Where(p => filters.EndDate == null || p.PaymentDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Supplier!.Name.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedPaymentSortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for supplier payments");
            return Result.Failure<PaginatedList<SupplierPaymentResponse>>(SupplierTransactionErrors.InvalidSortColumn);
        }
    }

    // ══════════════════════════════════════════════════════════════
    //  RETURNS
    // ══════════════════════════════════════════════════════════════

    public async Task<Result<SupplierReturnResponse>> AddReturnAsync(
        CreateSupplierReturnRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var supplier = await _dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.SupplierId && !s.IsDeleted, ct);

            if (supplier is null)
                return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.SupplierNotFound);

            var productIds = request.Items.Select(i => i.ProductId).ToList();

            var products = await _dbContext.Products
                .Where(p => productIds.Contains(p.Id) && !p.IsDeleted)
                .ToDictionaryAsync(p => p.Id, ct);

            if (products.Count != request.Items.Count)
                return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.ProductNotFound);

            var supplierReturn = new SupplierReturn
            {
                SupplierId = supplier.Id,
                Reason = (ReturnReason)request.Reason,
                Notes = request.Notes,
                ReturnDate = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            decimal totalReturnedAmount = 0;
            var responseItems = new List<SupplierReturnItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var product = products[itemReq.ProductId];

                var batch = await _dbContext.ProductBatches
                    .FirstOrDefaultAsync(b => b.Id == itemReq.BatchId && b.ProductId == product.Id && !b.IsDeleted, ct);

                if (batch is null)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.BatchNotFound);
                }

                // Ensure we don't return more than what is currently in this specific batch
                if (itemReq.Quantity > batch.AvailableQuantity)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.InsufficientQuantity);
                }

                var unitCost = batch.PurchasePrice;
                if (itemReq.ReturnPrice != batch.PurchasePrice)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(new Error("SupplierReturn.InvalidPrice", $"سعر الإرجاع يجب أن يطابق سعر الشراء الأصلي ({batch.PurchasePrice}) لهذه الدفعة", 400));
                }
                var lineTotal = itemReq.Quantity * unitCost;
                totalReturnedAmount += lineTotal;

                // Decrease stock from batch and total product
                batch.AvailableQuantity -= itemReq.Quantity;
                batch.UpdatedAt = DateTime.UtcNow;

                var qtyBeforeSupplierReturn = product.Quantity;
                product.Quantity -= itemReq.Quantity;
                product.UpdatedAt = DateTime.UtcNow;
                await _notificationService.NotifyStockChangeAsync(product, qtyBeforeSupplierReturn, ct);

                var returnItem = new SupplierReturnItem
                {
                    SupplierReturnId = supplierReturn.Id,
                    ProductId = product.Id,
                    Quantity = itemReq.Quantity,
                    UnitCost = unitCost,
                    CreatedByUserId = userId
                };

                supplierReturn.Items.Add(returnItem);

                responseItems.Add(new SupplierReturnItemResponse(
                    returnItem.Id,
                    new ProductSummary(product.Id, product.Name, product.Barcode, product.ImageUrl, 0, 0, product.Quantity),
                    returnItem.Quantity,
                    returnItem.UnitCost,
                    lineTotal));
            }

            supplierReturn.TotalReturnedAmount = totalReturnedAmount;

            // Returning items means the supplier owes us, which decreases our debt to them
            if (request.IsCashRefund)
            {
                var routeResult = await _transactionRouter.RouteTransactionAsync(GlobalTransactionCategory.PurchaseReturn, totalReturnedAmount, 0, request.PaymentSource,
                    request.Notes, supplierReturn.Id, userId ?? "", ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(routeResult.Error);
                }
            }
            else
            {
                supplier.DebtBalance -= totalReturnedAmount;
            }

            supplier.UpdatedAt = DateTime.UtcNow;
            supplier.UpdatedByUserId = userId;

            _dbContext.SupplierReturns.Add(supplierReturn);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            var response = new SupplierReturnResponse(
                supplierReturn.Id,
                new SupplierSummary(supplier.Id, supplier.Name, supplier.Phone),
                (ReturnReasonDto)supplierReturn.Reason,
                supplierReturn.Notes,
                supplierReturn.TotalReturnedAmount,
                supplierReturn.ReturnDate,
                responseItems,
                responseItems.Count);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating supplier return");
            return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.ReturnCreationFailed);
        }
    }

    public async Task<Result<SupplierReturnResponse>> GetReturnAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.SupplierReturns
            .Where(r => r.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.ReturnNotFound)
            : Result.Success(response);
    }

    public async Task<Result<PaginatedList<SupplierReturnResponse>>> GetAllReturnsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.SupplierReturns
                .Where(r => !r.IsDeleted)
                .Where(r => filters.SupplierId == null || r.SupplierId == filters.SupplierId)
                .Where(r => filters.StartDate == null || r.ReturnDate >= filters.StartDate)
                .Where(r => filters.EndDate == null || r.ReturnDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Supplier!.Name.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedReturnSortColumns);

            var result = await query.ProjectToSummaryResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for supplier returns");
            return Result.Failure<PaginatedList<SupplierReturnResponse>>(SupplierTransactionErrors.InvalidSortColumn);
        }
    }

    // ══════════════════════════════════════════════════════════════
}
