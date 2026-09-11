using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Customers;
using Centraly.Api.Entities.Drawer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centraly.Api.Entities.Maintenance;

[Microsoft.EntityFrameworkCore.Index(nameof(Status))]
public class MaintenanceDevice : BaseEntity
{
    public string CustomerName { get; set; } = string.Empty;
    public string? CustomerPhone { get; set; }

    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    // Optional description of the device being repaired
    public string? DeviceDescription { get; set; }
    public string? Problem { get; set; }
    public string? Solution { get; set; }

    // Financials
    public decimal ServicePrice { get; set; }
    public decimal TotalPartsPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalCost { get; set; } // COGS of parts
    public decimal PaidAmount { get; set; }

    // Clamped to 0 so a deposit taken before the device is priced/diagnosed (TotalPrice
    // still 0) doesn't display as a negative "remaining amount" on the ticket list - the
    // deposit itself stays fully tracked in PaidAmount and is settled correctly once
    // DeliverMaintenanceAsync computes the real remainingAmount (which can legitimately
    // go negative there, triggering a refund transaction).
    [NotMapped]
    public decimal RemainingAmount => Math.Max(0, TotalPrice - PaidAmount);

    public DateTime? DeliveryDate { get; set; }

    public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Pending;

    public ICollection<MaintenanceProductItem> ProductsUsed { get; set; } = [];

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
