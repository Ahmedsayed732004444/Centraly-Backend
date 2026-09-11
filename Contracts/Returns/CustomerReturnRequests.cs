using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Returns;

public record ReturnItemRequest(
    string ProductId,
    string BatchId,
    int Quantity,
    decimal UnitPrice
);

public record CreateCustomerReturnRequest(
    string InvoiceId,
    ReturnReasonDto Reason,
    string? Notes,
    bool IsCashRefund,
    IReadOnlyList<ReturnItemRequest> Items,
    PaymentSource? PaymentSource = null
);

public record ReturnItemResponse(
    string Id,
    string ProductId,
    string BatchId,
    int Quantity,
    decimal UnitPrice
);

public record ReturnRecordResponse(
    string Id,
    string InvoiceId,
    string InvoiceNumber,
    bool IsFullInvoiceReturn,
    ReturnReasonDto Reason,
    string? Notes,
    bool IsCashRefund,
    decimal TotalReturnedAmount,
    DateTime ReturnDate,
    IReadOnlyList<ReturnItemResponse> Items
);

