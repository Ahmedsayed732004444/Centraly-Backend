using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Customers;
using Centraly.Api.Contracts.Returns;

namespace Centraly.Api.Services.Abstraction;

public interface ICustomerTransactionService
{
    Task<Result<CustomerPaymentResponse>> AddPaymentAsync(string customerId, CreateCustomerPaymentRequest request, string? userId, CancellationToken ct = default);
    Task<Result<ReturnRecordResponse>> AddReturnAsync(string customerId, CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default);
    Task<Result<IEnumerable<CustomerStatementResponse>>> GetCustomerStatementAsync(string customerId, CancellationToken ct = default);
}
