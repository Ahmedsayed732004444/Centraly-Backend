namespace Centraly.Api.Errors;

public static class NotificationErrors
{
    public static readonly Error NotFound =
        new("Notification.NotFound", "الإشعار غير موجود", StatusCodes.Status404NotFound);
}
