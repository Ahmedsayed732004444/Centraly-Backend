namespace Centraly.Api.Entities.Common;

public enum SaleType
{
    Wholesale = 1,  // جملة
    Retail = 2      // تجزئة
}

public enum PaymentMethod
{
    Cash = 1,       // كاش
    Deferred = 2    // آجل / مديونية
}

public enum ReturnReason
{
    Defect = 1,         // عطل
    ChangedMind = 2,    // تغيير رأي
    Other = 3           // سبب آخر
}

public enum MaintenanceStatus
{
    Pending = 1,        // معلق
    Delivered = 2,      // تم التسليم
    Returned = 3        // مرتجع
}

public enum DrawerType
{
    Sales = 1,
    Maintenance = 2
}

public enum DrawerTransactionType
{
    Income = 1,     // إيراد
    Expense = 2     // صادر
}

public enum DrawerTransactionCategory
{
    Sales = 1,          // مبيعات
    Suppliers = 2,      // موردين (دفعات مديونية)
    Maintenance = 3,    // صيانة
    Returns = 4,        // مرتجعات (من العملاء)
    CustomerDebt = 5,   // تسديد مديونية عميل
    Operational = 6,    // تشغيلية (يدوي)
    Purchases = 7,      // واردات (شراء بضاعة من مورد)
    SupplierReturn = 8,
    Expense = 9,  // إرجاع بضاعة لمورد (استرداد كاش)
    WalletOperation = 10
}

public enum TransactionLogType
{
    Sale = 1,
    Return = 2,
    Maintenance = 3,
    Inventory = 4,
    Supplier = 5,
    Drawer = 6,
    SparePart = 7,
    Customer = 8,
    Purchase = 9
}



public enum ProductUsage
{
    SaleOnly = 1,
    MaintenanceOnly = 2,
    SaleAndMaintenance = 3
}
