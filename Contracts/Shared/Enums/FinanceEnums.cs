namespace Centraly.Api.Contracts.Shared.Enums;

public enum SafeTransactionCategory
{
    DrawerDeposit = 1,
    OwnerDeposit = 2,
    OwnerWithdrawal = 3,
    ExpensePayment = 4,
    General = 5,
    ManualDeposit = 6,
    ManualWithdrawal = 7,
    Sales = 8,
    Returns = 9,
    Purchases = 10,
    SupplierReturn = 11,
    SupplierPayment = 12,
    CustomerPayment = 13,
    Maintenance = 14
}

public enum PaymentSource
{
    Drawer = 1,
    Safe = 2
}

public enum PaymentSourcePolicy
{
    DrawerOnly = 1,
    SafeOnly = 2,
    Either = 3
}

public enum GlobalTransactionCategory
{
    CashSale = 1,
    SalesReturn = 2,
    CashPurchase = 3,
    PurchaseReturn = 4,
    SupplierPayment = 5,
    SupplierReceipt = 6,
    CustomerPayment = 7,
    CustomerRefund = 8,
    Expense = 9,
    OwnerDeposit = 10,
    OwnerWithdrawal = 11,
    ManualIncome = 12,
    ManualExpense = 13,
    WalletOperation = 14,
    MaintenanceIncome = 15,
    MaintenanceExpense = 16
}

