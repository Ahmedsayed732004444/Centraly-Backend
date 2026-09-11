using Centraly.Api.Entities.Maintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class MaintenanceProductItemConfiguration : IEntityTypeConfiguration<MaintenanceProductItem>
{
    public void Configure(EntityTypeBuilder<MaintenanceProductItem> builder)
    {
        builder.Property(m => m.MaintenancePrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.CostPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(m => m.MaintenanceDevice)
            .WithMany(md => md.ProductsUsed)
            .HasForeignKey(m => m.MaintenanceDeviceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Product)
            .WithMany()
            .HasForeignKey(m => m.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_MaintenanceProductItem_Quantity", "[Quantity] > 0"));
    }
}
