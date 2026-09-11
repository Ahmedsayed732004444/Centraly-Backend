namespace Centraly.Api.Services.Implementation;

public class DrawerService(ApplicationDbContext dbContext) : IDrawerService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    private static readonly string[] AllowedSessionSortColumns = ["OpenedAt", "ClosingBalance"];

    // ─────────────────────────────────────────────────────────────────
    //  Open Session
    // ─────────────────────────────────────────────────────────────────
    // "Already open" is scoped per DrawerType, so a Sales shift being open
    // does not block opening an independent Maintenance shift, and vice versa.

    public async Task<Result<DrawerSessionResponse>> OpenSessionAsync(OpenSessionRequest request, string userId, CancellationToken ct = default)
    {
        var hasActiveSession = await _dbContext.DrawerSessions.AnyAsync(s => !s.IsClosed && (int)s.Type == request.Type, ct);
        if (hasActiveSession)
            return Result.Failure<DrawerSessionResponse>(DrawerErrors.AlreadyOpen);

        var session = new DrawerSession
        {
            Type = (DrawerType)request.Type,
            OpeningBalance = request.OpeningBalance,
            RunningBalance = request.OpeningBalance,
            OpenedAt = DateTime.UtcNow,
            OpenedByUserId = userId,
            IsClosed = false,
            CreatedByUserId = userId
        };

        _dbContext.DrawerSessions.Add(session);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new DrawerSessionResponse(
            session.Id, (int)session.Type, session.OpeningBalance, session.OpenedAt, session.OpenedByUserId,
            session.IsClosed, session.ClosedAt, session.TotalIncome, session.TotalExpense, session.ClosingBalance, 0, []));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Close Session
    // ─────────────────────────────────────────────────────────────────
    // Sums are computed in SQL (SumAsync) instead of loading every
    // transaction into memory, then the session row is closed with a
    // single ExecuteUpdateAsync (no tracking, no full entity load).

    public async Task<Result<DrawerSessionResponse>> CloseSessionAsync(int type, string userId, CancellationToken ct = default)
    {
        var session = await _dbContext.DrawerSessions
            .Where(s => !s.IsClosed && (int)s.Type == type)
            .Select(s => new { s.Id, s.OpeningBalance })
            .FirstOrDefaultAsync(ct);

        if (session is null)
            return Result.Failure<DrawerSessionResponse>(DrawerErrors.NoActiveSession);

        var totalIncome = await _dbContext.DrawerTransactions
            .Where(t => t.DrawerSessionId == session.Id && t.Type == DrawerTransactionType.Income)
            .SumAsync(t => t.Amount, ct);

        var totalExpense = await _dbContext.DrawerTransactions
            .Where(t => t.DrawerSessionId == session.Id && t.Type == DrawerTransactionType.Expense)
            .SumAsync(t => t.Amount, ct);

        var closingBalance = session.OpeningBalance + totalIncome - totalExpense;

        var totalProfit = await _dbContext.DrawerTransactions
            .Where(t => t.DrawerSessionId == session.Id)
            .SumAsync(t => t.Profit, ct);

        await _dbContext.DrawerSessions
            .Where(s => s.Id == session.Id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.TotalIncome, totalIncome)
                .SetProperty(s => s.TotalExpense, totalExpense)
                .SetProperty(s => s.ClosingBalance, closingBalance)
                .SetProperty(s => s.TotalProfit, totalProfit)
                .SetProperty(s => s.IsClosed, true)
                .SetProperty(s => s.ClosedAt, DateTime.UtcNow)
                .SetProperty(s => s.UpdatedAt, DateTime.UtcNow)
                .SetProperty(s => s.UpdatedByUserId, userId), ct);

        return await GetSessionByIdAsync(session.Id, ct);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Record Transaction
    // ─────────────────────────────────────────────────────────────────
    // The target shift (Sales vs Maintenance) is resolved automatically from
    // the transaction category, so callers never need to know about DrawerType.
    // The running balance is derived from the *last* transaction's Balance
    // (a single row) instead of re-summing every transaction the session has
    // ever had - this used to get slower as the shift went on.

    // RunningBalance is guarded by DrawerSession.Version (a rowversion concurrency
    // token) instead of relying on transaction isolation level. Two calls racing on the
    // same session - even when one of them is nested inside a caller's own,
    // non-Serializable transaction (e.g. SalesInvoiceService's) - can never silently
    // overwrite each other's balance update: the loser's SaveChangesAsync throws
    // DbUpdateConcurrencyException (a client-side rowcount check, not a SQL error, so
    // the ambient transaction stays usable) and this method reloads the fresh balance
    // and retries.
    private const int MaxConcurrencyRetries = 5;

    public async Task<Result<DrawerTransactionResponse>> RecordTransactionAsync(
        DrawerTransactionCategory category, DrawerTransactionType type, decimal amount, decimal profit,
        string? notes, string? source, string userId, CancellationToken ct = default)
    {
        var targetType = ResolveType(category);

        var ownsTransaction = _dbContext.Database.CurrentTransaction == null;
        var dbTransaction = ownsTransaction ? await _dbContext.Database.BeginTransactionAsync(ct) : null;
        try
        {
            for (var attempt = 1; attempt <= MaxConcurrencyRetries; attempt++)
            {
                var session = await _dbContext.DrawerSessions
                    .Where(s => !s.IsClosed && s.Type == targetType)
                    .FirstOrDefaultAsync(ct);

                if (session is null)
                    return Result.Failure<DrawerTransactionResponse>(DrawerErrors.NoActiveSession);

                if (amount < 0 || (amount == 0 && profit == 0))
                    return Result.Failure<DrawerTransactionResponse>(DrawerErrors.InvalidAmount);

                if (type == DrawerTransactionType.Expense && session.RunningBalance < amount)
                    return Result.Failure<DrawerTransactionResponse>(DrawerErrors.InsufficientFunds);

                var newBalance = type == DrawerTransactionType.Income ? session.RunningBalance + amount : session.RunningBalance - amount;
                session.RunningBalance = newBalance;

                var transaction = new DrawerTransaction
                {
                    DrawerSessionId = session.Id,
                    Type = type,
                    Category = category,
                    Amount = amount,
                    Profit = profit,
                    Balance = newBalance,
                    Source = source,
                    Notes = notes,
                    UserId = userId,
                    CreatedByUserId = userId
                };

                _dbContext.DrawerTransactions.Add(transaction);

                try
                {
                    await _dbContext.SaveChangesAsync(ct);
                    if (ownsTransaction) await dbTransaction!.CommitAsync(ct);

                    return Result.Success(new DrawerTransactionResponse(
                        transaction.Id, transaction.Type, transaction.Category, transaction.Amount, transaction.Balance,
                        transaction.Source, transaction.Notes, transaction.CreatedAt, transaction.UserId));
                }
                catch (DbUpdateConcurrencyException) when (attempt < MaxConcurrencyRetries)
                {
                    _dbContext.Entry(session).State = EntityState.Detached;
                    _dbContext.Entry(transaction).State = EntityState.Detached;
                }
            }

            return Result.Failure<DrawerTransactionResponse>(DrawerErrors.ConcurrencyConflict);
        }
        catch
        {
            if (ownsTransaction) await dbTransaction!.RollbackAsync(ct);
            throw;
        }
        finally
        {
            if (ownsTransaction) await dbTransaction!.DisposeAsync();
        }
    }

    public Task<Result<DrawerTransactionResponse>> AddManualTransactionAsync(
        AddManualTransactionRequest request, string userId, CancellationToken ct = default)
    {
        decimal profit = request.Type == DrawerTransactionType.Expense ? -request.Amount : 0m;
        return RecordTransactionAsync(request.Category, request.Type, request.Amount, profit, request.Notes, request.Source, userId, ct);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Active Session / By Id (full detail, including transactions)
    // ─────────────────────────────────────────────────────────────────
    // NOTE - bug fix: these used to filter (.Where) AFTER SelectSessionResponse,
    // i.e. on the already-projected DrawerSessionResponse DTO - which itself
    // contains a nested subquery (Transactions...ToList()). EF Core cannot
    // translate a filter applied on top of a projection that already embeds a
    // materialized subquery, and threw "could not be translated". The fix is to
    // filter the raw DrawerSession entities first (where IsClosed/Type/Id map
    // directly to columns) and only then project to the response shape.

    public async Task<Result<DrawerSessionResponse>> GetActiveSessionAsync(int type = 1, CancellationToken ct = default)
    {
        var query = _dbContext.DrawerSessions
            .Where(s => !s.IsClosed && (int)s.Type == type);

        var response = await SelectSessionResponse(query).FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<DrawerSessionResponse>(DrawerErrors.NoActiveSession)
            : Result.Success(response);
    }

    public async Task<Result<DrawerSessionResponse>> GetSessionByIdAsync(string id, CancellationToken ct = default)
    {
        var query = _dbContext.DrawerSessions
            .Where(s => s.Id == id);

        var response = await SelectSessionResponse(query).FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<DrawerSessionResponse>(DrawerErrors.SessionNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Sessions History (list view - summary only; optionally scoped to one shift type)
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<DrawerSessionResponse>>> GetSessionsHistoryAsync(
        RequestFilters filters, int? type = null, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.DrawerSessions
                .Where(s => type == null || (int)s.Type == type)
                .Where(s => filters.StartDate == null || s.OpenedAt >= filters.StartDate)
                .Where(s => filters.EndDate == null || s.OpenedAt <= filters.EndDate)
                .ApplyFilters(filters, allowedSortColumns: AllowedSessionSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(s => s.OpenedAt);

            var mappedQuery = query
                .Select(s => new DrawerSessionResponse(
                    s.Id, (int)s.Type, s.OpeningBalance, s.OpenedAt, s.OpenedByUserId, s.IsClosed, s.ClosedAt,
                    s.TotalIncome, s.TotalExpense, s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), new List<DrawerTransactionResponse>()))
                .AsNoTracking();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException)
        {
            return Result.Failure<PaginatedList<DrawerSessionResponse>>(DrawerErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Helpers
    // ─────────────────────────────────────────────────────────────────

    private static DrawerType ResolveType(DrawerTransactionCategory category) =>
        category == DrawerTransactionCategory.Maintenance ? DrawerType.Maintenance : DrawerType.Sales;

    private static IQueryable<DrawerSessionResponse> SelectSessionResponse(IQueryable<DrawerSession> query) =>
        query
            .Select(s => new DrawerSessionResponse(
                s.Id,
                (int)s.Type,
                s.OpeningBalance,
                s.OpenedAt,
                s.OpenedByUserId,
                s.IsClosed,
                s.ClosedAt,
                s.TotalIncome,
                s.TotalExpense,
                s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), s.Transactions
                    .OrderByDescending(t => t.CreatedAt)
                    .Select(t => new DrawerTransactionResponse(
                        t.Id, t.Type, t.Category, t.Amount, t.Balance, t.Source, t.Notes, t.CreatedAt, t.UserId))
                    .ToList()))
            .AsNoTracking();
}

