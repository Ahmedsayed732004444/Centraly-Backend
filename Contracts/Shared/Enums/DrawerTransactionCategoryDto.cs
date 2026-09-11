namespace Centraly.Api.Contracts.Shared.Enums;

/// <summary>
/// Data transfer object for the DrawerTransactionCategory enum.
/// </summary>
public enum DrawerTransactionCategoryDto
{
    Sales = 1,          // مبيعات
    Suppliers = 2,      // موردين (دفعات مديونية)
    Maintenance = 3,    // صيانة
    Returns = 4,        // مرتجعات (من العملاء)
    CustomerDebt = 5,   // تسديد مديونية عميل
    Operational = 6,    // تشغيلية (يدوي)
    Purchases = 7,      // واردات (شراء بضاعة من مورد)
    SupplierReturn = 8, // إرجاع بضاعة لمورد (استرداد كاش)
    WalletOperation = 10
}
