namespace Centraly.Api.Contracts.Roles;

public record RoleRequest(
    string Name,
    IList<string> Permissions
);