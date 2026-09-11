using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record PurchaseInvoiceItemResponse(
    string          PurchaseInvoiceItemId,
    ProductSummary  Product,
    int             Quantity,
    decimal         UnitCost,
    decimal         LineTotal
);
