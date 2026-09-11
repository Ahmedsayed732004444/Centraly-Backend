namespace Centraly.Api.Contracts.Drawer;

public record DrawerTransactionResponse(
    string Id,
    DrawerTransactionType Type,
    DrawerTransactionCategory Category,
    decimal Amount,
    decimal Balance,
    string? Source,
    string? Notes,
    DateTime CreatedAt,
    string UserId
);

public record DrawerSessionResponse(
    string Id,
    int Type, // 1 = Sales, 2 = Maintenance (DrawerType)
    decimal OpeningBalance,
    DateTime OpenedAt,
    string OpenedByUserId,
    bool IsClosed,
    DateTime? ClosedAt,
    decimal? TotalIncome,
    decimal? TotalExpense,
    decimal? ClosingBalance,
    decimal? TotalProfit,
    IReadOnlyList<DrawerTransactionResponse> Transactions
);