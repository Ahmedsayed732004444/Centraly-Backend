using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(200);

        // Fix: Barcode مش بينتهي بـ "Id" فمش بياخد الـ MaxLength convention العامة
        // في ApplicationDbContext تلقائيًا. لازم MaxLength صريح هنا لأنه داخل في
        // Unique Filtered Index تحت، وSQL Server مش بيسمح بعمود nvarchar(max)
        // يبقى جزء من Index.
        builder.Property(p => p.Barcode).HasMaxLength(64);


        // بديل عن Unique عادي - عشان الـ Soft Delete متعارضش معاه
        builder.HasIndex(p => p.Barcode)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0 AND [Barcode] IS NOT NULL");

        builder.HasOne(p => p.Department)
            .WithMany(d => d.Products)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_Product_Quantity", "[Quantity] >= 0"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Product_MinQuantityAlert", "[MinQuantityAlert] >= 0"));
    }
}
