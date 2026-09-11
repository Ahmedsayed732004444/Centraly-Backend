using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class PurchaseInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
{
    public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
    {
        builder.Property(pi => pi.InvoiceNumber).HasMaxLength(50).IsRequired();
        builder.Property(pi => pi.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(pi => pi.PaidAmount).HasColumnType("decimal(18,2)");

        builder.HasIndex(pi => pi.InvoiceNumber)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        builder.HasOne(pi => pi.Supplier)
            .WithMany(s => s.PurchaseInvoices)
            .HasForeignKey(pi => pi.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pi => pi.DrawerTransaction)
            .WithMany()
            .HasForeignKey(pi => pi.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(pi => pi.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_PurchaseInvoice_PaidAmount", "[PaidAmount] >= 0 AND [PaidAmount] <= [TotalAmount]"));
    }
}
