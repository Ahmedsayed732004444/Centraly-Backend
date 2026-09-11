namespace Centraly.Api.Errors;

public record TransactionRouterErrors
{
    public static readonly Error PolicyViolation =
        new("TransactionRouter.PolicyViolation", "مصدر الدفع المطلوب غير مسموح به لهذا النوع من العمليات", StatusCodes.Status400BadRequest);

    public static readonly Error NoMainSafe =
        new("TransactionRouter.NoMainSafe", "لا توجد خزينة رئيسية", StatusCodes.Status404NotFound);
}
