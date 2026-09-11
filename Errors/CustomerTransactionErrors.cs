namespace Centraly.Api.Errors;

public record CustomerTransactionErrors
{
    public static readonly Error PaymentFailed =
        new("CustomerTransaction.PaymentFailed", "فشل تسجيل الدفعة", StatusCodes.Status500InternalServerError);

    public static readonly Error ReturnFailed =
        new("CustomerTransaction.ReturnFailed", "فشل تسجيل المرتجع", StatusCodes.Status500InternalServerError);

    public static readonly Error InvoiceNotFound =
        new("CustomerTransaction.InvoiceNotFound", "الفاتورة غير موجودة أو لا تخص هذا العميل", StatusCodes.Status404NotFound);

    public static readonly Error InvalidReturn =
        new("CustomerTransaction.InvalidReturn", "الصنف غير موجود في الفاتورة أو الكمية المرتجعة تتجاوز المتبقي", StatusCodes.Status400BadRequest);

    public static readonly Error BatchNotFound =
        new("CustomerTransaction.BatchNotFound", "الدفعة غير موجودة", StatusCodes.Status400BadRequest);
}
