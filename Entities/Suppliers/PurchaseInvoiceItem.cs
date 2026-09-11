using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Suppliers;

public class PurchaseInvoiceItem : BaseEntity
{
    public string PurchaseInvoiceId { get; set; } = string.Empty;
    public PurchaseInvoice? PurchaseInvoice { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public int Quantity { get; set; }              // الكمية اللي دخلت المخزون

    public decimal UnitCost { get; set; }           // سعر الشراء وقت التوريد (بيحدّث Product.PurchasePrice)

    [NotMapped]
    public decimal LineTotal => Quantity * UnitCost;
}
