namespace Centraly.Api.Contracts.Sales;

public record CreateInvoiceItemRequest(
    string ProductId,
    int    Quantity
);
