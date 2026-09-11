namespace Centraly.Api.Contracts.Customers;

public record CustomerStatementResponse(
    DateTime Date,
    string TransactionType, // "Invoice", "Payment", "Return"
    string TransactionId,
    decimal Debit,
    decimal Credit,
    decimal BalanceAfter,
    string? Notes
);
