using Microsoft.Extensions.Caching.Hybrid;

namespace Centraly.Api.Services.Implementation;

public class DepartmentService(ApplicationDbContext dbContext, ILogger<DepartmentService> logger, HybridCache hybridCache) : IDepartmentService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<DepartmentService> _logger = logger;
    private readonly HybridCache _hybridCache = hybridCache;

    // Departments are read constantly (every product/category picker) and change
    // rarely (admin-only CRUD) - a good HybridCache candidate, unlike anything
    // money/stock related. Every cached entry below carries this same tag, so any
    // write can invalidate the whole entity with one RemoveByTagAsync call instead of
    // tracking each filter/id variant's exact key.
    private const string CachePrefix = "departments";

    private static readonly string[] AllowedDepartmentSortColumns = ["Name", "CreatedAt"];

    // ════════════════════════════════════════════════════════════════
    //  Add Department
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<DepartmentResponse>> AddDepartmentAsync(
        CreateDepartmentRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var department = new Department
            {
                Name = request.Name,
                CreatedByUserId = userId
            };

            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync(ct);
            await _hybridCache.RemoveByTagAsync(CachePrefix, ct);

            var response = new DepartmentResponse(
                department.Id, department.Name, 0, 0, department.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating department for user {UserId}", userId);
            return Result.Failure<DepartmentResponse>(DepartmentErrors.CreationFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Get Department By Id
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<DepartmentResponse>> GetDepartmentAsync(string id, CancellationToken ct = default)
    {
        var response = await _hybridCache.GetOrCreateAsync(
            $"{CachePrefix}-{id}",
            async ct => await _dbContext.Departments
                .Where(d => d.Id == id)
                .ProjectToResponse()
                .FirstOrDefaultAsync(ct),
            tags: [CachePrefix],
            cancellationToken: ct);

        return response is null
            ? Result.Failure<DepartmentResponse>(DepartmentErrors.DepartmentNotFound)
            : Result.Success(response);
    }

    // ════════════════════════════════════════════════════════════════
    //  Get All Departments
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<PaginatedList<DepartmentResponse>>> GetAllDepartmentsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var result = await _hybridCache.GetOrCreateAsync(
                $"{CachePrefix}-all-{filters.PageNumber}-{filters.PageSize}-{filters.SearchValue}-{filters.SortColumn}-{filters.SortDirection}",
                async ct =>
                {
                    var query = _dbContext.Departments
                        .Where(d => !d.IsDeleted)
                        .ApplyFilters(filters,
                            searchPredicate: x => x.Name.Contains(filters.SearchValue!),
                            allowedSortColumns: AllowedDepartmentSortColumns);

                    return await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
                },
                tags: [CachePrefix],
                cancellationToken: ct);

            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for departments");
            return Result.Failure<PaginatedList<DepartmentResponse>>(DepartmentErrors.InvalidSortColumn);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Update Department
    // ════════════════════════════════════════════════════════════════
    // Uses ExecuteUpdateAsync: issues a single UPDATE statement directly
    // against the database with no entity fetch and no change tracking,
    // instead of Fetch -> Track -> SaveChanges -> re-query counts (3 round-trips).

    public async Task<Result<DepartmentResponse>> UpdateDepartmentAsync(
        string id, UpdateDepartmentRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var updated = await _dbContext.Departments
                .Where(d => d.Id == id && !d.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(d => d.Name, request.Name)
                    .SetProperty(d => d.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(d => d.UpdatedByUserId, userId), ct);

            if (updated == 0)
                return Result.Failure<DepartmentResponse>(DepartmentErrors.DepartmentNotFound);

            await _hybridCache.RemoveByTagAsync(CachePrefix, ct);
            // Cached CategoryResponse/ProductResponse entries embed the department's
            // name - a rename here must also invalidate their cache, not just ours.
            await _hybridCache.RemoveByTagAsync("categories", ct);

            var response = await _dbContext.Departments
                .Where(d => d.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating department {DepartmentId}", id);
            return Result.Failure<DepartmentResponse>(DepartmentErrors.UpdateFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Soft Delete Department
    // ════════════════════════════════════════════════════════════════
    // Same idea: soft delete happens in a single UPDATE, with no fetch beforehand.

    public async Task<Result<bool>> DeleteDepartmentAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Departments
                .Where(d => d.Id == id && !d.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(d => d.IsDeleted, true)
                    .SetProperty(d => d.DeletedAt, DateTime.UtcNow), ct);

            if (deleted == 0)
                return Result.Failure<bool>(DepartmentErrors.DepartmentNotFound);

            await _hybridCache.RemoveByTagAsync(CachePrefix, ct);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting department {DepartmentId}", id);
            return Result.Failure<bool>(DepartmentErrors.DeleteFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Shared projection (selection loading - no Include anywhere)
    // ════════════════════════════════════════════════════════════════

}