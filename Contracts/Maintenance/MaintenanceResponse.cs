namespace Centraly.Api.Contracts.Maintenance;

public record MaintenanceResponse(
    string Id,
    string CustomerName,
    string? CustomerPhone,
    string? CustomerId,
    string? DeviceDescription,
    string? Problem,
    string? Solution,
    decimal ServicePrice,
    decimal TotalPartsPrice,
    decimal TotalPrice,
    decimal TotalCost,
    decimal PaidAmount,
    decimal RemainingAmount,
    DateTime? DeliveryDate,
    string Status,
    List<MaintenanceProductItemDto> ProductsUsed,
    DateTime CreatedAt);
