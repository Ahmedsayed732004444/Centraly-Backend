namespace Centraly.Api.Contracts.Shared.Summaries;

public record ProductSummary(
    string  ProductId,
    string? Name,
    string? Barcode,
    string? ImageUrl,
    decimal RetailPrice,
    decimal? WholesalePrice,
    int     Quantity
);
