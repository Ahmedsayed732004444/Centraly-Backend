namespace Centraly.Api.Contracts.Shared.Summaries;

public record SupplierSummary(
    string  SupplierId,
    string  Name,
    string? Phone
);
