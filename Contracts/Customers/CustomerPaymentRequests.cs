namespace Centraly.Api.Contracts.Customers;

public record CreateCustomerPaymentRequest(
    decimal Amount,
    string? Notes,
    string? InvoiceId = null,
    Centraly.Api.Contracts.Shared.Enums.PaymentSource? PaymentSource = null
);

public record CustomerPaymentResponse(
    string Id,
    string CustomerId,
    decimal Amount,
    DateTime PaymentDate,
    string? Notes
);

