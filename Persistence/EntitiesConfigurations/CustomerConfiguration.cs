using Centraly.Api.Entities.Customers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Name).HasMaxLength(150);
        builder.Property(c => c.Phone).HasMaxLength(20);
        builder.Property(c => c.DebtBalance).HasColumnType("decimal(18,2)");
    }
}
