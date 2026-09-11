using Centraly.Api.Contracts.Roles;
using Mapster;
using Microsoft.Extensions.Caching.Hybrid;

namespace Centraly.Api.Services;

public class RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context, HybridCache hybridCache) : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly ApplicationDbContext _context = context;
    private readonly HybridCache _hybridCache = hybridCache;

    // Roles/permissions are read on every request that needs an authorization check's
    // supporting UI (role pickers, the roles admin page) and change only when an admin
    // edits a role - a clear HybridCache candidate.
    private const string CachePrefix = "roles";

    public Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
        _hybridCache.GetOrCreateAsync(
            $"{CachePrefix}-all-{includeDisabled}",
            async ct => (IEnumerable<RoleResponse>)await _roleManager.Roles
                .Where(x => !x.IsDefault && (!x.IsDeleted || includeDisabled))
                .ProjectToType<RoleResponse>()
                .ToListAsync(ct),
            tags: [CachePrefix],
            cancellationToken: cancellationToken).AsTask();

    public async Task<Result<RoleDetailResponse>> GetAsync(string id)
    {
        var response = await _hybridCache.GetOrCreateAsync(
            $"{CachePrefix}-{id}",
            async ct =>
            {
                if (await _roleManager.FindByIdAsync(id) is not { } role)
                    return null;

                var permissions = await _roleManager.GetClaimsAsync(role);
                return new RoleDetailResponse(role.Id, role.Name!, role.IsDeleted, permissions.Select(x => x.Value));
            },
            tags: [CachePrefix]);

        return response is null
            ? Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound)
            : Result.Success(response);
    }

    public async Task<Result<RoleDetailResponse>> AddAsync(RoleRequest request)
    {
        var roleIsExists = await _roleManager.RoleExistsAsync(request.Name);

        if (roleIsExists)
            return Result.Failure<RoleDetailResponse>(RoleErrors.DuplicatedRole);

        var allowedPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure<RoleDetailResponse>(RoleErrors.InvalidPermissions);

        var role = new ApplicationRole
        {
            Name = request.Name,
            ConcurrencyStamp = Guid.CreateVersion7().ToString()
        };

        var result = await _roleManager.CreateAsync(role);

        if (result.Succeeded)
        {
            var permissions = request.Permissions
                .Select(x => new IdentityRoleClaim<string>
                {
                    ClaimType = Permissions.Type,
                    ClaimValue = x,
                    RoleId = role.Id
                });

            await _context.AddRangeAsync(permissions);
            await _context.SaveChangesAsync();
            await _hybridCache.RemoveByTagAsync(CachePrefix);

            var response = new RoleDetailResponse(role.Id, role.Name, role.IsDeleted, request.Permissions);

            return Result.Success(response);
        }

        var error = result.Errors.First();

        return Result.Failure<RoleDetailResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> UpdateAsync(string id, RoleRequest request)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure(RoleErrors.RoleNotFound);

        var roleIsExists = await _roleManager.Roles
            .AnyAsync(x => x.Name == request.Name && x.Id != id);

        if (roleIsExists)
            return Result.Failure(RoleErrors.DuplicatedRole);

        var allowedPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure(RoleErrors.InvalidPermissions);

        role.Name = request.Name;

        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            var currentPermissions = await _context.RoleClaims
                .Where(x => x.RoleId == id && x.ClaimType == Permissions.Type)
                .Select(x => x.ClaimValue)
                .ToListAsync();

            var newPermissions = request.Permissions
                .Except(currentPermissions)
                .Select(x => new IdentityRoleClaim<string>
                {
                    ClaimType = Permissions.Type,
                    ClaimValue = x,
                    RoleId = role.Id
                });

            var removedPermissions = currentPermissions
                .Except(request.Permissions);

            await _context.RoleClaims
                .Where(x =>
                    x.RoleId == id &&
                    removedPermissions.Contains(x.ClaimValue))
                .ExecuteDeleteAsync();

            await _context.AddRangeAsync(newPermissions);

            await _context.SaveChangesAsync();
            await _hybridCache.RemoveByTagAsync(CachePrefix);

            return Result.Success();
        }

        var error = result.Errors.First();

        return Result.Failure(
            new Error(
                error.Code,
                error.Description,
                StatusCodes.Status400BadRequest));
    }

    public async Task<Result> ToggleStatusAsync(string id)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);

        role.IsDeleted = !role.IsDeleted;

        await _roleManager.UpdateAsync(role);
        await _hybridCache.RemoveByTagAsync(CachePrefix);

        return Result.Success();
    }
}