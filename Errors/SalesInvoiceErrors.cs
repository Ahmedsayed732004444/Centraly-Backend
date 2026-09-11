namespace Centraly.Api.Errors;

public record SalesInvoiceErrors
{
    public static readonly Error InvoiceNotFound =
        new("SalesInvoice.NotFound", "الفاتورة غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error CustomerNotFound =
        new("SalesInvoice.CustomerNotFound", "العميل المحدد غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidPayment =
        new("SalesInvoice.InvalidPayment", "المبيعات النقدية يجب أن تُدفع بالكامل", StatusCodes.Status400BadRequest);

    public static readonly Error BatchNotFound =
        new("SalesInvoice.BatchNotFound", "بعض الدفعات غير موجودة أو لا تطابق المنتج المطلوب", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientQuantity =
        new("SalesInvoice.InsufficientQuantity", "الكمية المتاحة في المخزون غير كافية", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidSortColumn =
        new("SalesInvoice.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error CreationFailed =
        new("SalesInvoice.CreationFailed", "حدث خطأ أثناء إنشاء فاتورة المبيعات", StatusCodes.Status500InternalServerError);
}
