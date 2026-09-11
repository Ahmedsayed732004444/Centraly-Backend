namespace Centraly.Api.Errors;

public record ProductErrors
{
    public static readonly Error CreationFailed =
        new("Product.CreationFailed", "فشل إنشاء المنتج", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("Product.NotFound", "المنتج غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Product.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error DepartmentNotFound =
        new("Product.DepartmentNotFound", "القسم المحدد غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error CategoryNotFound =
        new("Product.CategoryNotFound", "التصنيف المحدد غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error BarcodeAlreadyExists =
        new("Product.BarcodeAlreadyExists", "يوجد منتج آخر بنفس الباركود", StatusCodes.Status409Conflict);

    public static readonly Error BatchNotFound =
        new("Product.BatchNotFound", "الدفعة المحددة غير موجودة لهذا المنتج", StatusCodes.Status404NotFound);

    public static readonly Error UpdateFailed =
        new("Product.UpdateFailed", "فشل تحديث المنتج", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Product.DeleteFailed", "فشل حذف المنتج", StatusCodes.Status400BadRequest);

    public static readonly Error NegativeQuantity =
        new("Product.NegativeQuantity", "لا يمكن ضبط كمية المنتج على رقم سالب", StatusCodes.Status400BadRequest);

    public static readonly Error CannotDeleteWithStock =
        new("Product.CannotDeleteWithStock", "لا يمكن حذف منتج مازال له رصيد في المخزون. قم بتصفير الكمية أولاً", StatusCodes.Status400BadRequest);
}
