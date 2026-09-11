namespace Centraly.Api.Errors;

public record FinancePolicyErrors
{
    public static readonly Error InvalidCategory =
        new("FinancePolicy.InvalidCategory", "فئة العملية المالية غير صالحة", StatusCodes.Status400BadRequest);

    public static readonly Error PolicyNotFound =
        new("FinancePolicy.PolicyNotFound", "السياسة غير موجودة", StatusCodes.Status404NotFound);
}
