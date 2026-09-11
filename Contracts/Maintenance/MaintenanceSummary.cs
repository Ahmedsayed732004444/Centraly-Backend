namespace Centraly.Api.Contracts.Maintenance;

public record MaintenanceSummary(
    string Id,
    string CustomerName,
    string? CustomerPhone,
    string? DeviceDescription,
    string? Problem,
    decimal TotalPrice,
    decimal PaidAmount,
    decimal RemainingAmount,
    DateTime? DeliveryDate,
    string Status,
    DateTime CreatedAt);
