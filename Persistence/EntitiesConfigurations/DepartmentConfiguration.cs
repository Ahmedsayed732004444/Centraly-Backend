using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Name).HasMaxLength(150).IsRequired();
    }
}
