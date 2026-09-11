namespace Centraly.Api.Contracts.Users;

public record UserResponse(
    string Id,
    string Username,
    IEnumerable<string> Roles
);