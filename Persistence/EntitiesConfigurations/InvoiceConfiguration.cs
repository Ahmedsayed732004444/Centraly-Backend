using Centraly.Api.Entities.Sales;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(i => i.InvoiceNumber).HasMaxLength(50).IsRequired();
        builder.Property(i => i.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(i => i.PaidAmount).HasColumnType("decimal(18,2)");
        builder.Property(i => i.RecordedProfit).HasColumnType("decimal(18,2)");

        builder.HasIndex(i => i.InvoiceNumber)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        builder.HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.DrawerTransaction)
            .WithMany()
            .HasForeignKey(i => i.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(i => i.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Invoice_PaidAmount", "[PaidAmount] >= 0 AND [PaidAmount] <= [TotalAmount]"));
    }
}
