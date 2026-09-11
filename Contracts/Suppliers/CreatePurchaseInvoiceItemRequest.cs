namespace Centraly.Api.Contracts.Suppliers;

public record CreatePurchaseInvoiceItemRequest(
    string ProductId,
    int Quantity,
    decimal UnitCost, // Purchase Price
    decimal WholesalePrice, // New Batch Wholesale Price
    decimal RetailPrice,     // New Batch Retail Price
    decimal? MaintenancePrice = null // Maintenance Price
);
