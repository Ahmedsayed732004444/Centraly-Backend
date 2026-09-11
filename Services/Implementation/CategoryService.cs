using Microsoft.Extensions.Caching.Hybrid;

namespace Centraly.Api.Services.Implementation;

public class CategoryService(ApplicationDbContext dbContext, ILogger<CategoryService> logger, HybridCache hybridCache) : ICategoryService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly HybridCache _hybridCache = hybridCache;

    private const string CachePrefix = "categories";

    private static readonly string[] AllowedCategorySortColumns = ["Name", "CreatedAt"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Category
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<CategoryResponse>> AddCategoryAsync(
        CreateCategoryRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var department = await _dbContext.Departments
                .Where(d => d.Id == request.DepartmentId && !d.IsDeleted)
                .Select(d => new DepartmentSummary(d.Id, d.Name))
                .FirstOrDefaultAsync(ct);

            if (department is null)
                return Result.Failure<CategoryResponse>(CategoryErrors.DepartmentNotFound);

            var category = new Category
            {
                Name = request.Name,
                DepartmentId = request.DepartmentId,
                CreatedByUserId = userId
            };

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync(ct);
            await _hybridCache.RemoveByTagAsync(CachePrefix, ct);

            var response = new CategoryResponse(
                category.Id,
                category.Name,
                department,
                0,
                category.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating category for user {UserId}", userId);
            return Result.Failure<CategoryResponse>(CategoryErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Category By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<CategoryResponse>> GetCategoryAsync(string id, CancellationToken ct = default)
    {
        var response = await _hybridCache.GetOrCreateAsync(
            $"{CachePrefix}-{id}",
            async ct => await _dbContext.Categories
                .Where(c => c.Id == id)
                .ProjectToResponse()
                .FirstOrDefaultAsync(ct),
            tags: [CachePrefix],
            cancellationToken: ct);

        return response is null
            ? Result.Failure<CategoryResponse>(CategoryErrors.CategoryNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Categories
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<CategoryResponse>>> GetAllCategoriesAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var result = await _hybridCache.GetOrCreateAsync(
                $"{CachePrefix}-all-{filters.PageNumber}-{filters.PageSize}-{filters.SearchValue}-{filters.SortColumn}-{filters.SortDirection}-{filters.DepartmentId}",
                async ct =>
                {
                    var query = _dbContext.Categories
                        .Where(c => !c.IsDeleted)
                        .Where(c => filters.DepartmentId == null || c.DepartmentId == filters.DepartmentId)
                        .ApplyFilters(filters,
                            searchPredicate: x => x.Name.Contains(filters.SearchValue!),
                            allowedSortColumns: AllowedCategorySortColumns);

                    return await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
                },
                tags: [CachePrefix],
                cancellationToken: ct);

            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for categories");
            return Result.Failure<PaginatedList<CategoryResponse>>(CategoryErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Update Category
    // ─────────────────────────────────────────────────────────────────
    // Instead of Fetch(+Include Department) -> Track -> SaveChanges -> re-query counts,
    // this validates the new department only when it actually changes, then issues a
    // single ExecuteUpdateAsync (no tracking, no full entity load), then re-projects.

    public async Task<Result<CategoryResponse>> UpdateCategoryAsync(
        string id, UpdateCategoryRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var currentDepartmentId = await _dbContext.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .Select(c => (string?)c.DepartmentId)
                .FirstOrDefaultAsync(ct);

            if (currentDepartmentId is null)
                return Result.Failure<CategoryResponse>(CategoryErrors.CategoryNotFound);

            if (currentDepartmentId != request.DepartmentId)
            {
                var departmentExists = await _dbContext.Departments
                    .AnyAsync(d => d.Id == request.DepartmentId && !d.IsDeleted, ct);

                if (!departmentExists)
                    return Result.Failure<CategoryResponse>(CategoryErrors.DepartmentNotFound);
            }

            await _dbContext.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.Name, request.Name)
                    .SetProperty(c => c.DepartmentId, request.DepartmentId)
                    .SetProperty(c => c.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(c => c.UpdatedByUserId, userId), ct);

            await _hybridCache.RemoveByTagAsync(CachePrefix, ct);

            var response = await _dbContext.Categories
                .Where(c => c.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating category {CategoryId}", id);
            return Result.Failure<CategoryResponse>(CategoryErrors.UpdateFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Soft Delete Category
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<bool>> DeleteCategoryAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.IsDeleted, true)
                    .SetProperty(c => c.DeletedAt, DateTime.UtcNow), ct);

            if (deleted == 0)
                return Result.Failure<bool>(CategoryErrors.CategoryNotFound);

            await _hybridCache.RemoveByTagAsync(CachePrefix, ct);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting category {CategoryId}", id);
            return Result.Failure<bool>(CategoryErrors.DeleteFailed);
        }
    }

}