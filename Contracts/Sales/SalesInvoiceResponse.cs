using Centraly.Api.Contracts.Customers;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Sales;

public record SalesInvoiceItemResponse(
    string Id,
    string ProductId,
    string ProductName,
    string BatchId,
    int Quantity,
    int ReturnedQuantity,
    decimal UnitPrice,
    decimal UnitCost,
    decimal LineTotal
);

public record SalesInvoiceResponse(
    string Id,
    string InvoiceNumber,
    CustomerSummary? Customer,
    SaleTypeDto SaleType,
    PaymentMethodDto PaymentMethod,
    decimal TotalAmount,
    decimal PaidAmount,
    decimal RemainingAmount,
    string? Notes,
    DateTime CreatedAt,
    bool HasReturns,
    IReadOnlyList<SalesInvoiceItemResponse> Items
);
