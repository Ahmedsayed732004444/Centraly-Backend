namespace Centraly.Api.Services.Implementation;

public partial class WalletService
{
    public async Task<Result<WalletResponse>> UpdateWalletAsync(string walletId, UpdateWalletRequest request, string userId, CancellationToken ct = default)
    {
        var wallet = await dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == walletId, ct);
        if (wallet == null)
            return Result.Failure<WalletResponse>(WalletErrors.NotFound);
        if (request.Image is not null)
        {
            if (!string.IsNullOrEmpty(wallet.ImageUrl))
            {
                FileHelper.DeleteFile(wallet.ImageUrl, "uploads/wallets", _env);
            }
            wallet.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/wallets", _env, _accessor);
        }
        wallet.Name = request.Name;
        wallet.PhoneNumber = request.PhoneNumber;
        wallet.OwnerName = request.OwnerName;
        wallet.IsActive = request.IsActive;
        if (request.AllowedOperations is { Count: > 0 })
        {
            wallet.AllowedOperations = request.AllowedOperations.Distinct().ToList();
        }

        await dbContext.SaveChangesAsync(ct);
        return Result.Success(new WalletResponse(wallet.Id, wallet.Name, wallet.PhoneNumber, wallet.OwnerName, wallet.Balance, wallet.ImageUrl, wallet.IsActive, wallet.AllowedOperations, wallet.CreatedAt));
    }

    public async Task<Result<PaginatedList<WalletResponse>>> GetAllWalletsAsync(PaginationFilter filter, CancellationToken ct = default)
    {
        var query = dbContext.Wallets.AsQueryable();
        var total = await query.CountAsync(ct);
        var items = await query.OrderByDescending(w => w.CreatedAt)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(w => new WalletResponse(w.Id, w.Name, w.PhoneNumber, w.OwnerName, w.Balance, w.ImageUrl, w.IsActive, w.AllowedOperations, w.CreatedAt))
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<WalletResponse>(items, filter.PageNumber, filter.PageSize, total));
    }

    public async Task<Result<WalletDetailsResponse>> GetWalletByIdAsync(string walletId, CancellationToken ct = default)
    {
        var w = await dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == walletId, ct);
        if (w == null) return Result.Failure<WalletDetailsResponse>(WalletErrors.NotFound);

        var netProfit = await dbContext.WalletOperations.Where(o => o.WalletId == walletId).SumAsync(o => o.Profit, ct);

        var res = new WalletDetailsResponse(w.Id, w.Name, w.PhoneNumber, w.OwnerName, w.Balance, w.ImageUrl, w.IsActive, w.AllowedOperations, w.CreatedAt, netProfit);
        return Result.Success(res);
    }

    public async Task<Result<PaginatedList<WalletOperationResponse>>> GetWalletOperationsAsync(WalletOperationFilter filter, CancellationToken ct = default)
    {
        var query = dbContext.WalletOperations.Where(o => o.WalletId == filter.WalletId);
        var total = await query.CountAsync(ct);
        var items = await query.OrderByDescending(o => o.CreatedAt)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(o => new WalletOperationResponse(o.Id, o.WalletId, o.OperationType, o.TransferredAmount, o.PhysicalCashAmount, o.Profit, o.DrawerTransactionId, o.CreatedAt))
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<WalletOperationResponse>(items, filter.PageNumber, filter.PageSize, total));
    }

    public async Task<Result<WalletOperationsSummaryResponse>> GetWalletOperationsSummaryAsync(WalletOperationFilter filter, CancellationToken ct = default)
    {
        var query = dbContext.WalletOperations.Where(o => o.WalletId == filter.WalletId);
        var totalProfit = await query.SumAsync(o => o.Profit, ct);
        return Result.Success(new WalletOperationsSummaryResponse(totalProfit));
    }
}
