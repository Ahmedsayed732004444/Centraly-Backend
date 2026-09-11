using Centraly.Api.Entities.Returns;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class ReturnItemConfiguration : IEntityTypeConfiguration<ReturnItem>
{
    public void Configure(EntityTypeBuilder<ReturnItem> builder)
    {
        builder.Property(ri => ri.UnitPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(ri => ri.ReturnRecord)
            .WithMany(r => r.Items)
            .HasForeignKey(ri => ri.ReturnRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ri => ri.Product)
            .WithMany(p => p.ReturnItems)
            .HasForeignKey(ri => ri.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
