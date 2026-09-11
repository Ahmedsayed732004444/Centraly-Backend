using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Entities.Inventory;

public class ProductBatch : BaseEntity
{
    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    // How many units were initially bought in this batch
    public int InitialQuantity { get; set; }

    // How many units are still available for sale from this batch
    public int AvailableQuantity { get; set; }
    [System.ComponentModel.DataAnnotations.Timestamp] public byte[] Version { get; set; } = null!;

    public decimal PurchasePrice { get; set; }
    public decimal WholesalePrice { get; set; }
    public decimal RetailPrice { get; set; }
    public decimal MaintenancePrice { get; set; }   // Ø³Ø¹Ø± Ø§Ù„ØµÙŠØ§Ù†Ø© (Ù„Ù„Ù…Ù†ØªØ¬Ø§Øª Ø°Ø§Øª Ø§Ù„ØµÙŠØ§Ù†Ø©)

    public DateTime DateReceived { get; set; }
}


