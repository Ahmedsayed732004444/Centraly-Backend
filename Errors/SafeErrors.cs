namespace Centraly.Api.Errors;

public record SafeErrors
{
    public static readonly Error SafeNotFound =
        new("Safe.NotFound", "الخزينة غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error DrawerNotFound =
        new("Safe.DrawerNotFound", "جلسة الدرج غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error DrawerNotClosed =
        new("Safe.DrawerNotClosed", "لا يمكن التوريد من جلسة درج مفتوحة، يجب إغلاقها أولاً", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientFunds =
        new("Safe.InsufficientFunds", "لا يوجد رصيد كافٍ في الخزينة", StatusCodes.Status400BadRequest);
}
