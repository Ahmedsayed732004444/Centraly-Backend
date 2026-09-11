using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record PurchaseInvoiceResponse(
    string                                 PurchaseInvoiceId,
    string                                 InvoiceNumber,
    SupplierSummary                        Supplier,
    decimal                                TotalAmount,
    decimal                                PaidAmount,
    decimal                                RemainingAmount,
    DateTime                               InvoiceDate,
    string?                                Notes,
    IReadOnlyList<PurchaseInvoiceItemResponse> Items
);
