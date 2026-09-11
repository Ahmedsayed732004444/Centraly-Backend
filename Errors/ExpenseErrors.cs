namespace Centraly.Api.Errors;

public record ExpenseErrors
{
    public static readonly Error CategoryNotFound =
        new("Expense.CategoryNotFound", "بند المصروفات غير موجود", StatusCodes.Status404NotFound);
}
