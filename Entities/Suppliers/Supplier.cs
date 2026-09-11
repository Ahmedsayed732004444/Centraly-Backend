using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Suppliers;

public class Supplier : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Type { get; set; }        // نوع المورد

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public decimal DebtBalance { get; set; } = 0;   // المديونية للمورد (بتتحدث تلقائي من الفواتير والدفعات)

    public ICollection<SupplierPayment> Payments { get; set; } = [];
    public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = [];
    public ICollection<SupplierReturn> Returns { get; set; } = [];
}
