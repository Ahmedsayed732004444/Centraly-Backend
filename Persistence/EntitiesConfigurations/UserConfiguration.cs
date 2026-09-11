namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasMany(x => x.RefreshTokens)
           .WithOne()
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Cascade);
        builder.Navigation(x => x.RefreshTokens).AutoInclude(false);

        builder.HasData([new ApplicationUser
        {
            Id = DefaultUsers.Admin.Id,
            UserName = DefaultUsers.Admin.Email,
            NormalizedUserName = DefaultUsers.Admin.Email.ToUpper(),
            Email = DefaultUsers.Admin.Email,
            NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Admin.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Admin.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new ApplicationUser
        {
            Id = DefaultUsers.Manager.Id,
            UserName = DefaultUsers.Manager.Email,
            NormalizedUserName = DefaultUsers.Manager.Email.ToUpper(),
            Email = DefaultUsers.Manager.Email,
            NormalizedEmail = DefaultUsers.Manager.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Manager.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Manager.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Manager.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new ApplicationUser
        {
            Id = DefaultUsers.Salesperson.Id,
            UserName = DefaultUsers.Salesperson.Email,
            NormalizedUserName = DefaultUsers.Salesperson.Email.ToUpper(),
            Email = DefaultUsers.Salesperson.Email,
            NormalizedEmail = DefaultUsers.Salesperson.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Salesperson.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Salesperson.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Salesperson.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new ApplicationUser
        {
            Id = DefaultUsers.Technician.Id,
            UserName = DefaultUsers.Technician.Email,
            NormalizedUserName = DefaultUsers.Technician.Email.ToUpper(),
            Email = DefaultUsers.Technician.Email,
            NormalizedEmail = DefaultUsers.Technician.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Technician.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Technician.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Technician.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        }

        ]);
    }
}
