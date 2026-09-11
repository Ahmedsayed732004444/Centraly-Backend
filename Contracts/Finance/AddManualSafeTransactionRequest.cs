namespace Centraly.Api.Contracts.Finance;

using Centraly.Api.Contracts.Shared.Enums;

public record AddManualSafeTransactionRequest(DrawerTransactionType Type, SafeTransactionCategory Category, decimal Amount, string? Notes);
