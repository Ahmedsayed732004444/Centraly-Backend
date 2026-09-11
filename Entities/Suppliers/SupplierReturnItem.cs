using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Suppliers;

public class SupplierReturnItem : BaseEntity
{
    public string SupplierReturnId { get; set; } = string.Empty;
    public SupplierReturn? SupplierReturn { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public int Quantity { get; set; }              // بتتخصم من Product.Quantity

    public decimal UnitCost { get; set; }
}
