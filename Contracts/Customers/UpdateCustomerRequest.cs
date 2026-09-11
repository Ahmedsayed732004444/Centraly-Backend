namespace Centraly.Api.Contracts.Customers;

public record UpdateCustomerRequest(
    string? Name,
    string? Phone
);
