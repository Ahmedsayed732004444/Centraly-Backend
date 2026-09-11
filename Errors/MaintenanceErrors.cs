namespace Centraly.Api.Errors;

public record MaintenanceErrors
{
    public static readonly Error NotFound =
        new("Maintenance.NotFound", "تذكرة الصيانة غير موجودة", StatusCodes.Status404NotFound);

    public static readonly Error InvalidStatus =
        new("Maintenance.InvalidStatus", "لا يمكن تعديل تذكرة تم تسليمها أو إرجاعها", StatusCodes.Status400BadRequest);

    public static readonly Error AlreadyDelivered =
        new("Maintenance.AlreadyDelivered", "تم تسليم هذه التذكرة مسبقاً", StatusCodes.Status400BadRequest);

    public static readonly Error NotPending =
        new("Maintenance.NotPending", "لا يمكن إرجاع التذكرة لأنها ليست قيد الانتظار", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("Maintenance.ProductNotFound", "أحد المنتجات المستخدمة غير موجود", StatusCodes.Status400BadRequest);

    public static readonly Error DuplicateProduct =
        new("Maintenance.DuplicateProduct", "لا يمكن تكرار نفس المنتج أكثر من مرة في التذكرة", StatusCodes.Status400BadRequest);

    public static readonly Error CreationFailed =
        new("Maintenance.CreationFailed", "فشل إنشاء تذكرة الصيانة", StatusCodes.Status500InternalServerError);

    public static readonly Error UpdateFailed =
        new("Maintenance.UpdateFailed", "فشل تحديث تذكرة الصيانة", StatusCodes.Status500InternalServerError);

    public static readonly Error DeliveryFailed =
        new("Maintenance.DeliveryFailed", "فشل تسليم تذكرة الصيانة", StatusCodes.Status500InternalServerError);

    public static readonly Error ReturnFailed =
        new("Maintenance.ReturnFailed", "فشل إرجاع تذكرة الصيانة", StatusCodes.Status500InternalServerError);

    public static readonly Error InvalidSortColumn =
        new("Maintenance.InvalidSortColumn", "عمود الترتيب المحدد غير مسموح به", StatusCodes.Status400BadRequest);

    public static Error InsufficientStock(string productName) =>
        new("Maintenance.InsufficientStock", $"لا يوجد مخزون كافٍ للمنتج: {productName}", StatusCodes.Status400BadRequest);
}