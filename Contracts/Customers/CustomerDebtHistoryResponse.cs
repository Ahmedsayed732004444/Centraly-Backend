namespace Centraly.Api.Contracts.Customers;

public record CustomerDebtHistoryResponse(
    CustomerResponse Customer,
    IReadOnlyList<CustomerInvoiceSummary> DeferredInvoices,
    IReadOnlyList<CustomerDebtPaymentResponse> Payments
);