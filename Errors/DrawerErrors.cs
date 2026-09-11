namespace Centraly.Api.Errors;

public record DrawerErrors
{
    public static readonly Error AlreadyOpen =
        new("Drawer.AlreadyOpen", "يوجد جلسة درج مفتوحة بالفعل، يجب إغلاقها أولاً", StatusCodes.Status400BadRequest);

    public static readonly Error NoActiveSession =
        new("Drawer.NoActiveSession", "لا توجد جلسة درج مفتوحة حالياً", StatusCodes.Status404NotFound);

    public static readonly Error InvalidAmount =
        new("Drawer.InvalidAmount", "يجب أن يكون المبلغ أكبر من صفر", StatusCodes.Status400BadRequest);

    public static readonly Error SessionNotFound =
        new("Drawer.NotFound", "جلسة الدرج غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Drawer.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientFunds =
        new("Drawer.InsufficientFunds", "لا يوجد رصيد كافٍ في الدرج لهذه العملية", StatusCodes.Status400BadRequest);

    public static readonly Error ConcurrencyConflict =
        new("Drawer.ConcurrencyConflict", "حدث تعارض أثناء تحديث رصيد الدرج، برجاء إعادة المحاولة", StatusCodes.Status409Conflict);
}
