namespace Centraly.Api.Services.Implementation;

public class CustomerTransactionService(
    ApplicationDbContext dbContext,
    ILogger<CustomerTransactionService> logger,
    ITransactionRouterService transactionRouter,
    IReturnProcessingService returnProcessor) : ICustomerTransactionService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CustomerTransactionService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly IReturnProcessingService _returnProcessor = returnProcessor;

    // ─────────────────────────────────────────────────────────────────
    //  Add Payment (or refund)
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<CustomerPaymentResponse>> AddPaymentAsync(
        string customerId, CreateCustomerPaymentRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == customerId && !c.IsDeleted, ct);

            if (customer is null)
                return Result.Failure<CustomerPaymentResponse>(CustomerErrors.CustomerNotFound);

            var payment = new CustomerDebtPayment
            {
                CustomerId = customer.Id,
                Amount = request.Amount,
                Notes = request.Notes,
                CreatedByUserId = userId
            };

            var category = request.Amount < 0 ? GlobalTransactionCategory.CustomerRefund : GlobalTransactionCategory.CustomerPayment;
            decimal profitToRecord = 0;

            // Only positive payments settle debt (and so recognize profit). A refund
            // (negative Amount) only affects DebtBalance below - it never re-opens an
            // invoice's PaidAmount/RecordedProfit, which avoids the previous code's
            // ill-defined "negative portion" when Amount < 0.
            if (request.Amount > 0)
            {
                // If no specific invoice was targeted, sweep the customer's oldest
                // outstanding deferred invoices first (FIFO) so a general payment still
                // recognizes the profit it settles instead of losing it entirely.
                var outstandingQuery = _dbContext.Invoices.Include(i => i.Items)
                    .Where(i => !i.IsDeleted && i.PaidAmount < i.TotalAmount);

                outstandingQuery = string.IsNullOrEmpty(request.InvoiceId)
                    ? outstandingQuery.Where(i => i.CustomerId == customerId)
                    : outstandingQuery.Where(i => i.Id == request.InvoiceId && i.CustomerId == customerId);

                var outstandingInvoices = await outstandingQuery.OrderBy(i => i.CreatedAt).ToListAsync(ct);

                var remainingToAllocate = request.Amount;
                foreach (var invoice in outstandingInvoices)
                {
                    if (remainingToAllocate <= 0) break;

                    var invoiceRemainingDebt = invoice.TotalAmount - invoice.PaidAmount;
                    // Never let PaidAmount exceed TotalAmount (the DB also enforces this
                    // via CK_Invoice_PaidAmount) - cap what this payment applies to the
                    // invoice at its own remaining debt; any excess stays as general
                    // customer credit via DebtBalance below instead of overpaying it.
                    var appliedToInvoice = Math.Min(remainingToAllocate, invoiceRemainingDebt);

                    var totalPotentialProfit = invoice.Items.Sum(i => (i.UnitPrice - i.UnitCost) * i.Quantity);
                    var remainingProfit = totalPotentialProfit - invoice.RecordedProfit;
                    var portion = invoiceRemainingDebt <= 0 ? 0 : appliedToInvoice / invoiceRemainingDebt;
                    var invoiceProfitShare = Math.Round(remainingProfit * portion, 2, MidpointRounding.AwayFromZero);

                    invoice.RecordedProfit += invoiceProfitShare;
                    invoice.PaidAmount += appliedToInvoice;

                    profitToRecord += invoiceProfitShare;
                    remainingToAllocate -= appliedToInvoice;
                }
            }

            var routerResult = await _transactionRouter.RouteTransactionAsync(category, Math.Abs(request.Amount), profitToRecord, request.PaymentSource, request.Notes, payment.Id, userId, ct);

            if (routerResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<CustomerPaymentResponse>(routerResult.Error);
            }

            customer.DebtBalance -= request.Amount; // if Amount is negative, it adds to DebtBalance (Customer Refund increases their debt to us or returns their credit). Wait, if customer pays us, they reduce their debt. DebtBalance -= Amount. If it's a refund (we pay them back), DebtBalance += Math.Abs(Amount) which is DebtBalance -= (-Math.Abs) -> DebtBalance -= request.Amount. Correct!
            customer.UpdatedAt = DateTime.UtcNow;
            customer.UpdatedByUserId = userId;

            _dbContext.CustomerDebtPayments.Add(payment);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return Result.Success(new CustomerPaymentResponse(
                payment.Id, payment.CustomerId, payment.Amount, payment.PaymentDate, payment.Notes));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error occurred while processing payment for customer {CustomerId}", customerId);
            return Result.Failure<CustomerPaymentResponse>(CustomerTransactionErrors.PaymentFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Add Return
    // ─────────────────────────────────────────────────────────────────
    // The actual workflow (validate invoice/items, restock batches, record
    // the return, route refund or adjust debt) lives in ReturnProcessingService
    // so it isn't duplicated between here and SalesReturnService. Passing
    // customerId scopes the check to "this invoice must belong to this customer".

    public Task<Result<ReturnRecordResponse>> AddReturnAsync(
        string customerId, CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default) =>
        _returnProcessor.ProcessReturnAsync(request, userId, expectedCustomerId: customerId, ct);

    // ─────────────────────────────────────────────────────────────────
    //  Customer Statement
    // ─────────────────────────────────────────────────────────────────
    // Only ever checked for existence, so this uses AnyAsync instead of
    // loading the full Customer entity.

    public async Task<Result<IEnumerable<CustomerStatementResponse>>> GetCustomerStatementAsync(
        string customerId, CancellationToken ct = default)
    {
        var customerExists = await _dbContext.Customers.AnyAsync(c => c.Id == customerId && !c.IsDeleted, ct);
        if (!customerExists)
            return Result.Failure<IEnumerable<CustomerStatementResponse>>(CustomerErrors.CustomerNotFound);

        var rawInvoices = await _dbContext.Invoices
            .Where(i => i.CustomerId == customerId && !i.IsDeleted)
            .Select(i => new { i.CreatedAt, i.Id, i.TotalAmount, i.PaidAmount, i.Notes })
            .AsNoTracking()
            .ToListAsync(ct);

        var invoices = rawInvoices
            .Select(i => new { Date = i.CreatedAt, Type = "Invoice", i.Id, Debit = i.TotalAmount, Credit = 0m, i.Notes })
            .ToList();

        var invoicePayments = rawInvoices
            .Where(i => i.PaidAmount > 0)
            .Select(i => new { Date = i.CreatedAt, Type = "InvoicePayment", i.Id, Debit = 0m, Credit = i.PaidAmount, Notes = "سداد نقدي للفاتورة" })
            .ToList();

        var payments = await _dbContext.CustomerDebtPayments
            .Where(p => p.CustomerId == customerId && !p.IsDeleted)
            .Select(p => new
            {
                Date = p.PaymentDate,
                Type = p.Amount >= 0 ? "Payment" : "Refund",
                p.Id,
                Debit = p.Amount < 0 ? Math.Abs(p.Amount) : 0m,
                Credit = p.Amount >= 0 ? p.Amount : 0m,
                Notes = (string?)p.Notes
            })
            .AsNoTracking()
            .ToListAsync(ct);

        var returns = await _dbContext.Returns
            .Where(r => r.Invoice!.CustomerId == customerId && !r.IsDeleted)
            .Select(r => new { Date = r.ReturnDate, Type = "Return", r.Id, Debit = 0m, Credit = r.TotalReturnedAmount, Notes = (string?)r.Notes })
            .AsNoTracking()
            .ToListAsync(ct);

        var allTransactions = invoices.Concat(invoicePayments).Concat(payments).Concat(returns).OrderBy(t => t.Date);

        var runningBalance = 0m;
        var result = new List<CustomerStatementResponse>();

        foreach (var t in allTransactions)
        {
            runningBalance += t.Debit - t.Credit;
            result.Add(new CustomerStatementResponse(t.Date, t.Type, t.Id, t.Debit, t.Credit, runningBalance, t.Notes));
        }

        return Result.Success<IEnumerable<CustomerStatementResponse>>(result);
    }
}
