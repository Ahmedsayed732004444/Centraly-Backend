namespace Centraly.Api.Entities.Notifications;

// Extensible on purpose: add a new member here + a call site that raises it. Nothing
// else in the notification pipeline (entity, hub, service, controller) needs to change
// to support a new type.
public enum NotificationType
{
    MaintenanceDueSoon = 1,
    MaintenanceOverdue = 2,
    ProductOutOfStock = 3,
    ProductLowStock = 4,
    OwnerWithdrawal = 5,
    DrawerLeftOpenOvernight = 6
}

public enum NotificationSeverity
{
    Info = 1,
    Warning = 2,
    Critical = 3
}
