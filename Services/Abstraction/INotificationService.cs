using Centraly.Api.Contracts.Notifications;
using Centraly.Api.Entities.Inventory;
using Centraly.Api.Entities.Notifications;

namespace Centraly.Api.Services.Abstraction;

public interface INotificationService
{
    Task NotifyUserAsync(
        string userId, NotificationType type, NotificationSeverity severity, string titleAr, string bodyAr,
        string? entityType = null, string? entityId = null, string? link = null, CancellationToken ct = default);

    Task NotifyRolesAsync(
        IEnumerable<string> roleNames, NotificationType type, NotificationSeverity severity, string titleAr, string bodyAr,
        string? entityType = null, string? entityId = null, string? link = null, CancellationToken ct = default);

    // Called right after a Product.Quantity mutation (with the quantity it had just
    // before) - persists+broadcasts an out-of-stock/low-stock alert only when this
    // specific mutation is what crossed the threshold, so repeated sales against an
    // already-low product don't spam a new notification every time.
    Task NotifyStockChangeAsync(Product product, int quantityBefore, CancellationToken ct = default);

    Task<Result<PaginatedList<NotificationResponse>>> GetForUserAsync(
        string userId, RequestFilters filters, bool unreadOnly, CancellationToken ct = default);

    Task<Result<UnreadCountResponse>> GetUnreadCountAsync(string userId, CancellationToken ct = default);

    Task<Result> MarkAsReadAsync(string userId, string notificationId, CancellationToken ct = default);

    Task<Result> MarkAllAsReadAsync(string userId, CancellationToken ct = default);
}
