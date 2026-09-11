namespace Centraly.Api.Errors;

public record CategoryErrors
{
    public static readonly Error CreationFailed =
        new("Category.CreationFailed", "فشل إنشاء التصنيف", StatusCodes.Status400BadRequest);

    public static readonly Error CategoryNotFound =
        new("Category.NotFound", "التصنيف غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Category.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error DepartmentNotFound =
        new("Category.DepartmentNotFound", "القسم المحدد غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Category.UpdateFailed", "فشل تحديث التصنيف", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Category.DeleteFailed", "فشل حذف التصنيف", StatusCodes.Status400BadRequest);
}
