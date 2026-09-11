using Centraly.Api.Entities.Returns;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class ReturnRecordConfiguration : IEntityTypeConfiguration<ReturnRecord>
{
    public void Configure(EntityTypeBuilder<ReturnRecord> builder)
    {
        builder.Property(r => r.TotalReturnedAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(r => r.Invoice)
            .WithMany(i => i.Returns)
            .HasForeignKey(r => r.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.DrawerTransaction)
            .WithMany()
            .HasForeignKey(r => r.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => r.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
