using Centraly.Api.Contracts.Finance;
using Centraly.Api.Contracts.Shared;
using Centraly.Api.Extensions;
namespace Centraly.Api.Services.Implementation;

public class SafeService(ApplicationDbContext dbContext) : ISafeService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Result<SafeResponse>> CreateSafeAsync(CreateSafeRequest request, string? userId, CancellationToken ct = default)
    {
        var safe = new Safe
        {
            Name = request.Name,
            Balance = request.InitialBalance,
            IsMain = request.IsMain,
            CreatedByUserId = userId
        };

        if (request.InitialBalance > 0)
        {
            safe.Transactions.Add(new SafeTransaction
            {
                TransactionType = DrawerTransactionType.Income,
                Category = SafeTransactionCategory.OwnerDeposit,
                Amount = request.InitialBalance,
                BalanceAfter = request.InitialBalance,
                Notes = "Initial Balance",
                CreatedByUserId = userId
            });
        }

        _dbContext.Safes.Add(safe);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new SafeResponse(safe.Id, safe.Name, safe.Balance, safe.IsMain));
    }

    public async Task<Result<IEnumerable<SafeResponse>>> GetSafesAsync(CancellationToken ct = default)
    {
        var safes = await _dbContext.Safes
            .Where(s => !s.IsDeleted)
            .ProjectToResponse()
            .ToListAsync(ct);

        return Result.Success<IEnumerable<SafeResponse>>(safes);
    }

    // Used by TransactionRouterService to find the main safe without pulling
    // every safe in the system over the wire just to filter client-side.
    public async Task<Result<SafeResponse>> GetMainSafeAsync(CancellationToken ct = default)
    {
        var safe = await _dbContext.Safes
            .Where(s => s.IsMain && !s.IsDeleted)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return safe is null
            ? Result.Failure<SafeResponse>(TransactionRouterErrors.NoMainSafe)
            : Result.Success(safe);
    }

    public async Task<Result<SafeTransactionResponse>> DepositFromDrawerAsync(
        string safeId, ReceiveDrawerDepositRequest request, string? userId, CancellationToken ct = default)
    {
        var safe = await _dbContext.Safes.FirstOrDefaultAsync(s => s.Id == safeId && !s.IsDeleted, ct);
        if (safe is null)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.SafeNotFound);

        var drawerSession = await _dbContext.DrawerSessions.FirstOrDefaultAsync(s => s.Id == request.DrawerSessionId, ct);
        if (drawerSession is null)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.DrawerNotFound);

        if (!drawerSession.IsClosed)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.DrawerNotClosed);
        // In a real system, we'd mark the DrawerSession as 'Deposited' to avoid double deposits.

        safe.Balance += request.Amount;
        safe.UpdatedAt = DateTime.UtcNow;
        safe.UpdatedByUserId = userId;

        var safeTx = new SafeTransaction
        {
            SafeId = safe.Id,
            TransactionType = DrawerTransactionType.Income,
            Category = SafeTransactionCategory.DrawerDeposit,
            Amount = request.Amount,
            BalanceAfter = safe.Balance,
            Notes = request.Notes ?? $"Deposit from Drawer Session: {request.DrawerSessionId}",
            CreatedByUserId = userId
        };

        _dbContext.SafeTransactions.Add(safeTx);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new SafeTransactionResponse(
            safeTx.Id, safeTx.SafeId, safeTx.TransactionType.ToString(), safeTx.Category.ToString(), safeTx.Amount, safeTx.BalanceAfter, safeTx.CreatedAt, safeTx.Notes));
    }

    public async Task<Result<SafeTransactionResponse>> AddManualTransactionAsync(
        string safeId, DrawerTransactionType type, SafeTransactionCategory category, decimal amount, decimal profit, string? notes, string? userId, CancellationToken ct = default)
    {
        var safe = await _dbContext.Safes.FirstOrDefaultAsync(s => s.Id == safeId && !s.IsDeleted, ct);
        if (safe is null)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.SafeNotFound);

        if (type == DrawerTransactionType.Expense && safe.Balance < amount)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.InsufficientFunds);

        safe.Balance += type == DrawerTransactionType.Income ? amount : -amount;
        safe.UpdatedAt = DateTime.UtcNow;
        safe.UpdatedByUserId = userId;

        var safeTx = new SafeTransaction
        {
            SafeId = safe.Id,
            TransactionType = type,
            Category = category,
            Amount = amount,
            Profit = profit,
            BalanceAfter = safe.Balance,
            Notes = notes,
            CreatedByUserId = userId
        };

        _dbContext.SafeTransactions.Add(safeTx);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new SafeTransactionResponse(
            safeTx.Id, safeTx.SafeId, safeTx.TransactionType.ToString(), safeTx.Category.ToString(), safeTx.Amount, safeTx.BalanceAfter, safeTx.CreatedAt, safeTx.Notes));
    }

    public async Task<Result<PaginatedList<SafeTransactionResponse>>> GetSafeTransactionsAsync(string safeId, FinanceFilters filters, CancellationToken ct = default)
    {
        var safeExists = await _dbContext.Safes.AnyAsync(s => s.Id == safeId && !s.IsDeleted, ct);
        if (!safeExists)
            return Result.Failure<PaginatedList<SafeTransactionResponse>>(SafeErrors.SafeNotFound);

        var query = _dbContext.SafeTransactions.Where(t => t.SafeId == safeId && !t.IsDeleted);

        if (filters.StartDate.HasValue)
            query = query.Where(t => t.CreatedAt >= filters.StartDate.Value);
        if (filters.EndDate.HasValue)
            query = query.Where(t => t.CreatedAt <= filters.EndDate.Value);

        var totalCount = await query.CountAsync(ct);
        var items = await query
            .OrderByDescending(t => t.CreatedAt)
            .ProjectToResponse()
            .Skip((filters.PageNumber - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<SafeTransactionResponse>(items, totalCount, filters.PageNumber, filters.PageSize));
    }
}




