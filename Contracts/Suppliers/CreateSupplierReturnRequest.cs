using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Suppliers;

public record CreateSupplierReturnItemRequest(
    string  ProductId,
    string  BatchId,
    int     Quantity,
    decimal ReturnPrice
);

public record CreateSupplierReturnRequest(
    string                                         SupplierId,
    ReturnReasonDto                                Reason,
    string?                                        Notes,
    IReadOnlyList<CreateSupplierReturnItemRequest> Items
)
{
    public bool IsCashRefund { get; init; }
    public PaymentSource? PaymentSource { get; init; }
}

