using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class PurchaseInvoiceService(
    ApplicationDbContext dbContext,
    ILogger<PurchaseInvoiceService> logger,
    ITransactionRouterService transactionRouter,
    INotificationService notificationService) : IPurchaseInvoiceService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<PurchaseInvoiceService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly INotificationService _notificationService = notificationService;

    private static readonly string[] AllowedInvoiceSortColumns = ["InvoiceNumber", "InvoiceDate", "TotalAmount", "PaidAmount"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Purchase Invoice
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PurchaseInvoiceResponse>> AddPurchaseInvoiceAsync(
        CreatePurchaseInvoiceRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var supplier = await _dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.SupplierId && !s.IsDeleted, ct);

            if (supplier is null)
                return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.SupplierNotFound);

            var productIds = request.Items.Select(i => i.ProductId).ToList();

            var products = await _dbContext.Products
                .Where(p => productIds.Contains(p.Id) && !p.IsDeleted)
                .ToDictionaryAsync(p => p.Id, ct);

            if (products.Count != request.Items.Count)
                return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.ProductNotFound);

            var invoiceNumber = $"PI-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";

            var invoice = new PurchaseInvoice
            {
                InvoiceNumber = invoiceNumber,
                SupplierId = supplier.Id,
                PaidAmount = request.PaidAmount,
                Notes = request.Notes,
                InvoiceDate = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            decimal totalAmount = 0;
            var responseItems = new List<PurchaseInvoiceItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var product = products[itemReq.ProductId];
                var lineTotal = itemReq.Quantity * itemReq.UnitCost;
                totalAmount += lineTotal;

                var qtyBeforeRestock = product.Quantity;
                product.Quantity += itemReq.Quantity;
                product.UpdatedAt = DateTime.UtcNow;
                product.UpdatedByUserId = userId;
                await _notificationService.NotifyStockChangeAsync(product, qtyBeforeRestock, ct);

                var invoiceItem = new PurchaseInvoiceItem
                {
                    PurchaseInvoiceId = invoice.Id,
                    ProductId = product.Id,
                    Quantity = itemReq.Quantity,
                    UnitCost = itemReq.UnitCost,
                    CreatedByUserId = userId
                };

                var batch = new ProductBatch
                {
                    ProductId = product.Id,
                    SupplierId = supplier.Id,
                    InitialQuantity = itemReq.Quantity,
                    AvailableQuantity = itemReq.Quantity,
                    PurchasePrice = itemReq.UnitCost,
                    WholesalePrice = itemReq.WholesalePrice,
                    RetailPrice = itemReq.RetailPrice,
                    MaintenancePrice = itemReq.MaintenancePrice ?? 0,
                    DateReceived = invoice.InvoiceDate,
                    CreatedByUserId = userId
                };

                _dbContext.ProductBatches.Add(batch);
                invoice.Items.Add(invoiceItem);

                responseItems.Add(new PurchaseInvoiceItemResponse(
                    invoiceItem.Id,
                    new ProductSummary(product.Id, product.Name, product.Barcode, product.ImageUrl, batch.RetailPrice, batch.WholesalePrice, product.Quantity),
                    invoiceItem.Quantity,
                    invoiceItem.UnitCost,
                    lineTotal));
            }

            if (request.PaidAmount > totalAmount)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.InvalidPaidAmount);
            }

            invoice.TotalAmount = totalAmount;

            var remaining = invoice.TotalAmount - invoice.PaidAmount;
            supplier.DebtBalance += remaining;
            supplier.UpdatedAt = DateTime.UtcNow;
            supplier.UpdatedByUserId = userId;

            _dbContext.PurchaseInvoices.Add(invoice);
            await _dbContext.SaveChangesAsync(ct);

            if (request.PaidAmount > 0)
            {
                var routeResult = await _transactionRouter.RouteTransactionAsync(GlobalTransactionCategory.CashPurchase, request.PaidAmount, 0, request.PaymentSource,
                    $"Purchase Invoice {invoice.Id}", invoice.Id, userId ?? "", ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<PurchaseInvoiceResponse>(routeResult.Error);
                }
            }

            await transaction.CommitAsync(ct);

            var response = new PurchaseInvoiceResponse(
                invoice.Id,
                invoice.InvoiceNumber,
                new SupplierSummary(supplier.Id, supplier.Name, supplier.Phone),
                invoice.TotalAmount,
                invoice.PaidAmount,
                invoice.RemainingAmount,
                invoice.InvoiceDate,
                invoice.Notes,
                responseItems);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error occurred while creating purchase invoice for user {UserId}", userId);
            return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Purchase Invoice By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PurchaseInvoiceResponse>> GetPurchaseInvoiceAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.PurchaseInvoices
            .Where(i => i.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.InvoiceNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Purchase Invoices
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<PurchaseInvoiceResponse>>> GetAllPurchaseInvoicesAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.PurchaseInvoices
                .Where(i => !i.IsDeleted)
                .Where(i => filters.SupplierId == null || i.SupplierId == filters.SupplierId)
                .Where(i => filters.StartDate == null || i.InvoiceDate >= filters.StartDate)
                .Where(i => filters.EndDate == null || i.InvoiceDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => (x.InvoiceNumber != null && x.InvoiceNumber.Contains(filters.SearchValue!)) ||
                                          (x.Supplier!.Name != null && x.Supplier.Name.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedInvoiceSortColumns)
                .ProjectToSummaryResponse();

            var result = await query.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for purchase invoices");
            return Result.Failure<PaginatedList<PurchaseInvoiceResponse>>(PurchaseInvoiceErrors.InvalidSortColumn);
        }
    }
}

