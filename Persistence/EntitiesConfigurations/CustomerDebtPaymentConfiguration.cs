using Centraly.Api.Entities.Customers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class CustomerDebtPaymentConfiguration : IEntityTypeConfiguration<CustomerDebtPayment>
{
    public void Configure(EntityTypeBuilder<CustomerDebtPayment> builder)
    {
        builder.Property(c => c.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(c => c.Customer)
            .WithMany(c => c.DebtPayments)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.DrawerTransaction)
            .WithMany()
            .HasForeignKey(c => c.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(c => c.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
