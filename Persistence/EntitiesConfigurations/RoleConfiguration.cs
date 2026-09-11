namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        //Default Data
        builder.HasData([
            new ApplicationRole
            {
                Id = DefaultRoles.Admin.Id,
                Name = DefaultRoles.Admin.Name,
                NormalizedName = DefaultRoles.Admin.Name.ToUpper(),
                ConcurrencyStamp = DefaultRoles.Admin.ConcurrencyStamp
            }
        ,
        new ApplicationRole
        {
            Id = DefaultRoles.Manager.Id,
            Name = DefaultRoles.Manager.Name,
            NormalizedName = DefaultRoles.Manager.Name.ToUpper(),
            ConcurrencyStamp = DefaultRoles.Manager.ConcurrencyStamp
        }
        ,
        new ApplicationRole
        {
            Id = DefaultRoles.Salesperson.Id,
            Name = DefaultRoles.Salesperson.Name,
            NormalizedName = DefaultRoles.Salesperson.Name.ToUpper(),
            ConcurrencyStamp = DefaultRoles.Salesperson.ConcurrencyStamp
        }
        ,
        new ApplicationRole
        {
            Id = DefaultRoles.Technician.Id,
            Name = DefaultRoles.Technician.Name,
            NormalizedName = DefaultRoles.Technician.Name.ToUpper(),
            ConcurrencyStamp = DefaultRoles.Technician.ConcurrencyStamp
        }

        ]);
    }
}
