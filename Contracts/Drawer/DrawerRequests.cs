using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Drawer;

public record OpenSessionRequest(decimal OpeningBalance, int Type = 1);

public record AddManualTransactionRequest(
    DrawerTransactionType Type,
    DrawerTransactionCategory Category,
    decimal Amount,
    string? Notes,
    string? Source
);
