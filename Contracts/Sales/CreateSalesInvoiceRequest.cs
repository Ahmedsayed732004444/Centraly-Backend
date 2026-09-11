using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Sales;

public record CreateSalesInvoiceItemRequest(
    string ProductId,
    string BatchId,
    int Quantity,
    decimal SellingPrice
);

public record CreateSalesInvoiceRequest(
    string? CustomerId,
    string? CustomerName,
    string? CustomerPhone,
    SaleTypeDto SaleType,
    PaymentMethodDto PaymentMethod,
    decimal PaidAmount,
    string? Notes,
    IReadOnlyList<CreateSalesInvoiceItemRequest> Items,
    PaymentSource? PaymentSource = null
);
