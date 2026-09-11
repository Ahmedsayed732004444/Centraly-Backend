namespace Centraly.Api.Services;

public interface IAuthService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<Result<LoginResponse>> GetRefreshTokenAsync(
       string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result> RevokeRefreshTokenAsync(
        string token, string refreshToken, CancellationToken cancellationToken = default);
}