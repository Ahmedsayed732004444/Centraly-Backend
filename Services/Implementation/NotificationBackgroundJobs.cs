using Centraly.Api.Entities.Drawer;
using Centraly.Api.Entities.Maintenance;
using Centraly.Api.Entities.Notifications;

namespace Centraly.Api.Services.Implementation;

public class NotificationBackgroundJobs(
    ApplicationDbContext dbContext,
    INotificationService notificationService,
    ILogger<NotificationBackgroundJobs> logger) : INotificationBackgroundJobs
{
    private static readonly TimeSpan DueSoonWindow = TimeSpan.FromHours(2);
    private static readonly TimeSpan DrawerOpenTooLong = TimeSpan.FromHours(12);

    private static readonly string[] MaintenanceRoles =
        [DefaultRoles.Admin.Name, DefaultRoles.Manager.Name, DefaultRoles.Technician.Name];
    private static readonly string[] BackOfficeRoles =
        [DefaultRoles.Admin.Name, DefaultRoles.Manager.Name];

    public async Task CheckMaintenanceTicketsAsync(CancellationToken ct = default)
    {
        var now = DateTime.UtcNow;
        var dueSoonThreshold = now.Add(DueSoonWindow);

        var pendingTickets = await dbContext.MaintenanceDevices
            .Where(m => m.Status == MaintenanceStatus.Pending && m.DeliveryDate != null)
            .Select(m => new { m.Id, m.CustomerName, m.DeliveryDate })
            .AsNoTracking()
            .ToListAsync(ct);

        if (pendingTickets.Count == 0) return;

        var alreadyNotified = await GetAlreadyNotifiedAsync(
            nameof(MaintenanceDevice), pendingTickets.Select(t => t.Id),
            [NotificationType.MaintenanceDueSoon, NotificationType.MaintenanceOverdue], ct);

        foreach (var ticket in pendingTickets)
        {
            var deliveryDate = ticket.DeliveryDate!.Value;
            var link = $"/maintenance?ticketId={ticket.Id}";

            if (deliveryDate < now)
            {
                if (alreadyNotified.Contains((ticket.Id, NotificationType.MaintenanceOverdue))) continue;

                await notificationService.NotifyRolesAsync(
                    MaintenanceRoles, NotificationType.MaintenanceOverdue, NotificationSeverity.Critical,
                    "تذكرة صيانة تجاوزت الموعد",
                    $"تذكرة الصيانة الخاصة بالعميل \"{ticket.CustomerName}\" تجاوزت موعد التسليم المحدد ولم يتم تسليمها بعد",
                    nameof(MaintenanceDevice), ticket.Id, link, ct);
            }
            else if (deliveryDate <= dueSoonThreshold)
            {
                if (alreadyNotified.Contains((ticket.Id, NotificationType.MaintenanceDueSoon))) continue;

                await notificationService.NotifyRolesAsync(
                    MaintenanceRoles, NotificationType.MaintenanceDueSoon, NotificationSeverity.Warning,
                    "اقتراب موعد تسليم صيانة",
                    $"موعد تسليم تذكرة الصيانة الخاصة بالعميل \"{ticket.CustomerName}\" خلال أقل من ساعتين",
                    nameof(MaintenanceDevice), ticket.Id, link, ct);
            }
        }

        logger.LogInformation("Maintenance notification sweep checked {Count} pending tickets", pendingTickets.Count);
    }

    public async Task CheckDrawerSessionsLeftOpenAsync(CancellationToken ct = default)
    {
        var threshold = DateTime.UtcNow.Subtract(DrawerOpenTooLong);

        var openSessions = await dbContext.DrawerSessions
            .Where(s => !s.IsClosed && s.OpenedAt < threshold)
            .Select(s => new { s.Id, s.Type, s.OpenedAt })
            .AsNoTracking()
            .ToListAsync(ct);

        if (openSessions.Count == 0) return;

        var alreadyNotified = await GetAlreadyNotifiedAsync(
            nameof(DrawerSession), openSessions.Select(s => s.Id),
            [NotificationType.DrawerLeftOpenOvernight], ct);

        foreach (var session in openSessions)
        {
            if (alreadyNotified.Contains((session.Id, NotificationType.DrawerLeftOpenOvernight))) continue;

            var shiftName = session.Type == DrawerType.Maintenance ? "درج الصيانة" : "درج المبيعات";

            await notificationService.NotifyRolesAsync(
                BackOfficeRoles, NotificationType.DrawerLeftOpenOvernight, NotificationSeverity.Warning,
                "جلسة درج مفتوحة منذ فترة طويلة",
                $"{shiftName} لسه مفتوح من {session.OpenedAt:yyyy-MM-dd HH:mm} ولم يتم تقفيله",
                nameof(DrawerSession), session.Id, "/finance/drawer", ct);
        }
    }

    private async Task<HashSet<(string EntityId, NotificationType Type)>> GetAlreadyNotifiedAsync(
        string entityType, IEnumerable<string> entityIds, NotificationType[] types, CancellationToken ct)
    {
        var idList = entityIds.ToList();

        var rows = await dbContext.Notifications
            .Where(n => n.EntityType == entityType && n.EntityId != null && idList.Contains(n.EntityId) && types.Contains(n.Type))
            .Select(n => new { n.EntityId, n.Type })
            .Distinct()
            .ToListAsync(ct);

        return rows.Select(r => (r.EntityId!, r.Type)).ToHashSet();
    }
}
