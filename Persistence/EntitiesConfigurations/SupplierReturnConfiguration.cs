using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierReturnConfiguration : IEntityTypeConfiguration<SupplierReturn>
{
    public void Configure(EntityTypeBuilder<SupplierReturn> builder)
    {
        builder.Property(sr => sr.TotalReturnedAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(sr => sr.Supplier)
            .WithMany(s => s.Returns)
            .HasForeignKey(sr => sr.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sr => sr.DrawerTransaction)
            .WithMany()
            .HasForeignKey(sr => sr.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(sr => sr.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
