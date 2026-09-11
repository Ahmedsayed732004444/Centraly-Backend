using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Finance;

public record CreateOwnerTransactionRequest(
    GlobalTransactionCategory Category,
    decimal Amount,
    PaymentSource PaymentSource,
    string? Notes
);
