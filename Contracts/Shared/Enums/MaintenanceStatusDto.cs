namespace Centraly.Api.Contracts.Shared.Enums;

/// <summary>
/// Data transfer object for the MaintenanceStatus enum.
/// </summary>
public enum MaintenanceStatusDto
{
    Pending = 1,   // معلق
    Delivered = 2, // تم التسليم
    Returned = 3   // مرتجع
}
