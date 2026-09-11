using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Finance;

public record OwnerTransactionResponse(
    string Id,
    GlobalTransactionCategory Category,
    decimal Amount,
    PaymentSource PaymentSource,
    string? Notes,
    DateTime CreatedAt,
    string? CreatedByUserId
);
