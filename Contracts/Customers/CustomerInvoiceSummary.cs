namespace Centraly.Api.Contracts.Customers;

public record CustomerInvoiceSummary(
    string InvoiceId,
    string InvoiceNumber,
    decimal TotalAmount,
    decimal PaidAmount,
    decimal RemainingAmount,
    DateTime CreatedAt
);