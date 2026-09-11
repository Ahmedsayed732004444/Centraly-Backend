using Microsoft.AspNetCore.Authorization;

namespace Centraly.Api.Authorization;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(policy: permission)
    {
    }
}
