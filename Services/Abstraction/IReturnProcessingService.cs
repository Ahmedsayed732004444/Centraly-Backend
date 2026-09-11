using Centraly.Api.Contracts.Returns;

namespace Centraly.Api.Services.Abstraction;

public interface IReturnProcessingService
{
    Task<Result<ReturnRecordResponse>> ProcessReturnAsync(
        CreateCustomerReturnRequest request, string? userId, string? expectedCustomerId, CancellationToken ct = default);
}