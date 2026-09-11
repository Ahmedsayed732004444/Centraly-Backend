using Centraly.Api.Entities.Sales;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.Property(ii => ii.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(ii => ii.UnitCost).HasColumnType("decimal(18,2)");

        builder.HasOne(ii => ii.Invoice)
            .WithMany(i => i.Items)
            .HasForeignKey(ii => ii.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ii => ii.Product)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(ii => ii.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_InvoiceItem_Quantity", "[Quantity] > 0"));
    }
}
