namespace Centraly.Api.Contracts.Notifications;

public record NotificationResponse(
    string Id,
    string Type,
    string Severity,
    string TitleAr,
    string BodyAr,
    string? EntityType,
    string? EntityId,
    string? Link,
    bool IsRead,
    DateTime? ReadAt,
    DateTime CreatedAt);

public record UnreadCountResponse(int Count);
