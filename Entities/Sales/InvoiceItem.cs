using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Sales;

public class InvoiceItem : BaseEntity
{
    public string InvoiceId { get; set; } = string.Empty;
    public Invoice? Invoice { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string BatchId { get; set; } = string.Empty;
    public ProductBatch? Batch { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }     // Ø§Ù„Ø³Ø¹Ø± ÙˆÙ‚Øª Ø§Ù„Ø¨ÙŠØ¹ (Ø¬Ù…Ù„Ø©/ØªØ¬Ø²Ø¦Ø©)

    public decimal UnitCost { get; set; }      // Ø³Ø¹Ø± Ø§Ù„Ø´Ø±Ø§Ø¡ ÙˆÙ‚Øª Ø§Ù„Ø¨ÙŠØ¹ (Ù„Ø­Ø³Ø§Ø¨ Ø§Ù„Ø±Ø¨Ø­ Ù„Ø§Ø­Ù‚Ø§Ù‹)

    [NotMapped]
    public decimal LineTotal => Quantity * UnitPrice;
}

