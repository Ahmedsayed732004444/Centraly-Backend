
namespace Centraly.Api.Entities.Wallets;

public class Wallet : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? OwnerName { get; set; }
    public decimal Balance { get; set; } = 0;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public List<WalletOperationType> AllowedOperations { get; set; } = [WalletOperationType.CashIn, WalletOperationType.CashOut];

    // Navigation properties
    public ICollection<WalletTransaction> Transactions { get; set; } = new List<WalletTransaction>();
    public ICollection<WalletOperation> Operations { get; set; } = new List<WalletOperation>();
}
