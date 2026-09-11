using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record SupplierPaymentResponse(
    string          SupplierPaymentId,
    SupplierSummary Supplier,
    decimal         Amount,
    DateTime        PaymentDate,
    string?         Notes
);