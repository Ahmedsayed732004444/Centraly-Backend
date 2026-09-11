using Centraly.Api.Entities.Notifications;

namespace Centraly.Api.Services.Implementation;

public class OwnerTransactionService(
    ApplicationDbContext dbContext,
    ITransactionRouterService transactionRouter,
    INotificationService notificationService) : IOwnerTransactionService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly INotificationService _notificationService = notificationService;

    public async Task<Result<OwnerTransactionResponse>> CreateOwnerTransactionAsync(
        CreateOwnerTransactionRequest request, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var ownerTransaction = new OwnerTransaction
            {
                Category = request.Category,
                Amount = request.Amount,
                PaymentSource = request.PaymentSource,
                Notes = request.Notes,
                CreatedByUserId = userId
            };

            _dbContext.OwnerTransactions.Add(ownerTransaction);

            var routeResult = await _transactionRouter.RouteTransactionAsync(category: ownerTransaction.Category, amount: ownerTransaction.Amount, profit: 0,
                requestedSource: ownerTransaction.PaymentSource,
                notes: ownerTransaction.Notes,
                referenceId: ownerTransaction.Id,
                userId: userId,
                ct: ct);

            if (routeResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<OwnerTransactionResponse>(routeResult.Error);
            }

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            if (ownerTransaction.Category == GlobalTransactionCategory.OwnerWithdrawal)
            {
                await _notificationService.NotifyRolesAsync(
                    [DefaultRoles.Admin.Name, DefaultRoles.Manager.Name],
                    NotificationType.OwnerWithdrawal, NotificationSeverity.Warning,
                    "سحب مبلغ من قبل المالك",
                    $"تم سحب مبلغ {ownerTransaction.Amount} بواسطة المالك" + (string.IsNullOrWhiteSpace(ownerTransaction.Notes) ? "" : $" - {ownerTransaction.Notes}"),
                    nameof(OwnerTransaction), ownerTransaction.Id, "/finance/owner-transactions", ct);
            }

            var response = ownerTransaction.ToResponse();
            return Result.Success(response);
        }
        catch
        {
            await transaction.RollbackAsync(ct);
            throw;
        }
    }

    public async Task<Result<IEnumerable<OwnerTransactionResponse>>> GetOwnerTransactionsAsync(CancellationToken ct = default)
    {
        var transactions = await _dbContext.OwnerTransactions
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectToResponse()
            .ToListAsync(ct);

        return Result.Success<IEnumerable<OwnerTransactionResponse>>(transactions);
    }
}
