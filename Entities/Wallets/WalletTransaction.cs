using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Wallets;

public enum WalletTransactionType
{
    Income = 1,
    Expense = 2
}

public class WalletTransaction : BaseEntity
{
    public string WalletId { get; set; } = string.Empty;
    public Wallet Wallet { get; set; } = null!;

    public WalletTransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public decimal BalanceAfter { get; set; }
    public string? Notes { get; set; }
}
