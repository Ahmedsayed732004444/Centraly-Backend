namespace Centraly.Api.Contracts.Suppliers;

public record UpdateSupplierRequest(
    string  Name,
    string? Type,
    string? Phone,
    string? Address
);
