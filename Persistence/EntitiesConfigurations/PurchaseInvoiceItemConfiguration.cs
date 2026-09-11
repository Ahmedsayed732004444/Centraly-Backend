using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class PurchaseInvoiceItemConfiguration : IEntityTypeConfiguration<PurchaseInvoiceItem>
{
    public void Configure(EntityTypeBuilder<PurchaseInvoiceItem> builder)
    {
        builder.Property(pii => pii.UnitCost).HasColumnType("decimal(18,2)");

        builder.HasOne(pii => pii.PurchaseInvoice)
            .WithMany(pi => pi.Items)
            .HasForeignKey(pii => pii.PurchaseInvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pii => pii.Product)
            .WithMany(p => p.PurchaseInvoiceItems)
            .HasForeignKey(pii => pii.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_PurchaseInvoiceItem_Quantity", "[Quantity] > 0"));
    }
}
