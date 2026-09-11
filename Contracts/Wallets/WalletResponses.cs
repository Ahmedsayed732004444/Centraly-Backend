using Centraly.Api.Entities.Wallets;

namespace Centraly.Api.Contracts.Wallets;

public record WalletResponse(
    string Id,
    string Name,
    string PhoneNumber, 
    string? OwnerName,
    decimal Balance,
    string? ImageUrl,
    bool IsActive,
    List<WalletOperationType> AllowedOperations,
    DateTime CreatedAt);

public record WalletOperationResponse(
    string Id,
    string WalletId,
    WalletOperationType OperationType,
    decimal TransferredAmount,
    decimal PhysicalCashAmount,
    decimal Profit,
    string? DrawerTransactionId,
    DateTime CreatedAt);

public record WalletDetailsResponse(
    string Id,
    string Name,
    string PhoneNumber, 
    string? OwnerName,
    decimal Balance,
    string? ImageUrl,
    bool IsActive,
    List<WalletOperationType> AllowedOperations,
    DateTime CreatedAt,
    decimal NetProfit);

public record WalletOperationsSummaryResponse(decimal TotalProfit);
