using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Suppliers;

namespace Centraly.Api.Services.Abstraction;

public interface ISupplierService
{
    Task<Result<SupplierResponse>> AddSupplierAsync(CreateSupplierRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SupplierResponse>> GetSupplierAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SupplierResponse>>> GetAllSuppliersAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<SupplierResponse>> UpdateSupplierAsync(string id, UpdateSupplierRequest request, string? userId, CancellationToken ct = default);
    Task<Result<bool>> DeleteSupplierAsync(string id, CancellationToken ct = default);
    Task<Result<List<SupplierStatementItemResponse>>> GetSupplierStatementAsync(string id, RequestFilters filters, CancellationToken ct = default);
    Task<Result<IReadOnlyList<SupplierBatchResponse>>> GetSupplierAvailableBatchesAsync(string supplierId, CancellationToken ct = default);
}
