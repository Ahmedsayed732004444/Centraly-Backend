using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Suppliers;

public class SupplierPayment : BaseEntity
{
    public string SupplierId { get; set; } = string.Empty;
    public Supplier? Supplier { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
