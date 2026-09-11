namespace Centraly.Api.Errors;

public record PurchaseInvoiceErrors
{
    public static readonly Error CreationFailed =
        new("PurchaseInvoice.CreationFailed", "فشل إنشاء فاتورة المشتريات", StatusCodes.Status400BadRequest);

    public static readonly Error InvoiceNotFound =
        new("PurchaseInvoice.NotFound", "فاتورة المشتريات غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("PurchaseInvoice.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static readonly Error SupplierNotFound =
        new("PurchaseInvoice.SupplierNotFound", "المورد المحدد غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("PurchaseInvoice.ProductNotFound", "أحد المنتجات في الفاتورة غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidPaidAmount =
        new("PurchaseInvoice.InvalidPaidAmount", "المبلغ المدفوع لا يمكن أن يكون أكبر من إجمالي الفاتورة", StatusCodes.Status400BadRequest);
}
