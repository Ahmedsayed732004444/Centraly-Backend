using Centraly.Api.Contracts.Inventory.Categories;
using Centraly.Api.Contracts.Inventory.Departments;
using Centraly.Api.Contracts.Inventory.Products;
using Centraly.Api.Entities.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class ProductMapping
{
    public sealed record PropertyPair(string Name, string Value);

    public sealed record ProductProjection(
        string ProductId,
        string? Barcode,
        string? Name,
        string DepartmentId,
        string DepartmentName,
        string CategoryId,
        string CategoryName,
        int Quantity,
        string? ImageUrl,
        int MinQuantityAlert,
        string? StorageLocation,
        DateTime CreatedAt,
        Centraly.Api.Contracts.Shared.Enums.ProductUsageDto Usage,
        List<PropertyPair> Properties,
        List<ProductBatchResponse> Batches);

    public static IQueryable<ProductProjection> ProjectToIntermediate(this IQueryable<Product> query)
    {
        return query
            .Where(p => !p.IsDeleted)
            .AsNoTracking()
            .Select(p => new ProductProjection(
                p.Id,
                p.Barcode,
                p.Name,
                p.DepartmentId,
                p.Department != null ? p.Department.Name : "بدون قسم",
                p.CategoryId,
                p.Category != null ? p.Category.Name : "بدون تصنيف",
                p.Quantity,
                p.ImageUrl,
                p.MinQuantityAlert,
                p.StorageLocation,
                p.CreatedAt,
                (Centraly.Api.Contracts.Shared.Enums.ProductUsageDto)p.Usage,
                p.Properties.Select(prop => new PropertyPair(prop.Name, prop.Value)).ToList(),
                p.Batches
                    .Where(b => b.AvailableQuantity > 0 && !b.IsDeleted)
                    .Select(b => new ProductBatchResponse(
                        b.Id,
                        b.SupplierId,
                        b.Supplier != null ? b.Supplier.Name : null,
                        b.AvailableQuantity,
                        b.PurchasePrice,
                        b.WholesalePrice,
                        b.RetailPrice,
                        b.MaintenancePrice,
                        b.DateReceived))
                    .ToList()));
    }

    public static ProductResponse ToResponse(this ProductProjection p)
    {
        return new ProductResponse(
            p.ProductId,
            p.Barcode,
            p.Name,
            new DepartmentSummary(p.DepartmentId, p.DepartmentName),
            new CategorySummary(p.CategoryId, p.CategoryName),
            p.Quantity,
            p.ImageUrl,
            p.MinQuantityAlert,
            p.StorageLocation,
            p.Quantity <= 0,
            p.Quantity > 0 && p.Quantity <= p.MinQuantityAlert,
            p.CreatedAt,
            p.Usage,
            p.Properties.ToDictionary(x => x.Name, x => x.Value),
            p.Batches);
    }
}
