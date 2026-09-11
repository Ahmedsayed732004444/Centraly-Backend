using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Suppliers;

public record CreateSupplierPaymentRequest(
    string  SupplierId,
    decimal Amount,
    string? Notes,
    PaymentSource? PaymentSource = null
);