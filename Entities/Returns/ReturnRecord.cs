using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Sales;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Returns;

public class ReturnRecord : BaseEntity
{
    public string InvoiceId { get; set; } = string.Empty;
    public Invoice? Invoice { get; set; }

    public bool IsFullInvoiceReturn { get; set; }

    public ReturnReason Reason { get; set; }

    public string? Notes { get; set; }

    public decimal TotalReturnedAmount { get; set; }

    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;

    public ICollection<ReturnItem> Items { get; set; } = new List<ReturnItem>();

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
