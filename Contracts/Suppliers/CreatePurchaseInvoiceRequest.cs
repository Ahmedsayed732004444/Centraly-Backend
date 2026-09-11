using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Suppliers;

public record CreatePurchaseInvoiceRequest(
    string SupplierId,
    decimal PaidAmount,
    string? Notes,
    List<CreatePurchaseInvoiceItemRequest> Items,
    PaymentSource? PaymentSource = null
);