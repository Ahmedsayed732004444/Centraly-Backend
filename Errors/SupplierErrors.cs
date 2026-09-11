namespace Centraly.Api.Errors;

public record SupplierErrors
{
    public static readonly Error CreationFailed =
        new("Supplier.CreationFailed", "فشل إنشاء المورد", StatusCodes.Status400BadRequest);

    public static readonly Error SupplierNotFound =
        new("Supplier.NotFound", "المورد غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Supplier.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Supplier.UpdateFailed", "فشل تحديث المورد", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Supplier.DeleteFailed", "فشل حذف المورد", StatusCodes.Status400BadRequest);

    public static readonly Error HasOutstandingDebt =
        new("Supplier.HasOutstandingDebt", "لا يمكن حذف مورد لديه مديونية قائمة", StatusCodes.Status400BadRequest);
}
