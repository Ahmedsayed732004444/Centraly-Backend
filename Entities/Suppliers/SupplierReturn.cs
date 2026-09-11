using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Suppliers;

// تسجيل يدوي لإرجاع بضاعة للمورد (عطل / تغيير رأي)
public class SupplierReturn : BaseEntity
{
    public string SupplierId { get; set; } = string.Empty;
    public Supplier? Supplier { get; set; }

    public ReturnReason Reason { get; set; }

    public string? Notes { get; set; }

    public decimal TotalReturnedAmount { get; set; }     // بيتخصم من مديونية المورد أو يترد كاش

    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;

    public ICollection<SupplierReturnItem> Items { get; set; } = [];

    public string? DrawerTransactionId { get; set; }     // لو استرديت فلوس كاش من المورد
    public DrawerTransaction? DrawerTransaction { get; set; }
}
