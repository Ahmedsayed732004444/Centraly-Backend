using Centraly.Api.Contracts.Wallets;

namespace Centraly.Api.Services.Abstraction;

public interface IWalletService
{
    Task<Result<WalletResponse>> CreateWalletAsync(CreateWalletRequest request, string userId, CancellationToken ct = default);
    Task<Result<WalletResponse>> UpdateWalletAsync(string walletId, UpdateWalletRequest request, string userId, CancellationToken ct = default);
    Task<Result<WalletOperationResponse>> ProcessOperationAsync(ProcessOperationRequest request, string userId, CancellationToken ct = default);
    Task<Result<PaginatedList<WalletResponse>>> GetAllWalletsAsync(PaginationFilter filter, CancellationToken ct = default);
    Task<Result<WalletDetailsResponse>> GetWalletByIdAsync(string walletId, CancellationToken ct = default);
    Task<Result<PaginatedList<WalletOperationResponse>>> GetWalletOperationsAsync(WalletOperationFilter filter, CancellationToken ct = default);
    Task<Result<WalletOperationsSummaryResponse>> GetWalletOperationsSummaryAsync(WalletOperationFilter filter, CancellationToken ct = default);
}