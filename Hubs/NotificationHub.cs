using Microsoft.AspNetCore.SignalR;

namespace Centraly.Api.Hubs;

// Clients connect to /hubs/notifications with ?access_token=<jwt> (already wired in
// Dependencies.cs's JwtBearer OnMessageReceived for any path under /hubs). The default
// IUserIdProvider reads ClaimTypes.NameIdentifier, which is exactly what "sub" in the
// JWT maps to (see JwtProvider), so Clients.User(userId) works with no custom provider.
//
// Role-targeted broadcasts (e.g. "everyone who can act on low stock") use SignalR
// groups named "role:{RoleName}". Membership is resolved from the database on connect
// rather than from the JWT's "roles" claim, because that claim's type isn't guaranteed
// to survive ASP.NET Core's inbound claim-type mapping into something IsInRole() (or a
// hand-rolled equivalent) can reliably read - a DB lookup by the token's own
// NameIdentifier avoids that ambiguity entirely.
[Authorize]
public class NotificationHub(ApplicationDbContext dbContext) : Hub
{
    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            var roleNames = await dbContext.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(dbContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                .Where(name => name != null)
                .ToListAsync();

            foreach (var roleName in roleNames)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"role:{roleName}");
            }
        }

        await base.OnConnectedAsync();
    }
}
