namespace Centraly.Api.Contracts.Authentication;

public record LoginResponse
(
    string Id,
    string UserName,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime RefreshTokenExpiration,
    IEnumerable<string> Role,
    IEnumerable<string> Permissions
);
