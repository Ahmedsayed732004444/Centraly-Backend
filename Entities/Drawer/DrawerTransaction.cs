using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Drawer;

public class DrawerTransaction : BaseEntity
{
    public string DrawerSessionId { get; set; } = string.Empty;
    public DrawerSession? DrawerSession { get; set; }

    public DrawerTransactionType Type { get; set; }         // إيراد / صادر
    public DrawerTransactionCategory Category { get; set; } // مبيعات/موردين/صيانة/مرتجعات/تشغيلية

    public decimal Amount { get; set; }
    public decimal Profit { get; set; }
    public decimal Balance { get; set; }   // الرصيد الجاري بعد الحركة دي
    public string? Source { get; set; }    // مصدر الحركة اليدوية (كتابة حرة)
    public string? Notes { get; set; }

    public string UserId { get; set; } = string.Empty;
}
