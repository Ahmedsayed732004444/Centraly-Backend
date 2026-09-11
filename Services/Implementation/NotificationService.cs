using Centraly.Api.Contracts.Notifications;
using Centraly.Api.Entities.Inventory;
using Centraly.Api.Entities.Notifications;
using Centraly.Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Centraly.Api.Services.Implementation;

public class NotificationService(
    ApplicationDbContext dbContext,
    IHubContext<NotificationHub> hubContext) : INotificationService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IHubContext<NotificationHub> _hubContext = hubContext;

    public async Task NotifyUserAsync(
        string userId, NotificationType type, NotificationSeverity severity, string titleAr, string bodyAr,
        string? entityType = null, string? entityId = null, string? link = null, CancellationToken ct = default)
    {
        var notification = new Notification
        {
            UserId = userId,
            Type = type,
            Severity = severity,
            TitleAr = titleAr,
            BodyAr = bodyAr,
            EntityType = entityType,
            EntityId = entityId,
            Link = link,
            CreatedByUserId = userId
        };

        _dbContext.Notifications.Add(notification);
        await _dbContext.SaveChangesAsync(ct);

        await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", ToResponse(notification), ct);
    }

    public async Task NotifyRolesAsync(
        IEnumerable<string> roleNames, NotificationType type, NotificationSeverity severity, string titleAr, string bodyAr,
        string? entityType = null, string? entityId = null, string? link = null, CancellationToken ct = default)
    {
        var roleNameList = roleNames.ToList();

        var userIds = await _dbContext.UserRoles
            .Join(_dbContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => new { ur.UserId, r.Name })
            .Where(x => x.Name != null && roleNameList.Contains(x.Name))
            .Select(x => x.UserId)
            .Distinct()
            .ToListAsync(ct);

        if (userIds.Count == 0) return;

        var notifications = userIds.Select(userId => new Notification
        {
            UserId = userId,
            Type = type,
            Severity = severity,
            TitleAr = titleAr,
            BodyAr = bodyAr,
            EntityType = entityType,
            EntityId = entityId,
            Link = link
        }).ToList();

        _dbContext.Notifications.AddRange(notifications);
        await _dbContext.SaveChangesAsync(ct);

        // Sent per-user (not as one group broadcast) so each recipient's payload carries
        // *their own* Notification.Id - a shared payload would let a client try to mark
        // another user's row as read.
        foreach (var notification in notifications)
        {
            await _hubContext.Clients.User(notification.UserId).SendAsync("ReceiveNotification", ToResponse(notification), ct);
        }
    }

    public Task NotifyStockChangeAsync(Product product, int quantityBefore, CancellationToken ct = default)
    {
        var justWentOutOfStock = product.Quantity <= 0 && quantityBefore > 0;
        var justWentLow = !justWentOutOfStock && product.Quantity > 0
            && product.Quantity <= product.MinQuantityAlert && quantityBefore > product.MinQuantityAlert;

        if (!justWentOutOfStock && !justWentLow)
            return Task.CompletedTask;

        var productName = product.Name ?? product.Id;
        var link = $"/inventory/products/{product.Id}";

        return justWentOutOfStock
            ? NotifyRolesAsync(
                [DefaultRoles.Admin.Name, DefaultRoles.Manager.Name],
                NotificationType.ProductOutOfStock, NotificationSeverity.Critical,
                "نفاد مخزون منتج",
                $"المنتج \"{productName}\" نفد من المخزون بالكامل",
                nameof(Product), product.Id, link, ct)
            : NotifyRolesAsync(
                [DefaultRoles.Admin.Name, DefaultRoles.Manager.Name],
                NotificationType.ProductLowStock, NotificationSeverity.Warning,
                "اقتراب نفاد مخزون منتج",
                $"المنتج \"{productName}\" اقترب من الحد الأدنى للمخزون (الكمية الحالية: {product.Quantity})",
                nameof(Product), product.Id, link, ct);
    }

    public async Task<Result<PaginatedList<NotificationResponse>>> GetForUserAsync(
        string userId, RequestFilters filters, bool unreadOnly, CancellationToken ct = default)
    {
        var query = _dbContext.Notifications
            .Where(n => n.UserId == userId)
            .Where(n => !unreadOnly || !n.IsRead)
            .OrderByDescending(n => n.CreatedAt)
            .Select(n => new NotificationResponse(
                n.Id, n.Type.ToString(), n.Severity.ToString(), n.TitleAr, n.BodyAr,
                n.EntityType, n.EntityId, n.Link, n.IsRead, n.ReadAt, n.CreatedAt))
            .AsNoTracking();

        var result = await query.ToPaginatedListAsync(filters, ct);
        return Result.Success(result);
    }

    public async Task<Result<UnreadCountResponse>> GetUnreadCountAsync(string userId, CancellationToken ct = default)
    {
        var count = await _dbContext.Notifications.CountAsync(n => n.UserId == userId && !n.IsRead, ct);
        return Result.Success(new UnreadCountResponse(count));
    }

    public async Task<Result> MarkAsReadAsync(string userId, string notificationId, CancellationToken ct = default)
    {
        var rows = await _dbContext.Notifications
            .Where(n => n.Id == notificationId && n.UserId == userId && !n.IsRead)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(n => n.IsRead, true)
                .SetProperty(n => n.ReadAt, DateTime.UtcNow), ct);

        if (rows == 0)
        {
            var exists = await _dbContext.Notifications.AnyAsync(n => n.Id == notificationId && n.UserId == userId, ct);
            if (!exists) return Result.Failure(NotificationErrors.NotFound);
        }

        return Result.Success();
    }

    public async Task<Result> MarkAllAsReadAsync(string userId, CancellationToken ct = default)
    {
        await _dbContext.Notifications
            .Where(n => n.UserId == userId && !n.IsRead)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(n => n.IsRead, true)
                .SetProperty(n => n.ReadAt, DateTime.UtcNow), ct);

        return Result.Success();
    }

    private static NotificationResponse ToResponse(Notification n) => new(
        n.Id, n.Type.ToString(), n.Severity.ToString(), n.TitleAr, n.BodyAr,
        n.EntityType, n.EntityId, n.Link, n.IsRead, n.ReadAt, n.CreatedAt);
}
