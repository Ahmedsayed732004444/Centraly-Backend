namespace Centraly.Api.Contracts.Users;

public record UpdateUserRequest(
    string Username,
    IList<string> Roles
);