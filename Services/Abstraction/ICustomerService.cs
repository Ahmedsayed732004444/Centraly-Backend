using Centraly.Api.Contracts.Customers;

namespace Centraly.Api.Services.Abstraction;

public interface ICustomerService
{
    Task<Result<CustomerResponse>> AddCustomerAsync(
        CreateCustomerRequest request, string? userId, CancellationToken ct = default);

    Task<Result<CustomerResponse>> GetCustomerAsync(
        string id, CancellationToken ct = default);

    Task<Result<PaginatedList<CustomerResponse>>> GetAllCustomersAsync(
        RequestFilters filters, CancellationToken ct = default);

    Task<Result<CustomerDebtHistoryResponse>> GetCustomerWithDebtHistoryAsync(
        string id, CancellationToken ct = default);

    Task<Result<CustomerResponse>> UpdateCustomerAsync(
        string id, UpdateCustomerRequest request, string? userId, CancellationToken ct = default);

    Task<Result<bool>> DeleteCustomerAsync(
        string id, CancellationToken ct = default);
}