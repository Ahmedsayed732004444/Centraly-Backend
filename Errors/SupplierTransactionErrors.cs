namespace Centraly.Api.Errors;

public record SupplierTransactionErrors
{
    public static readonly Error PaymentCreationFailed =
        new("SupplierTransaction.PaymentCreationFailed", "فشل تسجيل دفعة المورد", StatusCodes.Status400BadRequest);

    public static readonly Error ReturnCreationFailed =
        new("SupplierTransaction.ReturnCreationFailed", "فشل تسجيل مرتجع المورد", StatusCodes.Status400BadRequest);

    public static readonly Error PaymentNotFound =
        new("SupplierTransaction.PaymentNotFound", "دفعة المورد غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error ReturnNotFound =
        new("SupplierTransaction.ReturnNotFound", "مرتجع المورد غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error SupplierNotFound =
        new("SupplierTransaction.SupplierNotFound", "المورد المحدد غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("SupplierTransaction.ProductNotFound", "أحد المنتجات في المرتجع غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error BatchNotFound =
        new("SupplierTransaction.BatchNotFound", "أحد الدفعات في المرتجع غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientQuantity =
        new("SupplierTransaction.InsufficientQuantity", "لا يمكن إرجاع كمية أكبر من المتاح في المخزون", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidSortColumn =
        new("SupplierTransaction.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);
}
