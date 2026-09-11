using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SalesInvoiceService(
    ApplicationDbContext dbContext,
    ILogger<SalesInvoiceService> logger,
    ITransactionRouterService transactionRouter,
    INotificationService notificationService) : ISalesInvoiceService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<SalesInvoiceService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly INotificationService _notificationService = notificationService;

    private static readonly string[] AllowedInvoiceSortColumns = ["CreatedAt", "InvoiceNumber", "TotalAmount"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Sales Invoice
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SalesInvoiceResponse>> AddInvoiceAsync(
        CreateSalesInvoiceRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            Customer? customer = null;
            var finalCustomerId = request.CustomerId;

            if (!string.IsNullOrWhiteSpace(finalCustomerId))
            {
                // Customer was passed explicitly - validate it actually exists.
                customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == finalCustomerId && !c.IsDeleted, ct);
                if (customer is null)
                    return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.CustomerNotFound);
            }
            else if (!string.IsNullOrWhiteSpace(request.CustomerPhone))
            {
                customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Phone == request.CustomerPhone && !c.IsDeleted, ct);

                if (customer is null)
                {
                    customer = new Customer
                    {
                        Name = string.IsNullOrWhiteSpace(request.CustomerName) ? "بدون اسم" : request.CustomerName,
                        Phone = request.CustomerPhone,
                        CreatedByUserId = userId
                    };
                    _dbContext.Customers.Add(customer);
                }

                finalCustomerId = customer.Id;
            }

            if (finalCustomerId is null && request.PaymentMethod == PaymentMethodDto.Deferred)
                return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InvalidPayment);

            var invoice = new Invoice
            {
                InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMddHHmmss}",
                CustomerId = finalCustomerId,
                SaleType = (SaleType)request.SaleType,
                PaymentMethod = (PaymentMethod)request.PaymentMethod,
                PaidAmount = request.PaidAmount,
                Notes = request.Notes,
                UserId = userId ?? string.Empty,
                CreatedByUserId = userId
            };

            decimal totalAmount = 0;
            var responseItems = new List<SalesInvoiceItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var batches = await _dbContext.ProductBatches
                    .Include(b => b.Product)
                    .Where(b => b.ProductId == itemReq.ProductId && b.AvailableQuantity > 0 && !b.IsDeleted)
                    .OrderBy(b => b.CreatedAt)
                    .ToListAsync(ct);

                int remainingQty = itemReq.Quantity;

                foreach (var batch in batches)
                {
                    if (remainingQty <= 0) break;

                    // Price must match the batch's price for THIS invoice's SaleType specifically -
                    // matching either price regardless of SaleType let a retail sale go out at the
                    // (usually lower) wholesale price undetected.
                    var expectedPrice = invoice.SaleType == SaleType.Wholesale ? batch.WholesalePrice : batch.RetailPrice;
                    if (itemReq.SellingPrice != expectedPrice)
                    {
                        await transaction.RollbackAsync(ct);
                        var saleTypeLabel = invoice.SaleType == SaleType.Wholesale ? "الجملة" : "التجزئة";
                        return Result.Failure<SalesInvoiceResponse>(new Error("SalesInvoice.InvalidPrice", $"السعر {itemReq.SellingPrice} لا يطابق سعر {saleTypeLabel} ({expectedPrice}) للدفعة المستخدمة من المنتج {batch.Product?.Name}.", 400));
                    }

                    var toDeduct = Math.Min(remainingQty, batch.AvailableQuantity);
                    var lineTotal = toDeduct * itemReq.SellingPrice;
                    totalAmount += lineTotal;

                    batch.AvailableQuantity -= toDeduct;
                    batch.UpdatedAt = DateTime.UtcNow;

                    var qtyBeforeSale = batch.Product.Quantity;
                    batch.Product.Quantity -= toDeduct;
                    batch.Product.UpdatedAt = DateTime.UtcNow;
                    await _notificationService.NotifyStockChangeAsync(batch.Product, qtyBeforeSale, ct);

                    var invoiceItem = new InvoiceItem
                    {
                        InvoiceId = invoice.Id,
                        ProductId = itemReq.ProductId,
                        BatchId = batch.Id,
                        Quantity = toDeduct,
                        UnitPrice = itemReq.SellingPrice,
                        UnitCost = batch.PurchasePrice,
                        CreatedByUserId = userId
                    };

                    invoice.Items.Add(invoiceItem);

                    responseItems.Add(new SalesInvoiceItemResponse(
                        invoiceItem.Id, invoiceItem.ProductId, batch.Product.Name ?? "Unknown", invoiceItem.BatchId,
                        invoiceItem.Quantity, 0, invoiceItem.UnitPrice, invoiceItem.UnitCost, lineTotal));

                    remainingQty -= toDeduct;
                }

                if (remainingQty > 0)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InsufficientQuantity);
                }
            }

            invoice.TotalAmount = totalAmount;

            if (invoice.PaidAmount > invoice.TotalAmount)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<SalesInvoiceResponse>(new Error("SalesInvoice.InvalidPayment", "المبلغ المدفوع لا يمكن أن يتجاوز إجمالي الفاتورة", 400));
            }

            if (finalCustomerId is null && invoice.PaidAmount < invoice.TotalAmount)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InvalidPayment);
            }

            if (customer is not null && invoice.PaidAmount < invoice.TotalAmount)
            {
                customer.DebtBalance += invoice.RemainingAmount;
                customer.UpdatedAt = DateTime.UtcNow;
                customer.UpdatedByUserId = userId;
            }

            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync(ct);

            if (request.PaidAmount > 0)
            {
                decimal totalProfit = invoice.Items.Sum(i => (i.UnitPrice - i.UnitCost) * i.Quantity);
                // If deferred and partially paid, calculate proportional profit for this payment
                decimal recordedProfit = request.PaidAmount >= totalAmount ? totalProfit : Math.Round(totalProfit * (request.PaidAmount / totalAmount), 2, MidpointRounding.AwayFromZero);
                invoice.RecordedProfit = recordedProfit;
                
                var routeResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.CashSale, request.PaidAmount, recordedProfit, request.PaymentSource,
                    $"Sales Invoice {invoice.Id}", invoice.Id, userId ?? "", ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SalesInvoiceResponse>(routeResult.Error);
                }

                if (routeResult.Value.Source == PaymentSource.Drawer)
                {
                    invoice.DrawerTransactionId = routeResult.Value.Id;
                    await _dbContext.SaveChangesAsync(ct);
                }
            }

            await transaction.CommitAsync(ct);

            var customerSummary = customer is not null ? new CustomerSummary(customer.Id, customer.Name, customer.Phone) : null;

            var response = new SalesInvoiceResponse(
                invoice.Id, invoice.InvoiceNumber, customerSummary, (SaleTypeDto)invoice.SaleType,
                (PaymentMethodDto)invoice.PaymentMethod, invoice.TotalAmount, invoice.PaidAmount,
                invoice.RemainingAmount, invoice.Notes, invoice.CreatedAt, false, responseItems);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating sales invoice");
            return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Invoice By Id or InvoiceNumber
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SalesInvoiceResponse>> GetInvoiceAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Invoices
            .Where(i => i.Id == id || i.InvoiceNumber == id)
            .ProjectToResponse(_dbContext)
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InvoiceNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Invoices
    // ─────────────────────────────────────────────────────────────────
    // NOTE - bug fix: the previous version bypassed ApplyFilters/ToPaginatedListAsync
    // and hand-rolled Skip/Take, then constructed PaginatedList with its constructor
    // arguments in the wrong order (totalCount/pageNumber/pageSize were shuffled),
    // which silently corrupted TotalPages/HasNextPage for every response.

    public async Task<Result<PaginatedList<SalesInvoiceResponse>>> GetAllInvoicesAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Invoices
                .Where(i => !i.IsDeleted)
                .Where(i => filters.CustomerId == null || i.CustomerId == filters.CustomerId)
                .Where(i => filters.StartDate == null || i.CreatedAt >= filters.StartDate)
                .Where(i => filters.EndDate == null || i.CreatedAt <= filters.EndDate)
                .Where(i => !filters.SaleType.HasValue || i.SaleType == (SaleType)filters.SaleType.Value)
                .Where(i => !filters.PaymentMethod.HasValue || i.PaymentMethod == (PaymentMethod)filters.PaymentMethod.Value)
                .ApplyFilters(filters,
                    searchPredicate: x => x.InvoiceNumber.Contains(filters.SearchValue!) ||
                                          (x.Customer != null && x.Customer.Name!.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedInvoiceSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(i => i.CreatedAt);

            var mappedQuery = query.ProjectToSummaryResponse();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for sales invoices");
            return Result.Failure<PaginatedList<SalesInvoiceResponse>>(SalesInvoiceErrors.InvalidSortColumn);
        }
    }
}