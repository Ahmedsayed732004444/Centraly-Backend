namespace Centraly.Api.Contracts.Suppliers;

public record SupplierResponse(
    string   SupplierId,
    string   Name,
    string?  Type,
    string?  Phone,
    string?  Address,
    decimal  DebtBalance,
    int      PurchaseInvoicesCount,
    int      ReturnsCount,
    DateTime CreatedAt
);