using Centraly.Api.Contracts.Shared.Enums;
using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record SupplierReturnItemResponse(
    string          SupplierReturnItemId,
    ProductSummary  Product,
    int             Quantity,
    decimal         UnitCost,
    decimal         LineTotal
);

public record SupplierReturnResponse(
    string                                    SupplierReturnId,
    SupplierSummary                           Supplier,
    ReturnReasonDto                           Reason,
    string?                                   Notes,
    decimal                                   TotalReturnedAmount,
    DateTime                                  ReturnDate,
    IReadOnlyList<SupplierReturnItemResponse> Items,
    int                                       ItemsCount
);