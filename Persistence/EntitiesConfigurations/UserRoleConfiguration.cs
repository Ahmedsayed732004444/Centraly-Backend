namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Admin.Id,
                RoleId = DefaultRoles.Admin.Id
            },
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Manager.Id,
                RoleId = DefaultRoles.Manager.Id
            },
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Salesperson.Id,
                RoleId = DefaultRoles.Salesperson.Id
            },
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Technician.Id,
                RoleId = DefaultRoles.Technician.Id
            }
        );
    }
}
