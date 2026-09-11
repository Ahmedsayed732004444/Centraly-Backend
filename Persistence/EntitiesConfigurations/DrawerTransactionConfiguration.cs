using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class DrawerTransactionConfiguration : IEntityTypeConfiguration<DrawerTransaction>
{
    public void Configure(EntityTypeBuilder<DrawerTransaction> builder)
    {
        builder.Property(d => d.Amount).HasColumnType("decimal(18,2)");
        builder.Property(d => d.Balance).HasColumnType("decimal(18,2)");
        builder.Property(d => d.Profit).HasColumnType("decimal(18,2)");

        builder.HasOne(d => d.DrawerSession)
            .WithMany(s => s.Transactions)
            .HasForeignKey(d => d.DrawerSessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_DrawerTransaction_Amount", "[Amount] >= 0"));
    }
}
