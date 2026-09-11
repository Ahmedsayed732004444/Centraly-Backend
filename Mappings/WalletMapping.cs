using Centraly.Api.Contracts.Wallets;
using Centraly.Api.Entities.Wallets;

namespace Centraly.Api.Mappings;

public static class WalletMapping
{
    public static WalletResponse ToResponse(this Wallet wallet)
    {
        return new WalletResponse(
            wallet.Id,
            wallet.Name,
            wallet.PhoneNumber,
            wallet.OwnerName,
            wallet.Balance,
            wallet.ImageUrl,
            wallet.IsActive,
            wallet.AllowedOperations,
            wallet.CreatedAt
        );
    }

    public static WalletDetailsResponse ToDetailsResponse(this Wallet wallet, decimal netProfit)
    {
        return new WalletDetailsResponse(
            wallet.Id,
            wallet.Name,
            wallet.PhoneNumber,
            wallet.OwnerName,
            wallet.Balance,
            wallet.ImageUrl,
            wallet.IsActive,
            wallet.AllowedOperations,
            wallet.CreatedAt,
            netProfit
        );
    }

    public static WalletOperationResponse ToResponse(this WalletOperation operation)
    {
        return new WalletOperationResponse(
            operation.Id,
            operation.WalletId,
            operation.OperationType,
            operation.TransferredAmount,
            operation.PhysicalCashAmount,
            operation.Profit,
            operation.DrawerTransactionId,
            operation.CreatedAt
        );
    }
}
