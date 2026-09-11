using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Suppliers;

// فاتورة توريد: كل مرة تجيب بضاعة من مورد، بتتسجل هنا يدويًا بمعرفة المدير
public class PurchaseInvoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty;

    public string SupplierId { get; set; } = string.Empty;
    public Supplier? Supplier { get; set; }

    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }

    [NotMapped]
    public decimal RemainingAmount => TotalAmount - PaidAmount;   // = بيتضاف على مديونية المورد

    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public ICollection<PurchaseInvoiceItem> Items { get; set; } = [];

    // لو دفعت جزء أو كل المبلغ كاش وقت التوريد نفسه
    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
