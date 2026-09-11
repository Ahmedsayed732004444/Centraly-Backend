namespace Centraly.Api.Services.Abstraction;

public interface ITransactionRouterService
{
    Task<Result<(string Id, PaymentSource Source)>> RouteTransactionAsync(GlobalTransactionCategory category, decimal amount, decimal profit, PaymentSource? requestedSource, string? notes, string? referenceId, string userId, CancellationToken ct = default);
}
