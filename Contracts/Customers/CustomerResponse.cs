namespace Centraly.Api.Contracts.Customers;

public record CustomerResponse(
    string   CustomerId,
    string?  Name,
    string?  Phone,
    decimal  DebtBalance,
    int      InvoicesCount,
    DateTime CreatedAt
);
