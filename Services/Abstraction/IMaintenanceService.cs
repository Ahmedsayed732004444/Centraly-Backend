using Centraly.Api.Contracts.Maintenance;

namespace Centraly.Api.Services.Abstraction;

public interface IMaintenanceService
{
    Task<Result<MaintenanceResponse>> CreateMaintenanceAsync(CreateMaintenanceRequest request, string userId, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> UpdateMaintenanceAsync(string id, UpdateMaintenanceRequest request, string userId, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> DeliverMaintenanceAsync(string id, string userId, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> ReturnMaintenanceAsync(string id, string userId, CancellationToken ct = default);
    Task<Result<PaginatedList<MaintenanceSummary>>> GetAllMaintenanceAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> GetByIdAsync(string id, CancellationToken ct = default);
}