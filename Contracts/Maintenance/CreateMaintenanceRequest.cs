namespace Centraly.Api.Contracts.Maintenance;

// Step 1: Quick ticket creation - minimal info only
public record CreateMaintenanceRequest(
    string CustomerName,
    string? CustomerPhone,
    string? CustomerId,
    string? DeviceDescription,   // optional: what device/item is being repaired
    string? Problem,             // optional: problem description
    decimal PaidAmount,          // advance payment, default 0
    DateTime? DeliveryDate);     // optional scheduled pickup time

// Step 2: Update ticket - add products + service price
public record UpdateMaintenanceRequest(
    string CustomerName,
    string? CustomerPhone,
    string? CustomerId,
    string? DeviceDescription,
    string? Problem,
    string? Solution,
    decimal ServicePrice,
    decimal PaidAmount,
    DateTime? DeliveryDate,
    List<UpdateMaintenanceProductItemRequest> ProductsUsed);

public record UpdateMaintenanceProductItemRequest(
    string ProductId,
    int Quantity,
    decimal MaintenancePrice);

