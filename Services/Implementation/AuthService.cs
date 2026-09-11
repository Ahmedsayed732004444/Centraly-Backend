using System.Security.Cryptography;

namespace Centraly.Api.Services;

public class AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider,
    SignInManager<ApplicationUser> signInManager, ILogger<AuthService> logger, ApplicationDbContext context) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly ILogger<AuthService> _logger = logger;
    private readonly ApplicationDbContext _context = context;
    private readonly int _refreshTokenExpiryDays = 14;
    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {

        try
        {
            ApplicationUser? user = null;


            // If not found by email or doesn't contain @, try username
            if (user is null)
            {
                user = await _context.Users
                   .Include(u => u.RefreshTokens)
                   .FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);
            }
            if (user is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);


            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);

            if (result.Succeeded)
            {
                var (userRoles, userPermissions) =
                    await GetUserRolesAndPermissions(user, cancellationToken);

                var (token, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, userPermissions);
                var refreshToken = GenerateRefreshToken();
                var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

                user.RefreshTokens.Add(new RefreshToken
                {
                    Token = refreshToken,
                    ExpiresOn = refreshTokenExpiration
                });

                await _userManager.UpdateAsync(user);

                var response = new LoginResponse(
                    user.Id, user.UserName ?? string.Empty,
                    token, expiresIn, refreshToken, refreshTokenExpiration, userRoles, userPermissions);

                return Result.Success(response);
            }

            var error = result.IsNotAllowed ? UserErrors.EmailNotConfirmed
                      : result.IsLockedOut ? UserErrors.LockedUser
                                             : UserErrors.InvalidCredentials;

            return Result.Failure<LoginResponse>(error);
        }
        catch (Exception ex)
        {
            // _logger.LogError(ex, "Error occurred while generating token for user {username}", user.UserName);
            return Result.Failure<LoginResponse>(UserErrors.UnexpectedError);
        }
    }

    private async Task<(IEnumerable<string> roles, IEnumerable<string> permissions)>
        GetUserRolesAndPermissions(ApplicationUser user, CancellationToken cancellationToken)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        var userPermissions = await (
            from r in _context.Roles
            join p in _context.RoleClaims on r.Id equals p.RoleId
            where userRoles.Contains(r.Name!)
            select p.ClaimValue!)
            .Distinct()
            .ToListAsync(cancellationToken);

        return (userRoles, userPermissions);
    }
    private static string GenerateRefreshToken()
    => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    public async Task<Result<LoginResponse>> GetRefreshTokenAsync(
       string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        try
        {
            var userId = _jwtProvider.ValidateToken(token, validateLifetime: false);

            if (userId is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidJwtToken);

            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidJwtToken);

            var userRefreshToken = user.RefreshTokens
                .SingleOrDefault(x => x.Token == refreshToken && x.IsActive);

            if (userRefreshToken is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidRefreshToken);

            userRefreshToken.RevokedOn = DateTime.UtcNow;

            var (userRoles, userPermissions) =
                await GetUserRolesAndPermissions(user, cancellationToken);

            var (newToken, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, userPermissions);
            var newRefreshToken = GenerateRefreshToken();
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = newRefreshToken,
                ExpiresOn = refreshTokenExpiration
            });

            await _userManager.UpdateAsync(user);

            var response = new LoginResponse(
                user.Id, user.UserName ?? string.Empty,
                newToken, expiresIn, newRefreshToken, refreshTokenExpiration, userRoles, userPermissions);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while refreshing token");
            return Result.Failure<LoginResponse>(UserErrors.UnexpectedError);
        }
    }

    public async Task<Result> RevokeRefreshTokenAsync(
        string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        try
        {
            var userId = _jwtProvider.ValidateToken(token, validateLifetime: false);

            if (userId is null)
                return Result.Failure(UserErrors.InvalidJwtToken);

            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user is null)
                return Result.Failure(UserErrors.InvalidJwtToken);

            var userRefreshToken = user.RefreshTokens
                .SingleOrDefault(x => x.Token == refreshToken && x.IsActive);

            if (userRefreshToken is null)
                return Result.Failure(UserErrors.InvalidRefreshToken);

            userRefreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while revoking refresh token");
            return Result.Failure(UserErrors.UnexpectedError);
        }
    }

}