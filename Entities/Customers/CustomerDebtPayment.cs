using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Customers;

public class CustomerDebtPayment : BaseEntity
{
    public string CustomerId { get; set; } = string.Empty;
    public Customer? Customer { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
