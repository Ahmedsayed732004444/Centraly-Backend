using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierPaymentConfiguration : IEntityTypeConfiguration<SupplierPayment>
{
    public void Configure(EntityTypeBuilder<SupplierPayment> builder)
    {
        builder.Property(sp => sp.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(sp => sp.Supplier)
            .WithMany(s => s.Payments)
            .HasForeignKey(sp => sp.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sp => sp.DrawerTransaction)
            .WithMany()
            .HasForeignKey(sp => sp.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(sp => sp.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
