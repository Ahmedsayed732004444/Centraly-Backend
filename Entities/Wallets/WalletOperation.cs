using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Wallets;

public enum WalletOperationType
{
    CashIn = 1,   // بيع (إيداع كاش لعميل)
    CashOut = 2,  // سحب من عميل
    Recharge = 3  // شحن رصيد
}

public class WalletOperation : BaseEntity
{
    public string WalletId { get; set; } = string.Empty;
    public Wallet Wallet { get; set; } = null!;

    public WalletOperationType OperationType { get; set; }
    public decimal TransferredAmount { get; set; }
    public decimal PhysicalCashAmount { get; set; }
    public decimal Profit { get; set; }
    
    public string? DrawerTransactionId { get; set; }
}
