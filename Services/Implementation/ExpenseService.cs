using Microsoft.Extensions.Caching.Hybrid;

namespace Centraly.Api.Services.Implementation;

public class ExpenseService : IExpenseService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ITransactionRouterService _transactionRouter;
    private readonly HybridCache _hybridCache;

    // A short, admin-managed lookup list used on every "record an expense" form -
    // read constantly, changed almost never.
    private const string CategoriesCachePrefix = "expenseCategories";

    public ExpenseService(ApplicationDbContext dbContext, ITransactionRouterService transactionRouter, HybridCache hybridCache)
    {
        _dbContext = dbContext;
        _transactionRouter = transactionRouter;
        _hybridCache = hybridCache;
    }

    public async Task<Result<ExpenseCategoryResponse>> CreateExpenseCategoryAsync(CreateExpenseCategoryRequest request, string? userId, CancellationToken ct = default)
    {
        var cat = new ExpenseCategory
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            CreatedByUserId = userId
        };

        await _dbContext.ExpenseCategories.AddAsync(cat, ct);
        await _dbContext.SaveChangesAsync(ct);
        await _hybridCache.RemoveByTagAsync(CategoriesCachePrefix, ct);

        return Result.Success(new ExpenseCategoryResponse(cat.Id, cat.Name));
    }

    public async Task<Result<IEnumerable<ExpenseCategoryResponse>>> GetExpenseCategoriesAsync(CancellationToken ct = default)
    {
        var categories = await _hybridCache.GetOrCreateAsync(
            $"{CategoriesCachePrefix}-all",
            async ct => await _dbContext.ExpenseCategories.Where(c => !c.IsDeleted).Select(c => new ExpenseCategoryResponse(c.Id, c.Name)).ToListAsync(ct),
            tags: [CategoriesCachePrefix],
            cancellationToken: ct);

        return Result.Success<IEnumerable<ExpenseCategoryResponse>>(categories);
    }

    public async Task<Result<ExpenseResponse>> RecordExpenseAsync(CreateExpenseRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var category = await _dbContext.ExpenseCategories.FirstOrDefaultAsync(c => c.Id == request.CategoryId && !c.IsDeleted, ct);
            if (category is null) return Result.Failure<ExpenseResponse>(ExpenseErrors.CategoryNotFound);

            // An expense is not COGS-backed, so it reduces net profit by its full amount -
            // matching DrawerService.AddManualTransactionAsync's convention for manual
            // expenses instead of silently recording zero profit impact.
            var routeResult = await _transactionRouter.RouteTransactionAsync(GlobalTransactionCategory.Expense, request.Amount, -request.Amount, request.PaymentSource, request.Notes, null, userId ?? "", ct);
            if (routeResult.IsFailure) return Result.Failure<ExpenseResponse>(routeResult.Error);

            var expense = new Expense
            {
                Id = Guid.NewGuid().ToString(),
                CategoryId = category.Id,
                Amount = request.Amount,
                PaymentSource = request.PaymentSource ?? PaymentSource.Drawer, // Temp fallback if not nullable
                SourceTransactionId = routeResult.Value.Id,
                ExpenseDate = DateTime.UtcNow,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            await _dbContext.Expenses.AddAsync(expense, ct);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
            return Result.Success(new ExpenseResponse(expense.Id, category.Id, category.Name, expense.Amount, expense.PaymentSource.ToString(), expense.ExpenseDate, expense.Notes));
        }
        catch
        {
            await transaction.RollbackAsync(ct);
            throw;
        }
    }

    public async Task<Result<PaginatedList<ExpenseResponse>>> GetExpensesAsync(FinanceFilters filters, CancellationToken ct = default)
    {
        var query = _dbContext.Expenses.Where(e => !e.IsDeleted);

        if (filters.StartDate.HasValue)
            query = query.Where(e => e.ExpenseDate >= filters.StartDate.Value);
        if (filters.EndDate.HasValue)
            query = query.Where(e => e.ExpenseDate <= filters.EndDate.Value);

        var totalCount = await query.CountAsync(ct);
        var items = await query
            .OrderByDescending(e => e.ExpenseDate)
            .Select(e => new ExpenseResponse(e.Id, e.CategoryId, e.Category!.Name, e.Amount, e.PaymentSource.ToString(), e.ExpenseDate, e.Notes))
            .Skip((filters.PageNumber - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<ExpenseResponse>(items, filters.PageNumber, filters.PageSize, totalCount));
    }
}




