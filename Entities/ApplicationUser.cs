namespace Centraly.Api.Entities;

public sealed class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {

        Id = Guid.CreateVersion7().ToString();
        SecurityStamp = Guid.CreateVersion7().ToString();
    }
    public List<RefreshToken> RefreshTokens { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
