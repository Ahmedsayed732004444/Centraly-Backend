namespace Centraly.Api.Contracts.Inventory.Products;

public record ProductSupplierResponse(
    string   SupplierId,
    string   SupplierName,
    decimal  LastPurchasePrice,
    DateTime LastPurchaseDate,
    int      TotalQuantityPurchased
);