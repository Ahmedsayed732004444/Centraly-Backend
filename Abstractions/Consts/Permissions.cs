namespace Centraly.Api.Abstractions.Consts;

public static class Permissions
{
    public static string Type { get; } = "permissions";
    // Inventory
    public const string InventoryRead = "inventory:read";
    public const string InventoryWrite = "inventory:write";

    // Maintenance
    public const string MaintenanceRead = "maintenance:read";
    public const string MaintenanceWrite = "maintenance:write";

    // Sales
    public const string SalesRead = "sales:read";
    public const string SalesWrite = "sales:write";

    // Purchases
    public const string PurchasesRead = "purchases:read";
    public const string PurchasesWrite = "purchases:write";

    // Contacts (Suppliers)
    public const string SuppliersRead = "suppliers:read";
    public const string SuppliersWrite = "suppliers:write";
    // Contacts (Customers)
    public const string CustomersRead = "customers:read";
    public const string CustomersWrite = "customers:write";

    // Finance (Drawer/Safe/Expenses)
    public const string FinanceRead = "finance:read";
    public const string FinanceWrite = "finance:write";

    // Wallets
    public const string WalletsRead = "wallets:read";
    public const string WalletsWrite = "wallets:write";
    // Users
    public const string UsersRead = "users:read";
    public const string UsersWrite = "users:write";
    // Roles
    public const string RolesRead = "roles:read";
    public const string RolesWrite = "roles:write";

    public static IList<string?> GetAllPermissions() =>
        typeof(Permissions).GetFields().Select(x => x.GetValue(x) as string).ToList();
}
