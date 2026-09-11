using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Customers;
using Centraly.Api.Entities.Returns;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Sales;

[Microsoft.EntityFrameworkCore.Index(nameof(CreatedAt))]
public class Invoice : BaseEntity
{

    public string InvoiceNumber { get; set; } = string.Empty;

    public string? CustomerId { get; set; }     // Ù…Ù…ÙƒÙ† Ø¨ÙŠØ¹ Ø¨Ø¯ÙˆÙ† Ø¹Ù…ÙŠÙ„
    public Customer? Customer { get; set; }

    public SaleType SaleType { get; set; }        // Ø¬Ù…Ù„Ø© / ØªØ¬Ø²Ø¦Ø©
    public PaymentMethod PaymentMethod { get; set; }  // ÙƒØ§Ø´ / Ø¢Ø¬Ù„

    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RecordedProfit { get; set; }

    [NotMapped]
    public decimal RemainingAmount => TotalAmount - PaidAmount;   // = Ù…Ø¯ÙŠÙˆÙ†ÙŠØ© Ù„Ùˆ Ø¯ÙØ¹ Ø£Ù‚Ù„ Ù…Ù† Ø§Ù„Ø¥Ø¬Ù…Ø§Ù„ÙŠ

    public string? Notes { get; set; }
    public string UserId { get; set; } = string.Empty;          // Ø§Ù„Ù…ÙˆØ¸Ù/Ø§Ù„Ù…Ø³ØªØ®Ø¯Ù… Ø§Ù„Ø°ÙŠ Ø£Ù†Ø´Ø£ Ø§Ù„ÙØ§ØªÙˆØ±Ø©

    public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public ICollection<ReturnRecord> Returns { get; set; } = new List<ReturnRecord>();

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}


