using Centraly.Api.Entities.Returns;
using Centraly.Api.Entities.Sales;
using Centraly.Api.Entities.Suppliers;
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Inventory;

[Microsoft.EntityFrameworkCore.Index(nameof(Barcode))]
public class Product : BaseEntity
{
    public string? Barcode { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;

    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }

    public string CategoryId { get; set; } = string.Empty;
    public Category? Category { get; set; }

    public ProductUsage Usage { get; set; } = ProductUsage.SaleOnly;

    public int Quantity { get; set; } // Representing Total Available Quantity across all batches
    public string? ImageUrl { get; set; }

    public int MinQuantityAlert { get; set; }
    [System.ComponentModel.DataAnnotations.Timestamp] public byte[] Version { get; set; } = null!;
    public string? StorageLocation { get; set; }

    [NotMapped]
    public bool IsOutOfStock => Quantity <= 0;

    [NotMapped]
    public bool IsLowStock => Quantity > 0 && Quantity <= MinQuantityAlert;

    public ICollection<ProductBatch> Batches { get; set; } = new List<ProductBatch>();
    public ICollection<ProductProperty> Properties { get; set; } = new List<ProductProperty>();

    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    public ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();
    public ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
    public ICollection<SupplierReturnItem> SupplierReturnItems { get; set; } = new List<SupplierReturnItem>();
}

