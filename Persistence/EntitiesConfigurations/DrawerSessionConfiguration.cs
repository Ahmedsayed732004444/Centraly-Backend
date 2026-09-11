using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class DrawerSessionConfiguration : IEntityTypeConfiguration<DrawerSession>
{
    public void Configure(EntityTypeBuilder<DrawerSession> builder)
    {
        builder.Property(d => d.OpeningBalance).HasColumnType("decimal(18,2)");
        builder.Property(d => d.TotalIncome).HasColumnType("decimal(18,2)");
        builder.Property(d => d.TotalExpense).HasColumnType("decimal(18,2)");
        builder.Property(d => d.ClosingBalance).HasColumnType("decimal(18,2)");
        builder.Property(d => d.RunningBalance).HasColumnType("decimal(18,2)");
        builder.Property(d => d.TotalProfit).HasColumnType("decimal(18,2)");
    }
}
