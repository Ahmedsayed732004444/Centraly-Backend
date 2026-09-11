using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Maintenance;

public class MaintenanceProductItem : BaseEntity
{
    public string MaintenanceDeviceId { get; set; } = string.Empty;
    public MaintenanceDevice? MaintenanceDevice { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    
    public decimal MaintenancePrice { get; set; } // Price charged to the customer
    public decimal CostPrice { get; set; } // Calculated from FIFO batches upon delivery
}
