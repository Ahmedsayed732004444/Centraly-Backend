using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.Property(s => s.Name).HasMaxLength(150).IsRequired();
        builder.Property(s => s.Phone).HasMaxLength(20);
        builder.Property(s => s.DebtBalance).HasColumnType("decimal(18,2)");
    }
}
