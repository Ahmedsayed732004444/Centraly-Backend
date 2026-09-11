using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Returns;
using Centraly.Api.Contracts.Shared;

namespace Centraly.Api.Services.Abstraction;

public interface ISalesReturnService
{
    Task<Result<ReturnRecordResponse>> AddReturnAsync(CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default);
    Task<Result<ReturnRecordResponse>> GetReturnAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<ReturnRecordResponse>>> GetAllReturnsAsync(RequestFilters filters, CancellationToken ct = default);
}
