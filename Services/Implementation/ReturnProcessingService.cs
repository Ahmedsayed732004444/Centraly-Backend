namespace Centraly.Api.Services.Implementation;

public class ReturnProcessingService(
    ApplicationDbContext dbContext,
    ITransactionRouterService transactionRouter,
    ILogger<ReturnProcessingService> logger,
    INotificationService notificationService) : IReturnProcessingService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly ILogger<ReturnProcessingService> _logger = logger;
    private readonly INotificationService _notificationService = notificationService;

    public async Task<Result<ReturnRecordResponse>> ProcessReturnAsync(
        CreateCustomerReturnRequest request, string? userId, string? expectedCustomerId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var invoice = await _dbContext.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == request.InvoiceId && !i.IsDeleted, ct);

            if (invoice is null)
                return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.InvoiceNotFound);

            // If the caller is scoped to a specific customer (e.g. /customers/{id}/returns),
            // make sure the invoice actually belongs to that customer.
            if (expectedCustomerId is not null && invoice.CustomerId != expectedCustomerId)
                return Result.Failure<ReturnRecordResponse>(CustomerErrors.CustomerNotFound);

            var returnRecord = new ReturnRecord
            {
                InvoiceId = invoice.Id,
                IsFullInvoiceReturn = false,
                Reason = (ReturnReason)request.Reason,
                Notes = request.Notes,
                ReturnDate = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            var existingReturns = await _dbContext.ReturnItems
                .Where(ri => ri.ReturnRecord.InvoiceId == invoice.Id)
                .ToListAsync(ct);

            decimal totalReturnedAmount = 0;
            decimal totalReversedProfit = 0;
            var responseItems = new List<ReturnItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var invoiceItem = invoice.Items.FirstOrDefault(i => i.ProductId == itemReq.ProductId && i.BatchId == itemReq.BatchId);
                var returnedSoFar = existingReturns
                    .Where(ri => ri.ProductId == itemReq.ProductId && ri.BatchId == itemReq.BatchId)
                    .Sum(ri => ri.Quantity);

                if (invoiceItem is null || itemReq.Quantity > invoiceItem.Quantity - returnedSoFar)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.InvalidReturn);
                }

                var batch = await _dbContext.ProductBatches
                    .Include(b => b.Product)
                    .FirstOrDefaultAsync(b => b.Id == itemReq.BatchId && !b.IsDeleted, ct);

                if (batch?.Product is null)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.ProductNotFound);
                }

                batch.AvailableQuantity += itemReq.Quantity;
                batch.UpdatedAt = DateTime.UtcNow;

                var qtyBeforeRestock = batch.Product.Quantity;
                batch.Product.Quantity += itemReq.Quantity;
                batch.Product.UpdatedAt = DateTime.UtcNow;
                await _notificationService.NotifyStockChangeAsync(batch.Product, qtyBeforeRestock, ct);

                // NOTE - bug fix: the refunded/credited amount must be based on the price
                // actually charged on the original invoice line, not on whatever UnitPrice
                // the caller happens to send in the request. Trusting the client value here
                // let a return be priced higher than what the customer ever paid.
                var unitPrice = invoiceItem.UnitPrice;
                var lineTotal = itemReq.Quantity * unitPrice;
                totalReturnedAmount += lineTotal;
                totalReversedProfit += (unitPrice - invoiceItem.UnitCost) * itemReq.Quantity;

                var returnItem = new ReturnItem
                {
                    ReturnRecordId = returnRecord.Id,
                    ProductId = itemReq.ProductId,
                    BatchId = itemReq.BatchId,
                    Quantity = itemReq.Quantity,
                    UnitPrice = unitPrice,
                    CreatedByUserId = userId
                };

                returnRecord.Items.Add(returnItem);

                responseItems.Add(new ReturnItemResponse(
                    returnItem.Id, returnItem.ProductId, returnItem.BatchId, returnItem.Quantity, returnItem.UnitPrice));
            }

            returnRecord.TotalReturnedAmount = totalReturnedAmount;

            if (request.IsCashRefund)
            {
                var routerResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.SalesReturn, totalReturnedAmount, -totalReversedProfit, request.PaymentSource,
                    $"Refund for Invoice {invoice.InvoiceNumber}", returnRecord.Id, userId ?? string.Empty, ct);

                if (routerResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<ReturnRecordResponse>(routerResult.Error);
                }

                if (routerResult.Value.Source == PaymentSource.Drawer)
                {
                    returnRecord.DrawerTransactionId = routerResult.Value.Id;
                    await _dbContext.SaveChangesAsync(ct);
                }
            }
            else if (!string.IsNullOrEmpty(invoice.CustomerId))
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == invoice.CustomerId && !c.IsDeleted, ct);
                if (customer is not null)
                {
                    var invoiceOutstandingDebt = Math.Max(0, invoice.TotalAmount - invoice.PaidAmount);
                    var creditableAmount = Math.Min(totalReturnedAmount, invoiceOutstandingDebt);

                    customer.DebtBalance -= creditableAmount;
                    invoice.PaidAmount += creditableAmount; // Reduce remaining debt

                    var cashOwedToCustomer = totalReturnedAmount - creditableAmount;
                    if (cashOwedToCustomer > 0)
                    {
                        await transaction.RollbackAsync(ct);
                        return Result.Failure<ReturnRecordResponse>(new Error("Return.RequiresCashRefund", $"قيمة المرتجع تتجاوز المديونية المستحقة بمقدار {cashOwedToCustomer}، يجب إتمام العملية كرد نقدي", 400));
                    }

                    customer.UpdatedAt = DateTime.UtcNow;
                    customer.UpdatedByUserId = userId;
                }
            }
            else
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.InvalidReturn);
            }

            _dbContext.Returns.Add(returnRecord);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            var response = new ReturnRecordResponse(
                returnRecord.Id, returnRecord.InvoiceId, invoice.InvoiceNumber, returnRecord.IsFullInvoiceReturn,
                (ReturnReasonDto)returnRecord.Reason, returnRecord.Notes, request.IsCashRefund,
                returnRecord.TotalReturnedAmount, returnRecord.ReturnDate, responseItems);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error processing return for invoice {InvoiceId}", request.InvoiceId);
            return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.CreationFailed);
        }
    }
}
