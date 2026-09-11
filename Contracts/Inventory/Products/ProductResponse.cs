using Centraly.Api.Contracts.Shared.Summaries;
using Centraly.Api.Contracts.Shared.Enums;
namespace Centraly.Api.Contracts.Inventory.Products;

public record ProductBatchResponse(
    string BatchId,
    string? SupplierId,
    string? SupplierName,
    int AvailableQuantity,
    decimal PurchasePrice,
    decimal WholesalePrice,
    decimal RetailPrice,
    decimal MaintenancePrice,
    DateTime DateReceived
);

public record ProductResponse(
    string ProductId,
    string? Barcode,
    string? Name,
    DepartmentSummary Department,
    CategorySummary Category,
    int TotalQuantity,
    string? ImageUrl,
    int MinQuantityAlert,
    string? StorageLocation,
    bool IsOutOfStock,
    bool IsLowStock,
    DateTime CreatedAt,
    ProductUsageDto Usage,
    Dictionary<string, string> Properties,
    List<ProductBatchResponse> Batches
);
