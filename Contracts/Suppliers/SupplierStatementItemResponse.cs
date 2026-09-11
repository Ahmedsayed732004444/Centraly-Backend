namespace Centraly.Api.Contracts.Suppliers;

public record SupplierStatementItemResponse(
    DateTime Date,
    string TransactionType,
    string TransactionId,
    decimal Debit,
    decimal Credit,
    decimal BalanceAfter,
    string? Notes
);
