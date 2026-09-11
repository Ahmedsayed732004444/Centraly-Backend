using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Drawer;

public class DrawerSession : BaseEntity
{
    public DrawerType Type { get; set; } = DrawerType.Sales;

    public decimal OpeningBalance { get; set; }

    public DateTime OpenedAt { get; set; } = DateTime.UtcNow;

    public string OpenedByUserId { get; set; } = string.Empty;

    public bool IsClosed { get; set; } = false;

    public DateTime? ClosedAt { get; set; }
    public decimal? TotalIncome { get; set; }
    public decimal? TotalExpense { get; set; }
    public decimal? ClosingBalance { get; set; }
    public decimal RunningBalance { get; set; }
    public decimal? TotalProfit { get; set; }

    // Optimistic concurrency token: RecordTransactionAsync retries on conflict so that
    // two transactions racing on RunningBalance can never silently lose an update, even
    // when a caller's ambient transaction isn't itself Serializable.
    [System.ComponentModel.DataAnnotations.Timestamp] public byte[] Version { get; set; } = null!;

    public ICollection<DrawerTransaction> Transactions { get; set; } = [];
}

