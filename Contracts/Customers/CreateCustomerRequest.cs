namespace Centraly.Api.Contracts.Customers;

public record CreateCustomerRequest(
    string? Name,
    string? Phone
);
