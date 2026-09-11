using Centraly.Api.Contracts.Users;

namespace Centraly.Api.Services;

public class UserService(UserManager<ApplicationUser> userManager,
    IRoleService roleService,
    ApplicationDbContext context) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IRoleService _roleService = roleService;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await (from u in _context.Users
               join ur in _context.UserRoles
               on u.Id equals ur.UserId
               join r in _context.Roles
               on ur.RoleId equals r.Id into roles
               where !roles.Any(x => x.Name == "")
               select new
               {
                   u.Id,
                   u.UserName,
                   Roles = roles.Select(x => x.Name!).ToList()
               }
                )
                .GroupBy(u => new { u.Id, u.UserName })
                .Select(u => new UserResponse
                (
                    u.Key.Id,
                    u.Key.UserName!,
                    u.SelectMany(x => x.Roles)
                ))
               .ToListAsync(cancellationToken);

    public async Task<Result<UserResponse>> GetAsync(string id)
    {
        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure<UserResponse>(UserErrors.UserNotFound);

        var userRoles = await _userManager.GetRolesAsync(user);

        var response = new UserResponse(user.Id, user.UserName!, userRoles);

        return Result.Success(response);
    }

    public async Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var usernameIsExists = await _userManager.Users.AnyAsync(x => x.UserName == request.Username, cancellationToken);

        if (usernameIsExists)
            return Result.Failure<UserResponse>(UserErrors.DuplicateEmail);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any())
            return Result.Failure<UserResponse>(UserErrors.InvalidRoles);

        var cleanUsername = request.Username.Trim().ToLower().Replace(" ", "_");
        var user = new ApplicationUser
        {
            UserName = request.Username.Trim(),
            Email = $"{cleanUsername}@centraly.local",
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, request.Roles);

            var response = new UserResponse(user.Id, user.UserName!, request.Roles);

            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success(response);
        }

        var error = result.Errors.First();

        return Result.Failure<UserResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        var usernameIsExists = await _userManager.Users.AnyAsync(x => x.UserName == request.Username && x.Id != id, cancellationToken);

        if (usernameIsExists)
            return Result.Failure(UserErrors.DuplicateEmail);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any())
            return Result.Failure(UserErrors.InvalidRoles);

        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure(UserErrors.UserNotFound);

        var cleanUsername = request.Username.Trim().ToLower().Replace(" ", "_");
        user.UserName = request.Username.Trim();
        user.Email = $"{cleanUsername}@centraly.local";

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            await _context.UserRoles
                .Where(x => x.UserId == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _userManager.AddToRolesAsync(user, request.Roles);

            return Result.Success();
        }

        var error = result.Errors.First();

        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
}