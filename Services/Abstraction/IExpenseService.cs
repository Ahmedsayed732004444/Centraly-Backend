using Centraly.Api.Contracts.Finance;

namespace Centraly.Api.Services.Abstraction;

public interface IExpenseService
{
    Task<Result<ExpenseCategoryResponse>> CreateExpenseCategoryAsync(CreateExpenseCategoryRequest request, string? userId, CancellationToken ct = default);
    Task<Result<IEnumerable<ExpenseCategoryResponse>>> GetExpenseCategoriesAsync(CancellationToken ct = default);
    Task<Result<ExpenseResponse>> RecordExpenseAsync(CreateExpenseRequest request, string? userId, CancellationToken ct = default);
    Task<Result<PaginatedList<ExpenseResponse>>> GetExpensesAsync(FinanceFilters filters, CancellationToken ct = default);
}

