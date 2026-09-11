namespace Centraly.Api.Errors;

public record SalesReturnErrors
{
    public static readonly Error ReturnNotFound =
        new("SalesReturn.NotFound", "سجل المرتجع غير موجود", StatusCodes.Status404NotFound);

    public static readonly Error InvoiceNotFound =
        new("SalesReturn.InvoiceNotFound", "الفاتورة غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error InvalidReturn =
        new("SalesReturn.InvalidReturn", "الصنف غير موجود في الفاتورة أو الكمية المرتجعة تتجاوز المتبقي", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("SalesReturn.ProductNotFound", "المنتج أو الدفعة غير موجودة لأحد الأصناف المرتجعة", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("SalesReturn.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error CreationFailed =
        new("SalesReturn.CreationFailed", "فشل تسجيل المرتجع", StatusCodes.Status500InternalServerError);
}
