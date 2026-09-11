using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Notifications;

// One row per recipient (not one row shared by many users) so IsRead/ReadAt are
// per-user without a join table. A role-wide alert (e.g. "product out of stock")
// fans out into N rows at creation time - see NotificationService.NotifyRolesAsync.
public class Notification : BaseEntity
{
    public string UserId { get; set; } = string.Empty;

    public NotificationType Type { get; set; }
    public NotificationSeverity Severity { get; set; } = NotificationSeverity.Info;

    public string TitleAr { get; set; } = string.Empty;
    public string BodyAr { get; set; } = string.Empty;

    // What this notification is about, for deep-linking on the frontend
    // (e.g. EntityType="Maintenance", EntityId="<ticketId>", Link="/maintenance?ticketId=<id>").
    public string? EntityType { get; set; }
    public string? EntityId { get; set; }
    public string? Link { get; set; }

    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
}
