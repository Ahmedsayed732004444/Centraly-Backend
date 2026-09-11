namespace Centraly.Api.Services.Abstraction;

public interface IDepartmentService
{
    Task<Result<DepartmentResponse>> AddDepartmentAsync(
        CreateDepartmentRequest request, string? userId, CancellationToken ct = default);

    Task<Result<DepartmentResponse>> GetDepartmentAsync(
        string id, CancellationToken ct = default);

    Task<Result<PaginatedList<DepartmentResponse>>> GetAllDepartmentsAsync(
        RequestFilters filters, CancellationToken ct = default);

    Task<Result<DepartmentResponse>> UpdateDepartmentAsync(
        string id, UpdateDepartmentRequest request, string? userId, CancellationToken ct = default);

    Task<Result<bool>> DeleteDepartmentAsync(
        string id, CancellationToken ct = default);
}