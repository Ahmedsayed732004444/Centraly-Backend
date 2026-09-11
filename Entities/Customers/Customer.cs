using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Sales;
using Centraly.Api.Entities.Maintenance;

namespace Centraly.Api.Entities.Customers;

[Microsoft.EntityFrameworkCore.Index(nameof(Phone))]
public class Customer : BaseEntity
{

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public decimal DebtBalance { get; set; } = 0;   // المديونية الحالية

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public ICollection<CustomerDebtPayment> DebtPayments { get; set; } = new List<CustomerDebtPayment>();
    public ICollection<MaintenanceDevice> MaintenanceDevices { get; set; } = new List<MaintenanceDevice>();
}
