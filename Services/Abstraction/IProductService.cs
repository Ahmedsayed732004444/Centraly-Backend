using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Inventory.Products;

namespace Centraly.Api.Services.Abstraction;

public interface IProductService
{
    Task<Result<ProductResponse>> AddProductAsync(CreateProductRequest request, string? userId, CancellationToken ct = default);
    Task<Result<ProductResponse>> GetProductAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<ProductResponse>>> GetAllProductsAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<List<ProductSupplierResponse>>> GetProductSuppliersAsync(string productId, CancellationToken ct = default);
    Task<Result<ProductResponse>> UpdateProductAsync(string id, UpdateProductRequest request, string? userId, CancellationToken ct = default);
    Task<Result<bool>> DeleteProductAsync(string id, CancellationToken ct = default);
    Task<Result<ProductResponse>> AdjustQuantityAsync(string id, AdjustProductQuantityRequest request, string? userId, CancellationToken ct = default);
}