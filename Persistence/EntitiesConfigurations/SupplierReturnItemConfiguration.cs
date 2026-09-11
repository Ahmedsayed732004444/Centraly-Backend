using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierReturnItemConfiguration : IEntityTypeConfiguration<SupplierReturnItem>
{
    public void Configure(EntityTypeBuilder<SupplierReturnItem> builder)
    {
        builder.Property(sri => sri.UnitCost).HasColumnType("decimal(18,2)");

        builder.HasOne(sri => sri.SupplierReturn)
            .WithMany(sr => sr.Items)
            .HasForeignKey(sri => sri.SupplierReturnId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sri => sri.Product)
            .WithMany(p => p.SupplierReturnItems)
            .HasForeignKey(sri => sri.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
