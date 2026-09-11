using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Customers;

public record CustomerDebtPaymentResponse(
    string             PaymentId,
    CustomerSummary    Customer,
    decimal            Amount,
    DateTime           PaymentDate,
    string?            Notes
);
