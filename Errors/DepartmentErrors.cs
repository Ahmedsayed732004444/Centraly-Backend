namespace Centraly.Api.Errors;

public record DepartmentErrors
{
    public static readonly Error CreationFailed =
        new("Department.CreationFailed", "فشل إنشاء القسم", StatusCodes.Status400BadRequest);

    public static readonly Error DepartmentNotFound =
        new("Department.NotFound", "القسم غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Department.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Department.UpdateFailed", "فشل تحديث القسم", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Department.DeleteFailed", "فشل حذف القسم", StatusCodes.Status400BadRequest);
}
