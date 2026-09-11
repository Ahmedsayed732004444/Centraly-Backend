using Centraly.Api.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace Centraly.Api.Entities;

public class ApplicationRole : IdentityRole, ISoftDelete
{
    public ApplicationRole()
    {
        Id = Guid.CreateVersion7().ToString();
    }

    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
