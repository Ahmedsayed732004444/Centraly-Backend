using Centraly.Api.Entities.Maintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class MaintenanceDeviceConfiguration : IEntityTypeConfiguration<MaintenanceDevice>
{
    public void Configure(EntityTypeBuilder<MaintenanceDevice> builder)
    {
        builder.Property(m => m.ServicePrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.TotalPartsPrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.TotalCost).HasColumnType("decimal(18,2)");
        builder.Property(m => m.TotalPrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.PaidAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(m => m.Customer)
            .WithMany(c => c.MaintenanceDevices)
            .HasForeignKey(m => m.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.DrawerTransaction)
            .WithMany()
            .HasForeignKey(m => m.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_MaintenanceDevice_PaidAmount", "[PaidAmount] >= 0"));
    }
}
