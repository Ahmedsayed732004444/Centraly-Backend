using Centraly.Api.Contracts.Finance;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Services.Abstraction;

public interface ISafeService
{
    Task<Result<SafeResponse>> CreateSafeAsync(CreateSafeRequest request, string? userId, CancellationToken ct = default);
    Task<Result<IEnumerable<SafeResponse>>> GetSafesAsync(CancellationToken ct = default);
    Task<Result<SafeResponse>> GetMainSafeAsync(CancellationToken ct = default);
    Task<Result<SafeTransactionResponse>> DepositFromDrawerAsync(string safeId, ReceiveDrawerDepositRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SafeTransactionResponse>> AddManualTransactionAsync(string safeId, DrawerTransactionType type, SafeTransactionCategory category, decimal amount, decimal profit, string? notes, string? userId, CancellationToken ct = default);
    Task<Result<PaginatedList<SafeTransactionResponse>>> GetSafeTransactionsAsync(string safeId, FinanceFilters filters, CancellationToken ct = default);
}


