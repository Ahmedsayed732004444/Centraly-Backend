using Centraly.Api.Entities.Common;

namespace Centraly.Api.Contracts.Maintenance;

public record MaintenanceProductItemDto(
    string ProductId,
    string ProductName,
    int Quantity,
    decimal MaintenancePrice,
    decimal CostPrice);
