namespace Centraly.Api.Contracts.Roles;

public record RoleResponse(
    string Id,
    string Name,
    bool IsDeleted
);