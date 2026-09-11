namespace Centraly.Api.Contracts.Suppliers;

public record SupplierBatchResponse(
    string  BatchId,
    string  ProductId,
    string? ProductName,
    string? Barcode,
    int     AvailableQuantity,
    decimal PurchasePrice,
    DateTime DateReceived
);
