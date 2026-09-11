namespace Centraly.Api.Contracts.Suppliers;

public record CreateSupplierRequest(
    string  Name,
    string? Type,
    string? Phone,
    string? Address
);
