using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Finance;

namespace Centraly.Api.Services.Abstraction;

public interface IOwnerTransactionService
{
    Task<Result<OwnerTransactionResponse>> CreateOwnerTransactionAsync(CreateOwnerTransactionRequest request, string userId, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<OwnerTransactionResponse>>> GetOwnerTransactionsAsync(CancellationToken cancellationToken = default);
}
