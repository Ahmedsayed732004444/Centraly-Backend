namespace Centraly.Api.Errors;

public record CustomerErrors
{
    public static readonly Error CustomerNotFound =
        new("Customer.NotFound", "العميل غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error CreationFailed =
        new("Customer.CreationFailed", "فشل إنشاء العميل", StatusCodes.Status400BadRequest);

    public static readonly Error HasOutstandingDebt =
        new("Customer.HasOutstandingDebt", "لا يمكن حذف عميل لديه رصيد مديونية قائم", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidSortColumn =
        new("Customer.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Customer.UpdateFailed", "فشل تحديث بيانات العميل", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Customer.DeleteFailed", "فشل حذف العميل", StatusCodes.Status400BadRequest);

    public static readonly Error Error =
        new("Customer.Error", "حدث خطأ أثناء معالجة الطلب", StatusCodes.Status500InternalServerError);
}
