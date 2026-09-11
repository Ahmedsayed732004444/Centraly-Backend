namespace Centraly.Api.Contracts.Users;

public record CreateUserRequest(
    string Username,
    string Password,
    IList<string> Roles
);