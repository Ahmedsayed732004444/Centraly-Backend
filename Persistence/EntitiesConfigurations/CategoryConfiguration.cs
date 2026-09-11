using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name).HasMaxLength(150).IsRequired();

        builder.HasOne(c => c.Department)
            .WithMany(d => d.Categories)
            .HasForeignKey(c => c.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
