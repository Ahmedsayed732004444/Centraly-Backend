using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Inventory.Categories;

namespace Centraly.Api.Services.Abstraction;

public interface ICategoryService
{
    Task<Result<CategoryResponse>> AddCategoryAsync(CreateCategoryRequest request, string? userId, CancellationToken ct = default);
    Task<Result<CategoryResponse>> GetCategoryAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<CategoryResponse>>> GetAllCategoriesAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<CategoryResponse>> UpdateCategoryAsync(string id, UpdateCategoryRequest request, string? userId, CancellationToken ct = default);
    Task<Result<bool>> DeleteCategoryAsync(string id, CancellationToken ct = default);
}
