using Centraly.Api.Contracts.Finance;
namespace Centraly.Api.Controllers;

[ApiController]
[Route("expenses")]
[Authorize]

public class ExpenseController(IExpenseService _expenseService) : ControllerBase
{
    [Authorize(Roles = "Admin,Manager")]
    [HttpPost("categories")]
    public async Task<IActionResult> CreateCategory(CreateExpenseCategoryRequest request, CancellationToken ct)
    {
        var result = await _expenseService.CreateExpenseCategoryAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories(CancellationToken ct)
    {
        var result = await _expenseService.GetExpenseCategoriesAsync(ct);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> RecordExpense(CreateExpenseRequest request, CancellationToken ct)
    {
        var result = await _expenseService.RecordExpenseAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses([FromQuery] FinanceFilters filters, CancellationToken ct)
    {
        var result = await _expenseService.GetExpensesAsync(filters, ct);
        return Ok(result.Value);
    }
}


