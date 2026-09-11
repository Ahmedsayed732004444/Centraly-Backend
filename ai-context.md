This file is a merged representation of a subset of the codebase, containing files not matching ignore patterns, combined into a single document by Repomix.

# File Summary

## Purpose
This file contains a packed representation of a subset of the repository's contents that is considered the most important context.
It is designed to be easily consumable by AI systems for analysis, code review,
or other automated processes.

## File Format
The content is organized as follows:
1. This summary section
2. Repository information
3. Directory structure
4. Repository files (if enabled)
5. Multiple file entries, each consisting of:
  a. A header with the file path (## File: path/to/file)
  b. The full contents of the file in a code block

## Usage Guidelines
- This file should be treated as read-only. Any changes should be made to the
  original repository files, not this packed version.
- When processing this file, use the file path to distinguish
  between different files in the repository.
- Be aware that this file may contain sensitive information. Handle it with
  the same level of security as you would the original repository.

## Notes
- Some files may have been excluded based on .gitignore rules and Repomix's configuration
- Binary files are not included in this packed representation. Please refer to the Repository Structure section for a complete list of file paths, including binary files
- Files matching these patterns are excluded: ai-context.md, repomix-output.xml, keys/**, wwwroot/**, **/*.xml, **/*.csproj, **/*.sln, **/*.user, **/*.designer.cs, **/*.g.cs, **/bin/**, **/obj/**, **/.vs/**, **/Migrations/**
- Files matching patterns in .gitignore are excluded
- Files matching default ignore patterns are excluded
- Files are sorted by Git change count (files with more changes are at the bottom)

# Directory Structure
```
Abstractions/Consts/DefaultRoles.cs
Abstractions/Consts/DefaultSafe.cs
Abstractions/Consts/DefaultUsers.cs
Abstractions/Consts/Permissions.cs
Abstractions/Consts/RegexPatterns.cs
Abstractions/Error.cs
Abstractions/PaginatedList.cs
Abstractions/Result.cs
Abstractions/ResultExtensions.cs
appsettings.Development.json
appsettings.json
Authentication/IJwtProvider.cs
Authentication/JwtProvider.cs
Authorization/HasPermissionAttribute.cs
Centraly.Api.http
Contracts/Authentication/LoginRequest.cs
Contracts/Authentication/LoginRequestValidator.cs
Contracts/Authentication/LoginResponse.cs
Contracts/Authentication/RefreshTokenRequest.cs
Contracts/Authentication/RefreshTokenRequestValidator.cs
Contracts/Common/PagedResponse.cs
Contracts/Common/PaginationFilter.cs
Contracts/Common/RequestFilters.cs
Contracts/Customers/CreateCustomerRequest.cs
Contracts/Customers/CreateCustomerRequestValidator.cs
Contracts/Customers/CustomerDebtHistoryResponse.cs
Contracts/Customers/CustomerDebtPaymentResponse.cs
Contracts/Customers/CustomerInvoiceSummary.cs
Contracts/Customers/CustomerPaymentRequests.cs
Contracts/Customers/CustomerResponse.cs
Contracts/Customers/CustomerStatementResponse.cs
Contracts/Customers/UpdateCustomerRequest.cs
Contracts/Customers/UpdateCustomerRequestValidator.cs
Contracts/Drawer/DrawerRequests.cs
Contracts/Drawer/DrawerResponses.cs
Contracts/Finance/AddManualSafeTransactionRequest.cs
Contracts/Finance/CreateOwnerTransactionRequestValidator.cs
Contracts/Finance/FinanceContracts.cs
Contracts/Finance/FinanceFilters.cs
Contracts/Finance/OwnerRequests.cs
Contracts/Finance/OwnerResponses.cs
Contracts/Inventory/Categories/CategoryResponse.cs
Contracts/Inventory/Categories/CreateCategoryRequest.cs
Contracts/Inventory/Categories/CreateCategoryRequestValidator.cs
Contracts/Inventory/Categories/UpdateCategoryRequest.cs
Contracts/Inventory/Categories/UpdateCategoryRequestValidator.cs
Contracts/Inventory/Departments/CreateDepartmentRequest.cs
Contracts/Inventory/Departments/CreateDepartmentRequestValidator.cs
Contracts/Inventory/Departments/DepartmentResponse.cs
Contracts/Inventory/Departments/UpdateDepartmentRequest.cs
Contracts/Inventory/Departments/UpdateDepartmentRequestValidator.cs
Contracts/Inventory/Products/AdjustProductQuantityRequest.cs
Contracts/Inventory/Products/AdjustProductQuantityRequestValidator.cs
Contracts/Inventory/Products/CreateProductRequest.cs
Contracts/Inventory/Products/CreateProductRequestValidator.cs
Contracts/Inventory/Products/ProductResponse.cs
Contracts/Inventory/Products/ProductSupplierResponse.cs
Contracts/Inventory/Products/UpdateProductRequest.cs
Contracts/Inventory/Products/UpdateProductRequestValidator.cs
Contracts/Maintenance/CreateMaintenanceRequest.cs
Contracts/Maintenance/MaintenanceProductItemDto.cs
Contracts/Maintenance/MaintenanceResponse.cs
Contracts/Maintenance/MaintenanceSummary.cs
Contracts/Returns/CreateCustomerReturnRequestValidator.cs
Contracts/Returns/CustomerReturnRequests.cs
Contracts/Returns/SupplierReturnRequests.cs
Contracts/Roles/RoleDetailResponse.cs
Contracts/Roles/RoleRequest.cs
Contracts/Roles/RoleRequestValidator.cs
Contracts/Roles/RoleResponse.cs
Contracts/Sales/CreateInvoiceItemRequest.cs
Contracts/Sales/CreateSalesInvoiceRequest.cs
Contracts/Sales/CreateSalesInvoiceRequestValidator.cs
Contracts/Sales/SalesInvoiceResponse.cs
Contracts/Shared/Enums/DrawerTransactionCategoryDto.cs
Contracts/Shared/Enums/DrawerTransactionTypeDto.cs
Contracts/Shared/Enums/FinanceEnums.cs
Contracts/Shared/Enums/MaintenanceStatusDto.cs
Contracts/Shared/Enums/PaymentMethodDto.cs
Contracts/Shared/Enums/ProductUsageDto.cs
Contracts/Shared/Enums/ReturnReasonDto.cs
Contracts/Shared/Enums/SaleTypeDto.cs
Contracts/Shared/Summaries/CategorySummary.cs
Contracts/Shared/Summaries/CustomerSummary.cs
Contracts/Shared/Summaries/DepartmentSummary.cs
Contracts/Shared/Summaries/DrawerSessionSummary.cs
Contracts/Shared/Summaries/ProductSummary.cs
Contracts/Shared/Summaries/SupplierSummary.cs
Contracts/Shared/Summaries/UserSummary.cs
Contracts/Suppliers/CreatePurchaseInvoiceItemRequest.cs
Contracts/Suppliers/CreatePurchaseInvoiceRequest.cs
Contracts/Suppliers/CreatePurchaseInvoiceRequestValidator.cs
Contracts/Suppliers/CreateSupplierPaymentRequest.cs
Contracts/Suppliers/CreateSupplierPaymentRequestValidator.cs
Contracts/Suppliers/CreateSupplierRequest.cs
Contracts/Suppliers/CreateSupplierRequestValidator.cs
Contracts/Suppliers/CreateSupplierReturnRequest.cs
Contracts/Suppliers/CreateSupplierReturnRequestValidator.cs
Contracts/Suppliers/PurchaseInvoiceItemResponse.cs
Contracts/Suppliers/PurchaseInvoiceResponse.cs
Contracts/Suppliers/SupplierBatchResponse.cs
Contracts/Suppliers/SupplierPaymentResponse.cs
Contracts/Suppliers/SupplierResponse.cs
Contracts/Suppliers/SupplierReturnResponse.cs
Contracts/Suppliers/SupplierStatementItemResponse.cs
Contracts/Suppliers/UpdateSupplierRequest.cs
Contracts/Suppliers/UpdateSupplierRequestValidator.cs
Contracts/Users/CreateUserRequest.cs
Contracts/Users/CreateUserRequestValidator.cs
Contracts/Users/UpdateUserRequest.cs
Contracts/Users/UpdateUserRequestValidator.cs
Contracts/Users/UserResponse.cs
Contracts/Wallets/WalletRequests.cs
Contracts/Wallets/WalletResponses.cs
Controllers/AuthController.cs
Controllers/CategoryController.cs
Controllers/CustomerController.cs
Controllers/CustomerTransactionController.cs
Controllers/DepartmentController.cs
Controllers/DrawerController.cs
Controllers/ExpenseController.cs
Controllers/FinancePolicyController.cs
Controllers/MaintenanceController.cs
Controllers/OwnerTransactionController.cs
Controllers/ProductController.cs
Controllers/PurchaseInvoiceController.cs
Controllers/RoleController.cs
Controllers/SafeController.cs
Controllers/SalesInvoiceController.cs
Controllers/SalesReturnController.cs
Controllers/SupplierController.cs
Controllers/SupplierTransactionController.cs
Controllers/UserController.cs
Controllers/WalletsController.cs
Dependencies.cs
dotnet-tools.json
drop_wallets.sql
Entities/ApplicationRole.cs
Entities/ApplicationUser.cs
Entities/Common/BaseEntity.cs
Entities/Common/Enums.cs
Entities/Common/ISoftDelete.cs
Entities/Customers/Customer.cs
Entities/Customers/CustomerDebtPayment.cs
Entities/Drawer/DrawerSession.cs
Entities/Drawer/DrawerTransaction.cs
Entities/Finance/FinanceEntities.cs
Entities/Finance/OwnerTransaction.cs
Entities/Finance/TransactionSourcePolicy.cs
Entities/Inventory/Category.cs
Entities/Inventory/Department.cs
Entities/Inventory/Product.cs
Entities/Inventory/ProductBatch.cs
Entities/Inventory/ProductProperty.cs
Entities/Maintenance/MaintenanceDevice.cs
Entities/Maintenance/MaintenanceProductItem.cs
Entities/RefreshToken.cs
Entities/Returns/ReturnItem.cs
Entities/Returns/ReturnRecord.cs
Entities/Sales/Invoice.cs
Entities/Sales/InvoiceItem.cs
Entities/Suppliers/PurchaseInvoice.cs
Entities/Suppliers/PurchaseInvoiceItem.cs
Entities/Suppliers/Supplier.cs
Entities/Suppliers/SupplierPayment.cs
Entities/Suppliers/SupplierReturn.cs
Entities/Suppliers/SupplierReturnItem.cs
Entities/Wallets/Wallet.cs
Entities/Wallets/WalletOperation.cs
Entities/Wallets/WalletTransaction.cs
Errors/CategoryErrors.cs
Errors/CustomerErrors.cs
Errors/CustomerTransactionErrors.cs
Errors/DepartmentErrors.cs
Errors/DrawerErrors.cs
Errors/ExpenseErrors.cs
Errors/FinancePolicyErrors.cs
Errors/MaintenanceErrors.cs
Errors/ProductErrors.cs
Errors/PurchaseInvoiceErrors.cs
Errors/RoleErrors.cs
Errors/SafeErrors.cs
Errors/SalesInvoiceErrors.cs
Errors/SalesReturnErrors.cs
Errors/SupplierErrors.cs
Errors/SupplierTransactionErrors.cs
Errors/TransactionRouterErrors.cs
Errors/UserErrors.cs
Errors/WalletErrors.cs
Extensions/QueryableFilterExtensions.cs
Extensions/UserExtensions.cs
fix_drawer.csx
GlobalUsings.cs
Helpers/FileHelper.cs
Mappings/CategoryMapping.cs
Mappings/DepartmentMapping.cs
Mappings/FinanceMapping.cs
Mappings/ProductMapping.cs
Mappings/PurchasingMapping.cs
Mappings/SalesMapping.cs
Mappings/WalletMapping.cs
Middlewares/GlobalCancellationMiddleware.cs
Options/JwtOptions.cs
Persistence/ApplicationDbContext.cs
Persistence/EntitiesConfigurations/CategoryConfiguration.cs
Persistence/EntitiesConfigurations/CustomerConfiguration.cs
Persistence/EntitiesConfigurations/CustomerDebtPaymentConfiguration.cs
Persistence/EntitiesConfigurations/DepartmentConfiguration.cs
Persistence/EntitiesConfigurations/DrawerSessionConfiguration.cs
Persistence/EntitiesConfigurations/DrawerTransactionConfiguration.cs
Persistence/EntitiesConfigurations/InvoiceConfiguration.cs
Persistence/EntitiesConfigurations/InvoiceItemConfiguration.cs
Persistence/EntitiesConfigurations/MaintenanceDeviceConfiguration.cs
Persistence/EntitiesConfigurations/MaintenanceProductItemConfiguration.cs
Persistence/EntitiesConfigurations/ProductConfiguration.cs
Persistence/EntitiesConfigurations/PurchaseInvoiceConfiguration.cs
Persistence/EntitiesConfigurations/PurchaseInvoiceItemConfiguration.cs
Persistence/EntitiesConfigurations/ReturnItemConfiguration.cs
Persistence/EntitiesConfigurations/ReturnRecordConfiguration.cs
Persistence/EntitiesConfigurations/RoleConfiguration.cs
Persistence/EntitiesConfigurations/SupplierConfiguration.cs
Persistence/EntitiesConfigurations/SupplierPaymentConfiguration.cs
Persistence/EntitiesConfigurations/SupplierReturnConfiguration.cs
Persistence/EntitiesConfigurations/SupplierReturnItemConfiguration.cs
Persistence/EntitiesConfigurations/UserConfiguration.cs
Persistence/EntitiesConfigurations/UserRoleConfiguration.cs
Program.cs
Properties/launchSettings.json
repomix.config.json
restore.py
script.csx
Services/Abstraction/IAuthService.cs
Services/Abstraction/ICategoryService.cs
Services/Abstraction/ICustomerService.cs
Services/Abstraction/ICustomerTransactionService.cs
Services/Abstraction/IDepartmentService.cs
Services/Abstraction/IDrawerService.cs
Services/Abstraction/IExpenseService.cs
Services/Abstraction/IFinancePolicyService.cs
Services/Abstraction/IMaintenanceService.cs
Services/Abstraction/IOwnerTransactionService.cs
Services/Abstraction/IProductService.cs
Services/Abstraction/IPurchaseInvoiceService.cs
Services/Abstraction/IReturnProcessingService.cs
Services/Abstraction/IRoleService.cs
Services/Abstraction/ISafeService.cs
Services/Abstraction/ISalesInvoiceService.cs
Services/Abstraction/ISalesReturnService.cs
Services/Abstraction/ISupplierService.cs
Services/Abstraction/ISupplierTransactionService.cs
Services/Abstraction/ITransactionRouterService.cs
Services/Abstraction/IUserService.cs
Services/Abstraction/IWalletService.cs
Services/Abstractions/IExpenseService.cs
Services/Implementation/AuthService.cs
Services/Implementation/CategoryService.cs
Services/Implementation/CustomerService.cs
Services/Implementation/CustomerTransactionService.cs
Services/Implementation/DepartmentService.cs
Services/Implementation/DrawerService.cs
Services/Implementation/ExpenseService.cs
Services/Implementation/FinancePolicyService.cs
Services/Implementation/MaintenanceService.cs
Services/Implementation/OwnerTransactionService.cs
Services/Implementation/ProductService.cs
Services/Implementation/PurchaseInvoiceService.cs
Services/Implementation/ReturnProcessingService.cs
Services/Implementation/RoleService.cs
Services/Implementation/SafeService.cs
Services/Implementation/SalesInvoiceService.cs
Services/Implementation/SalesReturnService.cs
Services/Implementation/SupplierService.cs
Services/Implementation/SupplierTransactionService.cs
Services/Implementation/TransactionRouterService.cs
Services/Implementation/UserService.cs
Services/Implementation/WalletService.cs
Services/Implementation/WalletService.Part2.cs
update_maintenance.csx
WeatherForecast.cs
```

# Files

## File: Abstractions/Consts/DefaultRoles.cs
```csharp
namespace Centraly.Api.Abstractions.Consts;

public static class DefaultRoles
{
    public partial class Admin
    {
        public const string Name = nameof(Admin);
        public const string Id = "0191a4b6-c4fc-752e-9d95-40b5e4e68054";
        public const string ConcurrencyStamp = "0191a4b6-c4fc-752e-9d95-40b631d1866d";
    }
    public partial class Manager
    {
        public const string Name = nameof(Manager);
        public const string Id = "6340d7c9-5aba-483f-90ad-29979e56999b";
        public const string ConcurrencyStamp = "fb6de3d0-ca0a-44d4-97d4-03caa996184a";
    }

    public partial class Salesperson
    {
        public const string Name = nameof(Salesperson);
        public const string Id = "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0";
        public const string ConcurrencyStamp = "0191a4b6-c4fc-752e-9d95-40b85cf3fd22";
    }

    public partial class Technician
    {
        public const string Name = nameof(Technician);
        public const string Id = "4ec432f6-c564-4291-b079-98636f8b8b1d";
        public const string ConcurrencyStamp = "19a49e8c-9372-4b21-937b-9304b99a4d01";
    }
}
```

## File: Abstractions/Consts/DefaultSafe.cs
```csharp
namespace Centraly.Api.Abstractions.Consts;

public static class DefaultSafe
{
    public const string MainSafeId = "0191a4b6-c4fc-752e-9d95-40b900000001";
    public const string MainSafeName = "الخزينة الرئيسية";
}
```

## File: Abstractions/Consts/DefaultUsers.cs
```csharp
namespace Centraly.Api.Abstractions.Consts;

public static class DefaultUsers
{
    public partial class Admin
    {
        public const string Id = "0191a4b6-c4fc-752e-9d95-40b30fa7a9b6";
        public const string Email = "admin@gmail.com";
        public const string PasswordHash = "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==";//P@ssword123
        public const string SecurityStamp = "55BF92C9EF0249CDA210D85D1A851BC9";
        public const string ConcurrencyStamp = "0191a4b6-c4fc-752e-9d95-40b42a925b8e";
    }
    public partial class Manager
    {
        public const string Id = "517ab86b-fd99-438a-be09-6647986a5ca9";
        public const string Email = "manager@gmail.com";
        public const string PasswordHash = "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==";//P@ssword123
        public const string SecurityStamp = "4831b51a-68fc-40ed-90ac-815d0e218a24";
        public const string ConcurrencyStamp = "3ac4ffe0-30dd-433a-9212-088346bedcf6";
    }
    public partial class Salesperson
    {
        public const string Id = "aa146cf1-fbca-46cd-b63e-5f7c20b11703";
        public const string Email = "sales@gmail.com";
        public const string PasswordHash = "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==";//P@ssword123
        public const string SecurityStamp = "9a1bb131-a421-438d-b468-f5b59564f706";
        public const string ConcurrencyStamp = "37635289-2152-499a-982f-599964b8f80f";
    }
    public partial class Technician
    {
        public const string Id = "947aa516-7fd4-4864-95b1-40abf2d29a9f";
        public const string Email = "tech@gmail.com";
        public const string PasswordHash = "AQAAAAIAAYagAAAAEKRku5u6K325Irl1Utujiuil/WUhjTvShS9mJLXxO+2v/GKrMT1Ofhdp/0taFUO2bA==";//P@ssword123
        public const string SecurityStamp = "7cc9e897-ce48-49aa-926f-7831277b1d14";
        public const string ConcurrencyStamp = "ba02318d-c674-4ff5-b607-55e43cad9aff";
    }

}
```

## File: Abstractions/Consts/Permissions.cs
```csharp
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
```

## File: Abstractions/Consts/RegexPatterns.cs
```csharp
namespace Centraly.Api.Abstractions.Consts;

public static class RegexPatterns
{
    //public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string EgyptianPhonePattern =
    @"^(?:\+20|0)?1[0125][0-9]{8}$";
    public const string PasswordPattern = 
    "(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}";
}
```

## File: Abstractions/Error.cs
```csharp
namespace Centraly.Api.Abstractions;

public record Error(
    string Code,
    string Description,
    int? StatusCode
)
{
    public static readonly Error None = new(string.Empty, string.Empty, null);
}
```

## File: Abstractions/PaginatedList.cs
```csharp
namespace Centraly.Api.Abstractions;

public sealed class PaginatedList<T>
{
    public List<T> Items { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public int TotalPages { get; init; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public PaginatedList(List<T> items, int pageNumber, int pageSize, int totalCount)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);

        var totalCount = await source.CountAsync(cancellationToken);
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<T>(items, pageNumber, pageSize, totalCount);
    }

    // ✅ NEW: بتحوّل الـ Items لنوع تاني (زي DTO) بعد ما الداتا اتجابت فعليًا من الداتابيز
    // (client-side mapping — آمن للـ Enum casts اللي كانت بتكسر ترجمة SQL)
    public PaginatedList<TResult> Select<TResult>(Func<T, TResult> selector)
    {
        ArgumentNullException.ThrowIfNull(selector);

        var mappedItems = Items.Select(selector).ToList();
        return new PaginatedList<TResult>(mappedItems, PageNumber, PageSize, TotalCount);
    }
}
```

## File: Abstractions/Result.cs
```csharp
namespace Centraly.Api.Abstractions;

public class Result
{
    public Result(bool isSuccess,
        Error error
    )
    {
        if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Error = error;
    }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; } = default!;

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
}

public class Result<Tvalue> : Result
{
    private readonly Tvalue _value;
    public Result(Tvalue value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }
    public Tvalue Value => IsSuccess ? _value : throw new InvalidOperationException("Failure results cannot have value");
}
```

## File: Abstractions/ResultExtensions.cs
```csharp
using Microsoft.AspNetCore.Mvc;

namespace Centraly.Api.Abstractions;

public static class ResultExtensions
{
    public static ObjectResult ToProblem(this Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException("Cannot convert success result to a problem");

        var problem = Results.Problem(statusCode: result.Error.StatusCode);
        var problemDetails = problem.GetType().GetProperty(nameof(ProblemDetails))!.GetValue(problem) as ProblemDetails;

        problemDetails!.Extensions = new Dictionary<string, object?>
        {
            {
                "errors", new[]
                {
                    result.Error.Code,
                    result.Error.Description
                }
            }
        };

        return new ObjectResult(problemDetails);
    }
}
```

## File: appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

## File: appsettings.json
```json
{
  "AllowedOrigins": [
    "http://localhost:5173",
    "https://localhost:5173"
  ],
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "HangfireSettings": {
    "Username": "3lmny",
    "Password": "3lmny"
  },
  "Jwt": {
    "Key": "jjkjfhhhjfbghbdfgbdfgbhbdfhgbdhbjvhbk",
    "Issuer": "3lmny",
    "Audience": "3lmny users",
    "ExpiryMinutes": 90
  },
  //"ConnectionStrings": {
  //  "HangfireConnection": "Data Source=.\\Ahmed1;Initial Catalog=CentralyDB2;Integrated Security=True;Trust Server Certificate=True",
  //  "DefaultConnection": "Data Source=.\\Ahmed1;Initial Catalog=CentralyDB2;Integrated Security=True;Trust Server Certificate=True"
  //},
  "ConnectionStrings": {
    "HangfireConnection": "Server=db66712.public.databaseasp.net; Database=db66712; User Id=db66712; Password=5y-Sb!N7Bk9?; Encrypt=False; MultipleActiveResultSets=True;",
    "DefaultConnection": "Server=db66712.public.databaseasp.net; Database=db66712; User Id=db66712; Password=5y-Sb!N7Bk9?; Encrypt=False; MultipleActiveResultSets=True;"
  }
}
```

## File: Authentication/IJwtProvider.cs
```csharp
namespace Centraly.Api.Authentication;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles, IEnumerable<string> permissions);
    string? ValidateToken(string token, bool validateLifetime = true);
}
```

## File: Authentication/JwtProvider.cs
```csharp
namespace Centraly.Api.Authentication;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles, IEnumerable<string> permissions)
    {
        Claim[] claims = [
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Name, user.UserName!),
            new(JwtRegisteredClaimNames.Jti, Guid.CreateVersion7().ToString()),
            new(nameof(roles), JsonSerializer.Serialize(roles), JsonClaimValueTypes.JsonArray),
            new(nameof(permissions), JsonSerializer.Serialize(permissions), JsonClaimValueTypes.JsonArray)
        ];

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

        var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes),
            signingCredentials: singingCredentials
        );

        return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: _options.ExpiryMinutes * 60);
    }




    public string? ValidateToken(string token, bool validateLifetime = true)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = symmetricSecurityKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = validateLifetime, // ← السطر ده بس
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
        }
        catch
        {
            return null;
        }
    }

}
```

## File: Authorization/HasPermissionAttribute.cs
```csharp
using Microsoft.AspNetCore.Authorization;

namespace Centraly.Api.Authorization;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(policy: permission)
    {
    }
}
```

## File: Centraly.Api.http
```
@Centraly.Api_HostAddress = http://localhost:5081

GET {{Centraly.Api_HostAddress}}/weatherforecast/
Accept: application/json

###
```

## File: Contracts/Authentication/LoginRequest.cs
```csharp
namespace Centraly.Api.Contracts.Authentication;

public record LoginRequest
(
    string UserName,
    string Password
);
```

## File: Contracts/Authentication/LoginRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Authentication;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
```

## File: Contracts/Authentication/LoginResponse.cs
```csharp
namespace Centraly.Api.Contracts.Authentication;

public record LoginResponse
(
    string Id,
    string UserName,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime RefreshTokenExpiration,
    IEnumerable<string> Role,
    IEnumerable<string> Permissions
);
```

## File: Contracts/Authentication/RefreshTokenRequest.cs
```csharp
namespace Centraly.Api.Contracts.Authentication;

public record RefreshTokenRequest(
    string Token,
    string RefreshToken
);
```

## File: Contracts/Authentication/RefreshTokenRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Authentication;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}
```

## File: Contracts/Common/PagedResponse.cs
```csharp
namespace Centraly.Api.Contracts.Common;

public record PagedResponse<T>(
    IReadOnlyList<T> Items,
    int PageNumber,
    int PageSize,
    int TotalCount,
    int TotalPages
);
```

## File: Contracts/Common/PaginationFilter.cs
```csharp
namespace Centraly.Api.Contracts.Common;

public record PaginationFilter
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;

    public int PageNumber { get; init; } = 1;

    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public string? SearchValue { get; init; }
    public string? SortColumn { get; init; }
    public SortDirection SortDirection { get; init; } = SortDirection.Asc;
}
```

## File: Contracts/Common/RequestFilters.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Common;
public enum SortDirection
{
    Asc,
    Desc
}

public record RequestFilters
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;

    public int PageNumber { get; init; } = 1;

    public int PageSize
    {
        get => _pageSize;
        init => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public string? SearchValue { get; init; }
    public string? SortColumn { get; init; }
    public SortDirection SortDirection { get; init; } = SortDirection.Asc;

    // Filters for Inventory
    public string? CategoryId { get; init; }
    public string? DepartmentId { get; init; }
    public string? StockStatus { get; init; }
    public ProductUsageDto? Usage { get; init; }
    public ProductUsageDto? ExcludeUsage { get; init; }

    // Filters for Suppliers & Transactions
    public string? SupplierId { get; init; }
    public string? CustomerId { get; init; }
    public string? CustomerPhone { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string? Status { get; init; }
}
```

## File: Contracts/Customers/CreateCustomerRequest.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public record CreateCustomerRequest(
    string? Name,
    string? Phone
);
```

## File: Contracts/Customers/CreateCustomerRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Phone)
            .Matches(@"^01[0125][0-9]{8}$")
            .When(x => !string.IsNullOrWhiteSpace(x.Phone));
    }
}
```

## File: Contracts/Customers/CustomerDebtHistoryResponse.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public record CustomerDebtHistoryResponse(
    CustomerResponse Customer,
    IReadOnlyList<CustomerInvoiceSummary> DeferredInvoices,
    IReadOnlyList<CustomerDebtPaymentResponse> Payments
);
```

## File: Contracts/Customers/CustomerDebtPaymentResponse.cs
```csharp
using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Customers;

public record CustomerDebtPaymentResponse(
    string             PaymentId,
    CustomerSummary    Customer,
    decimal            Amount,
    DateTime           PaymentDate,
    string?            Notes
);
```

## File: Contracts/Customers/CustomerInvoiceSummary.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public record CustomerInvoiceSummary(
    string InvoiceId,
    string InvoiceNumber,
    decimal TotalAmount,
    decimal PaidAmount,
    decimal RemainingAmount,
    DateTime CreatedAt
);
```

## File: Contracts/Customers/CustomerPaymentRequests.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public record CreateCustomerPaymentRequest(
    decimal Amount,
    string? Notes,
    string? InvoiceId = null,
    Centraly.Api.Contracts.Shared.Enums.PaymentSource? PaymentSource = null
);

public record CustomerPaymentResponse(
    string Id,
    string CustomerId,
    decimal Amount,
    DateTime PaymentDate,
    string? Notes
);
```

## File: Contracts/Customers/CustomerResponse.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public record CustomerResponse(
    string   CustomerId,
    string?  Name,
    string?  Phone,
    decimal  DebtBalance,
    int      InvoicesCount,
    DateTime CreatedAt
);
```

## File: Contracts/Customers/CustomerStatementResponse.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public record CustomerStatementResponse(
    DateTime Date,
    string TransactionType, // "Invoice", "Payment", "Return"
    string TransactionId,
    decimal Debit,
    decimal Credit,
    decimal BalanceAfter,
    string? Notes
);
```

## File: Contracts/Customers/UpdateCustomerRequest.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public record UpdateCustomerRequest(
    string? Name,
    string? Phone
);
```

## File: Contracts/Customers/UpdateCustomerRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Customers;

public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Phone)
            .Matches(@"^01[0125][0-9]{8}$")
            .When(x => !string.IsNullOrWhiteSpace(x.Phone));
    }
}
```

## File: Contracts/Drawer/DrawerRequests.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Drawer;

public record OpenSessionRequest(decimal OpeningBalance, int Type = 1);

public record AddManualTransactionRequest(
    DrawerTransactionType Type,
    DrawerTransactionCategory Category,
    decimal Amount,
    string? Notes,
    string? Source
);
```

## File: Contracts/Drawer/DrawerResponses.cs
```csharp
namespace Centraly.Api.Contracts.Drawer;

public record DrawerTransactionResponse(
    string Id,
    DrawerTransactionType Type,
    DrawerTransactionCategory Category,
    decimal Amount,
    decimal Balance,
    string? Source,
    string? Notes,
    DateTime CreatedAt,
    string UserId
);

public record DrawerSessionResponse(
    string Id,
    int Type, // 1 = Sales, 2 = Maintenance (DrawerType)
    decimal OpeningBalance,
    DateTime OpenedAt,
    string OpenedByUserId,
    bool IsClosed,
    DateTime? ClosedAt,
    decimal? TotalIncome,
    decimal? TotalExpense,
    decimal? ClosingBalance,
    decimal? TotalProfit,
    IReadOnlyList<DrawerTransactionResponse> Transactions
);
```

## File: Contracts/Finance/AddManualSafeTransactionRequest.cs
```csharp
namespace Centraly.Api.Contracts.Finance;

using Centraly.Api.Contracts.Shared.Enums;

public record AddManualSafeTransactionRequest(DrawerTransactionType Type, SafeTransactionCategory Category, decimal Amount, string? Notes);
```

## File: Contracts/Finance/CreateOwnerTransactionRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Finance;

public class CreateOwnerTransactionRequestValidator : AbstractValidator<CreateOwnerTransactionRequest>
{
    public CreateOwnerTransactionRequestValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.Notes));
    }
}
```

## File: Contracts/Finance/FinanceContracts.cs
```csharp
using System;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Finance;

public record CreateSafeRequest(string Name, bool IsMain, decimal InitialBalance);
public record SafeDepositRequest(decimal Amount, string? Notes, string? Source);
public record SafeWithdrawalRequest(decimal Amount, string? Notes, string? Reason);
public record ReceiveDrawerDepositRequest(string DrawerSessionId, decimal Amount, string? Notes);

public record SafeResponse(string Id, string Name, decimal Balance, bool IsMain);
public record SafeTransactionResponse(string Id, string SafeId, string TransactionType, string Category, decimal Amount, decimal BalanceAfter, DateTime CreatedAt, string? Notes);

public record CreateExpenseCategoryRequest(string Name);
public record CreateExpenseRequest(string CategoryId, decimal Amount, PaymentSource? PaymentSource, string? Notes);

public record ExpenseCategoryResponse(string Id, string Name);
public record ExpenseResponse(string Id, string CategoryId, string CategoryName, decimal Amount, string PaymentSource, DateTime ExpenseDate, string? Notes);

public record UpdateTransactionPolicyRequest(PaymentSourcePolicy AllowedSource);
public record TransactionPolicyResponse(string Id, string Category, string AllowedSource);
```

## File: Contracts/Finance/FinanceFilters.cs
```csharp
namespace Centraly.Api.Contracts.Finance;

using Centraly.Api.Contracts.Shared;

public record FinanceFilters : PaginationFilter
{
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}
```

## File: Contracts/Finance/OwnerRequests.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Finance;

public record CreateOwnerTransactionRequest(
    GlobalTransactionCategory Category,
    decimal Amount,
    PaymentSource PaymentSource,
    string? Notes
);
```

## File: Contracts/Finance/OwnerResponses.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Finance;

public record OwnerTransactionResponse(
    string Id,
    GlobalTransactionCategory Category,
    decimal Amount,
    PaymentSource PaymentSource,
    string? Notes,
    DateTime CreatedAt,
    string? CreatedByUserId
);
```

## File: Contracts/Inventory/Categories/CategoryResponse.cs
```csharp
using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Inventory.Categories;

public record CategoryResponse(
    string             CategoryId,
    string             Name,
    DepartmentSummary  Department,
    int                ProductsCount,
    DateTime           CreatedAt
);
```

## File: Contracts/Inventory/Categories/CreateCategoryRequest.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Categories;

public record CreateCategoryRequest(
    string Name,
    string DepartmentId
);
```

## File: Contracts/Inventory/Categories/CreateCategoryRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);

        RuleFor(x => x.DepartmentId)
            .NotEmpty();
    }
}
```

## File: Contracts/Inventory/Categories/UpdateCategoryRequest.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Categories;

public record UpdateCategoryRequest(
    string Name,
    string DepartmentId
);
```

## File: Contracts/Inventory/Categories/UpdateCategoryRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Categories;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);

        RuleFor(x => x.DepartmentId)
            .NotEmpty();
    }
}
```

## File: Contracts/Inventory/Departments/CreateDepartmentRequest.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Departments;

public record CreateDepartmentRequest(//Add
    string Name
);
```

## File: Contracts/Inventory/Departments/CreateDepartmentRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Departments;

public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>
{
    public CreateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);
    }
}
```

## File: Contracts/Inventory/Departments/DepartmentResponse.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Departments;

public record DepartmentResponse(//Get //Add
    string DepartmentId,
    string Name,
    int CategoriesCount,
    int ProductsCount,
    DateTime CreatedAt
);
```

## File: Contracts/Inventory/Departments/UpdateDepartmentRequest.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Departments;

public record UpdateDepartmentRequest(
    string Name
);
```

## File: Contracts/Inventory/Departments/UpdateDepartmentRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Departments;

public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
{
    public UpdateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 150);
    }
}
```

## File: Contracts/Inventory/Products/AdjustProductQuantityRequest.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Products;

/// <summary>
/// ØªØµØ­ÙŠØ­ ÙŠØ¯ÙˆÙŠ Ù„ÙƒÙ…ÙŠØ© Ø§Ù„Ù…Ø®Ø²ÙˆÙ† (Ø¬Ø±Ø¯ Ù Ø¹Ù„ÙŠ) Ù„Ø¯Ù Ø¹Ø© Ù…Ø­Ø¯Ø¯Ø©
/// </summary>
public record AdjustProductQuantityRequest(
    string  BatchId,
    int     NewQuantity,
    string? Reason
);
```

## File: Contracts/Inventory/Products/AdjustProductQuantityRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Inventory.Products;

public class AdjustProductQuantityRequestValidator : AbstractValidator<AdjustProductQuantityRequest>
{
    public AdjustProductQuantityRequestValidator()
    {
        RuleFor(x => x.BatchId)
            .NotEmpty();

        RuleFor(x => x.NewQuantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Reason)
            .MaximumLength(300)
            .When(x => !string.IsNullOrWhiteSpace(x.Reason));
    }
}
```

## File: Contracts/Inventory/Products/CreateProductRequest.cs
```csharp
using Microsoft.AspNetCore.Http;
using Centraly.Api.Contracts.Shared.Enums;
namespace Centraly.Api.Contracts.Inventory.Products;

public record CreateProductRequest(
    string? Barcode,
    string? Name,
    string DepartmentId,
    string CategoryId,
    IFormFile? Image,
    int MinQuantityAlert,
    string? StorageLocation,
    ProductUsageDto Usage,
    Dictionary<string, string>? Properties
);
```

## File: Contracts/Inventory/Products/CreateProductRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Inventory.Products;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Barcode)
            .MaximumLength(64)
            .When(x => !string.IsNullOrWhiteSpace(x.Barcode));

        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.DepartmentId)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.MinQuantityAlert)
            .GreaterThanOrEqualTo(0);
    }
}
```

## File: Contracts/Inventory/Products/ProductResponse.cs
```csharp
using Centraly.Api.Contracts.Shared.Summaries;
using Centraly.Api.Contracts.Shared.Enums;
namespace Centraly.Api.Contracts.Inventory.Products;

public record ProductBatchResponse(
    string BatchId,
    string? SupplierId,
    string? SupplierName,
    int AvailableQuantity,
    decimal PurchasePrice,
    decimal WholesalePrice,
    decimal RetailPrice,
    decimal MaintenancePrice,
    DateTime DateReceived
);

public record ProductResponse(
    string ProductId,
    string? Barcode,
    string? Name,
    DepartmentSummary Department,
    CategorySummary Category,
    int TotalQuantity,
    string? ImageUrl,
    int MinQuantityAlert,
    string? StorageLocation,
    bool IsOutOfStock,
    bool IsLowStock,
    DateTime CreatedAt,
    ProductUsageDto Usage,
    Dictionary<string, string> Properties,
    List<ProductBatchResponse> Batches
);
```

## File: Contracts/Inventory/Products/ProductSupplierResponse.cs
```csharp
namespace Centraly.Api.Contracts.Inventory.Products;

public record ProductSupplierResponse(
    string   SupplierId,
    string   SupplierName,
    decimal  LastPurchasePrice,
    DateTime LastPurchaseDate,
    int      TotalQuantityPurchased
);
```

## File: Contracts/Inventory/Products/UpdateProductRequest.cs
```csharp
using Microsoft.AspNetCore.Http;
using Centraly.Api.Contracts.Shared.Enums;
namespace Centraly.Api.Contracts.Inventory.Products;

public record UpdateProductRequest(
    string? Barcode,
    string? Name,
    string DepartmentId,
    string CategoryId,
    IFormFile? Image,
    int MinQuantityAlert,
    string? StorageLocation,
    ProductUsageDto Usage,
    Dictionary<string, string>? Properties
);
```

## File: Contracts/Inventory/Products/UpdateProductRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Inventory.Products;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Barcode)
            .MaximumLength(64)
            .When(x => !string.IsNullOrWhiteSpace(x.Barcode));

        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.DepartmentId)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.MinQuantityAlert)
            .GreaterThanOrEqualTo(0);
    }
}
```

## File: Contracts/Maintenance/CreateMaintenanceRequest.cs
```csharp
namespace Centraly.Api.Contracts.Maintenance;

// Step 1: Quick ticket creation - minimal info only
public record CreateMaintenanceRequest(
    string CustomerName,
    string? CustomerPhone,
    string? CustomerId,
    string? DeviceDescription,   // optional: what device/item is being repaired
    string? Problem,             // optional: problem description
    decimal PaidAmount,          // advance payment, default 0
    DateTime? DeliveryDate);     // optional scheduled pickup time

// Step 2: Update ticket - add products + service price
public record UpdateMaintenanceRequest(
    string CustomerName,
    string? CustomerPhone,
    string? CustomerId,
    string? DeviceDescription,
    string? Problem,
    string? Solution,
    decimal ServicePrice,
    decimal PaidAmount,
    DateTime? DeliveryDate,
    List<UpdateMaintenanceProductItemRequest> ProductsUsed);

public record UpdateMaintenanceProductItemRequest(
    string ProductId,
    int Quantity,
    decimal MaintenancePrice);
```

## File: Contracts/Maintenance/MaintenanceProductItemDto.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Contracts.Maintenance;

public record MaintenanceProductItemDto(
    string ProductId,
    string ProductName,
    int Quantity,
    decimal MaintenancePrice,
    decimal CostPrice);
```

## File: Contracts/Maintenance/MaintenanceResponse.cs
```csharp
namespace Centraly.Api.Contracts.Maintenance;

public record MaintenanceResponse(
    string Id,
    string CustomerName,
    string? CustomerPhone,
    string? CustomerId,
    string? DeviceDescription,
    string? Problem,
    string? Solution,
    decimal ServicePrice,
    decimal TotalPartsPrice,
    decimal TotalPrice,
    decimal TotalCost,
    decimal PaidAmount,
    decimal RemainingAmount,
    DateTime? DeliveryDate,
    string Status,
    List<MaintenanceProductItemDto> ProductsUsed,
    DateTime CreatedAt);
```

## File: Contracts/Maintenance/MaintenanceSummary.cs
```csharp
namespace Centraly.Api.Contracts.Maintenance;

public record MaintenanceSummary(
    string Id,
    string CustomerName,
    string? CustomerPhone,
    string? DeviceDescription,
    string? Problem,
    decimal TotalPrice,
    decimal PaidAmount,
    decimal RemainingAmount,
    DateTime? DeliveryDate,
    string Status,
    DateTime CreatedAt);
```

## File: Contracts/Returns/CreateCustomerReturnRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Returns;

public class CreateCustomerReturnRequestValidator : AbstractValidator<CreateCustomerReturnRequest>
{
    public CreateCustomerReturnRequestValidator()
    {
        RuleFor(x => x.InvoiceId).NotEmpty();
        RuleFor(x => x.Reason).IsInEnum();
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));
        RuleFor(x => x.Items).NotNull().NotEmpty().WithMessage("Return must contain at least one item");
    }
}
```

## File: Contracts/Returns/CustomerReturnRequests.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Returns;

public record ReturnItemRequest(
    string ProductId,
    string BatchId,
    int Quantity,
    decimal UnitPrice
);

public record CreateCustomerReturnRequest(
    string InvoiceId,
    ReturnReasonDto Reason,
    string? Notes,
    bool IsCashRefund,
    IReadOnlyList<ReturnItemRequest> Items,
    PaymentSource? PaymentSource = null
);

public record ReturnItemResponse(
    string Id,
    string ProductId,
    string BatchId,
    int Quantity,
    decimal UnitPrice
);

public record ReturnRecordResponse(
    string Id,
    string InvoiceId,
    string InvoiceNumber,
    bool IsFullInvoiceReturn,
    ReturnReasonDto Reason,
    string? Notes,
    bool IsCashRefund,
    decimal TotalReturnedAmount,
    DateTime ReturnDate,
    IReadOnlyList<ReturnItemResponse> Items
);
```

## File: Contracts/Returns/SupplierReturnRequests.cs
```csharp

```

## File: Contracts/Roles/RoleDetailResponse.cs
```csharp
namespace Centraly.Api.Contracts.Roles;

public record RoleDetailResponse(
    string Id,
    string Name,
    bool IsDeleted,
    IEnumerable<string> Permissions
);
```

## File: Contracts/Roles/RoleRequest.cs
```csharp
namespace Centraly.Api.Contracts.Roles;

public record RoleRequest(
    string Name,
    IList<string> Permissions
);
```

## File: Contracts/Roles/RoleRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Roles;

public class RoleRequestValidator : AbstractValidator<RoleRequest>
{
    public RoleRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 200);

        RuleFor(x => x.Permissions)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Permissions)
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("You cannot add duplicated permissions for the same role")
            .When(x => x.Permissions != null);
    }
}
```

## File: Contracts/Roles/RoleResponse.cs
```csharp
namespace Centraly.Api.Contracts.Roles;

public record RoleResponse(
    string Id,
    string Name,
    bool IsDeleted
);
```

## File: Contracts/Sales/CreateInvoiceItemRequest.cs
```csharp
namespace Centraly.Api.Contracts.Sales;

public record CreateInvoiceItemRequest(
    string ProductId,
    int    Quantity
);
```

## File: Contracts/Sales/CreateSalesInvoiceRequest.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Sales;

public record CreateSalesInvoiceItemRequest(
    string ProductId,
    string BatchId,
    int Quantity,
    decimal SellingPrice
);

public record CreateSalesInvoiceRequest(
    string? CustomerId,
    string? CustomerName,
    string? CustomerPhone,
    SaleTypeDto SaleType,
    PaymentMethodDto PaymentMethod,
    decimal PaidAmount,
    string? Notes,
    IReadOnlyList<CreateSalesInvoiceItemRequest> Items,
    PaymentSource? PaymentSource = null
);
```

## File: Contracts/Sales/CreateSalesInvoiceRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Sales;

public class CreateSalesInvoiceItemRequestValidator : AbstractValidator<CreateSalesInvoiceItemRequest>
{
    public CreateSalesInvoiceItemRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.BatchId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.SellingPrice).GreaterThanOrEqualTo(0);
    }
}

public class CreateSalesInvoiceRequestValidator : AbstractValidator<CreateSalesInvoiceRequest>
{
    public CreateSalesInvoiceRequestValidator()
    {
        RuleFor(x => x.SaleType).IsInEnum();
        RuleFor(x => x.PaymentMethod).IsInEnum();
        RuleFor(x => x.PaidAmount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Notes).MaximumLength(500);
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Invoice must contain at least one item.");
            
        RuleForEach(x => x.Items).SetValidator(new CreateSalesInvoiceItemRequestValidator());
        
        // Ensure no duplicate batch in items
        RuleFor(x => x.Items)
            .Must(items => items.Select(i => i.BatchId).Distinct().Count() == items.Count)
            .When(x => x.Items != null && x.Items.Any())
            .WithMessage("Duplicate items found. Cannot add the same batch multiple times.");
    }
}
```

## File: Contracts/Sales/SalesInvoiceResponse.cs
```csharp
using Centraly.Api.Contracts.Customers;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Sales;

public record SalesInvoiceItemResponse(
    string Id,
    string ProductId,
    string ProductName,
    string BatchId,
    int Quantity,
    int ReturnedQuantity,
    decimal UnitPrice,
    decimal UnitCost,
    decimal LineTotal
);

public record SalesInvoiceResponse(
    string Id,
    string InvoiceNumber,
    CustomerSummary? Customer,
    SaleTypeDto SaleType,
    PaymentMethodDto PaymentMethod,
    decimal TotalAmount,
    decimal PaidAmount,
    decimal RemainingAmount,
    string? Notes,
    DateTime CreatedAt,
    bool HasReturns,
    IReadOnlyList<SalesInvoiceItemResponse> Items
);
```

## File: Contracts/Shared/Enums/DrawerTransactionCategoryDto.cs
```csharp
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
```

## File: Contracts/Shared/Enums/DrawerTransactionTypeDto.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Enums;

/// <summary>
/// Data transfer object for the DrawerTransactionType enum.
/// </summary>
public enum DrawerTransactionTypeDto
{
    Income = 1, // إيراد
    Expense = 2 // صادر
}
```

## File: Contracts/Shared/Enums/FinanceEnums.cs
```csharp
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
    CustomerPayment = 13
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
    WalletOperation = 14
}
```

## File: Contracts/Shared/Enums/MaintenanceStatusDto.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Enums;

/// <summary>
/// Data transfer object for the MaintenanceStatus enum.
/// </summary>
public enum MaintenanceStatusDto
{
    Pending = 1,   // معلق
    Delivered = 2, // تم التسليم
    Returned = 3   // مرتجع
}
```

## File: Contracts/Shared/Enums/PaymentMethodDto.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Enums;

/// <summary>
/// Data transfer object for the PaymentMethod enum.
/// </summary>
public enum PaymentMethodDto
{
    Cash = 1,     // كاش
    Deferred = 2  // آجل / مديونية
}
```

## File: Contracts/Shared/Enums/ProductUsageDto.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Enums;

public enum ProductUsageDto
{
    SaleOnly = 1,
    MaintenanceOnly = 2,
    SaleAndMaintenance = 3
}
```

## File: Contracts/Shared/Enums/ReturnReasonDto.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Enums;

/// <summary>
/// Data transfer object for the ReturnReason enum.
/// </summary>
public enum ReturnReasonDto
{
    Defect = 1,      // عطل
    ChangedMind = 2, // تغيير رأي
    Other = 3        // سبب آخر
}
```

## File: Contracts/Shared/Enums/SaleTypeDto.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Enums;

/// <summary>
/// Data transfer object for the SaleType enum.
/// </summary>
public enum SaleTypeDto
{
    Wholesale = 1, // جملة
    Retail = 2     // تجزئة
}
```

## File: Contracts/Shared/Summaries/CategorySummary.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Summaries;

public record CategorySummary(
    string CategoryId,
    string Name
);
```

## File: Contracts/Shared/Summaries/CustomerSummary.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Summaries;

public record CustomerSummary(
    string  CustomerId,
    string? Name,
    string? Phone
);
```

## File: Contracts/Shared/Summaries/DepartmentSummary.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Summaries;

public record DepartmentSummary(
    string DepartmentId,
    string Name
);
```

## File: Contracts/Shared/Summaries/DrawerSessionSummary.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Summaries;

public record DrawerSessionSummary(
    string   DrawerSessionId,
    DateTime OpenedAt,
    bool     IsClosed
);
```

## File: Contracts/Shared/Summaries/ProductSummary.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Summaries;

public record ProductSummary(
    string  ProductId,
    string? Name,
    string? Barcode,
    string? ImageUrl,
    decimal RetailPrice,
    decimal? WholesalePrice,
    int     Quantity
);
```

## File: Contracts/Shared/Summaries/SupplierSummary.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Summaries;

public record SupplierSummary(
    string  SupplierId,
    string  Name,
    string? Phone
);
```

## File: Contracts/Shared/Summaries/UserSummary.cs
```csharp
namespace Centraly.Api.Contracts.Shared.Summaries;

public record UserSummary(
    string  UserId,
    string  UserName,
    string? Email
);
```

## File: Contracts/Suppliers/CreatePurchaseInvoiceItemRequest.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public record CreatePurchaseInvoiceItemRequest(
    string ProductId,
    int Quantity,
    decimal UnitCost, // Purchase Price
    decimal WholesalePrice, // New Batch Wholesale Price
    decimal RetailPrice,     // New Batch Retail Price
    decimal? MaintenancePrice = null // Maintenance Price
);
```

## File: Contracts/Suppliers/CreatePurchaseInvoiceRequest.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Suppliers;

public record CreatePurchaseInvoiceRequest(
    string SupplierId,
    decimal PaidAmount,
    string? Notes,
    List<CreatePurchaseInvoiceItemRequest> Items,
    PaymentSource? PaymentSource = null
);
```

## File: Contracts/Suppliers/CreatePurchaseInvoiceRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public class CreatePurchaseInvoiceItemRequestValidator : AbstractValidator<CreatePurchaseInvoiceItemRequest>
{
    public CreatePurchaseInvoiceItemRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitCost).GreaterThanOrEqualTo(0);
    }
}

public class CreatePurchaseInvoiceRequestValidator : AbstractValidator<CreatePurchaseInvoiceRequest>
{
    public CreatePurchaseInvoiceRequestValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.PaidAmount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));

        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("Purchase invoice must contain at least one item");

        RuleForEach(x => x.Items).SetValidator(new CreatePurchaseInvoiceItemRequestValidator());

        RuleFor(x => x.Items)
            .Must(items => items.Select(i => i.ProductId).Distinct().Count() == items.Count)
            .WithMessage("You cannot add the same product twice in one purchase invoice")
            .When(x => x.Items != null);
    }
}
```

## File: Contracts/Suppliers/CreateSupplierPaymentRequest.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Suppliers;

public record CreateSupplierPaymentRequest(
    string  SupplierId,
    decimal Amount,
    string? Notes,
    PaymentSource? PaymentSource = null
);
```

## File: Contracts/Suppliers/CreateSupplierPaymentRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Suppliers;

public class CreateSupplierPaymentRequestValidator : AbstractValidator<CreateSupplierPaymentRequest>
{
    public CreateSupplierPaymentRequestValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.Amount).NotEqual(0).WithMessage("Payment amount must not be zero.");
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));
    }
}
```

## File: Contracts/Suppliers/CreateSupplierRequest.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public record CreateSupplierRequest(
    string  Name,
    string? Type,
    string? Phone,
    string? Address
);
```

## File: Contracts/Suppliers/CreateSupplierRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public class CreateSupplierRequestValidator : AbstractValidator<CreateSupplierRequest>
{
    public CreateSupplierRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(2, 150);
        RuleFor(x => x.Type).MaximumLength(100).When(x => !string.IsNullOrWhiteSpace(x.Type));
        RuleFor(x => x.Phone).Matches(@"^01[0125][0-9]{8}$").When(x => !string.IsNullOrWhiteSpace(x.Phone));
        RuleFor(x => x.Address).MaximumLength(300).When(x => !string.IsNullOrWhiteSpace(x.Address));
    }
}
```

## File: Contracts/Suppliers/CreateSupplierReturnRequest.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Contracts.Suppliers;

public record CreateSupplierReturnItemRequest(
    string  ProductId,
    string  BatchId,
    int     Quantity,
    decimal ReturnPrice
);

public record CreateSupplierReturnRequest(
    string                                         SupplierId,
    ReturnReasonDto                                Reason,
    string?                                        Notes,
    IReadOnlyList<CreateSupplierReturnItemRequest> Items
)
{
    public bool IsCashRefund { get; init; }
    public PaymentSource? PaymentSource { get; init; }
}
```

## File: Contracts/Suppliers/CreateSupplierReturnRequestValidator.cs
```csharp
using FluentValidation;

namespace Centraly.Api.Contracts.Suppliers;

public class CreateSupplierReturnItemRequestValidator : AbstractValidator<CreateSupplierReturnItemRequest>
{
    public CreateSupplierReturnItemRequestValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}

public class CreateSupplierReturnRequestValidator : AbstractValidator<CreateSupplierReturnRequest>
{
    public CreateSupplierReturnRequestValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.Reason).IsInEnum();
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Notes));

        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("Supplier return must contain at least one item");

        RuleForEach(x => x.Items).SetValidator(new CreateSupplierReturnItemRequestValidator());

        RuleFor(x => x.Items)
            .Must(items => items.Select(i => i.ProductId).Distinct().Count() == items.Count)
            .WithMessage("You cannot add the same product twice in one return")
            .When(x => x.Items != null);
    }
}
```

## File: Contracts/Suppliers/PurchaseInvoiceItemResponse.cs
```csharp
using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record PurchaseInvoiceItemResponse(
    string          PurchaseInvoiceItemId,
    ProductSummary  Product,
    int             Quantity,
    decimal         UnitCost,
    decimal         LineTotal
);
```

## File: Contracts/Suppliers/PurchaseInvoiceResponse.cs
```csharp
using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record PurchaseInvoiceResponse(
    string                                 PurchaseInvoiceId,
    string                                 InvoiceNumber,
    SupplierSummary                        Supplier,
    decimal                                TotalAmount,
    decimal                                PaidAmount,
    decimal                                RemainingAmount,
    DateTime                               InvoiceDate,
    string?                                Notes,
    IReadOnlyList<PurchaseInvoiceItemResponse> Items
);
```

## File: Contracts/Suppliers/SupplierBatchResponse.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public record SupplierBatchResponse(
    string  BatchId,
    string  ProductId,
    string? ProductName,
    string? Barcode,
    int     AvailableQuantity,
    decimal PurchasePrice,
    DateTime DateReceived
);
```

## File: Contracts/Suppliers/SupplierPaymentResponse.cs
```csharp
using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record SupplierPaymentResponse(
    string          SupplierPaymentId,
    SupplierSummary Supplier,
    decimal         Amount,
    DateTime        PaymentDate,
    string?         Notes
);
```

## File: Contracts/Suppliers/SupplierResponse.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public record SupplierResponse(
    string   SupplierId,
    string   Name,
    string?  Type,
    string?  Phone,
    string?  Address,
    decimal  DebtBalance,
    int      PurchaseInvoicesCount,
    int      ReturnsCount,
    DateTime CreatedAt
);
```

## File: Contracts/Suppliers/SupplierReturnResponse.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;
using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Suppliers;

public record SupplierReturnItemResponse(
    string          SupplierReturnItemId,
    ProductSummary  Product,
    int             Quantity,
    decimal         UnitCost,
    decimal         LineTotal
);

public record SupplierReturnResponse(
    string                                    SupplierReturnId,
    SupplierSummary                           Supplier,
    ReturnReasonDto                           Reason,
    string?                                   Notes,
    decimal                                   TotalReturnedAmount,
    DateTime                                  ReturnDate,
    IReadOnlyList<SupplierReturnItemResponse> Items
);
```

## File: Contracts/Suppliers/SupplierStatementItemResponse.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public record SupplierStatementItemResponse(
    DateTime Date,
    string TransactionType,
    string TransactionId,
    decimal Debit,
    decimal Credit,
    decimal BalanceAfter,
    string? Notes
);
```

## File: Contracts/Suppliers/UpdateSupplierRequest.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public record UpdateSupplierRequest(
    string  Name,
    string? Type,
    string? Phone,
    string? Address
);
```

## File: Contracts/Suppliers/UpdateSupplierRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Suppliers;

public class UpdateSupplierRequestValidator : AbstractValidator<UpdateSupplierRequest>
{
    public UpdateSupplierRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(2, 150);
        RuleFor(x => x.Type).MaximumLength(100).When(x => !string.IsNullOrWhiteSpace(x.Type));
        RuleFor(x => x.Phone).Matches(@"^01[0125][0-9]{8}$").When(x => !string.IsNullOrWhiteSpace(x.Phone));
        RuleFor(x => x.Address).MaximumLength(300).When(x => !string.IsNullOrWhiteSpace(x.Address));
    }
}
```

## File: Contracts/Users/CreateUserRequest.cs
```csharp
namespace Centraly.Api.Contracts.Users;

public record CreateUserRequest(
    string Username,
    string Password,
    IList<string> Roles
);
```

## File: Contracts/Users/CreateUserRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Users;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(100)
            .WithMessage("Username must not exceed 100 characters");

        RuleFor(x => x.Roles)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Roles)
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("You cannot add duplicated role for the same user")
            .When(x => x.Roles != null);
    }
}
```

## File: Contracts/Users/UpdateUserRequest.cs
```csharp
namespace Centraly.Api.Contracts.Users;

public record UpdateUserRequest(
    string Username,
    IList<string> Roles
);
```

## File: Contracts/Users/UpdateUserRequestValidator.cs
```csharp
namespace Centraly.Api.Contracts.Users;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(100)
            .WithMessage("Username must not exceed 100 characters");

        RuleFor(x => x.Roles)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Roles)
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("You cannot add duplicated role for the same user")
            .When(x => x.Roles != null);
    }
}
```

## File: Contracts/Users/UserResponse.cs
```csharp
namespace Centraly.Api.Contracts.Users;

public record UserResponse(
    string Id,
    string Username,
    IEnumerable<string> Roles
);
```

## File: Contracts/Wallets/WalletRequests.cs
```csharp
using Centraly.Api.Entities.Wallets;

namespace Centraly.Api.Contracts.Wallets;

public record CreateWalletRequest(string Name, string PhoneNumber, string? OwnerName, decimal InitialBalance, IFormFile Image);

public class CreateWalletRequestValidator : AbstractValidator<CreateWalletRequest>
{
    public CreateWalletRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.OwnerName).MaximumLength(100);
        RuleFor(x => x.InitialBalance).GreaterThanOrEqualTo(0);
    }
}

public record ProcessOperationRequest(
    string WalletId,
    WalletOperationType OperationType,
    decimal TransferredAmount,
    decimal PhysicalCashAmount,
    string? Notes);

public class ProcessOperationRequestValidator : AbstractValidator<ProcessOperationRequest>
{
    public ProcessOperationRequestValidator()
    {
        RuleFor(x => x.WalletId).NotEmpty();
        RuleFor(x => x.OperationType).IsInEnum();
        RuleFor(x => x.TransferredAmount).GreaterThan(0);
        RuleFor(x => x.PhysicalCashAmount).GreaterThan(0);
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}

public record UpdateWalletRequest(
    string Name, 
    string PhoneNumber, 
    string? OwnerName, 
    bool IsActive,
    IFormFile? Image);

public class UpdateWalletRequestValidator : AbstractValidator<UpdateWalletRequest>
{
    public UpdateWalletRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.OwnerName).MaximumLength(100);
    }
}

public record WalletOperationFilter : Centraly.Api.Contracts.Common.PaginationFilter
{
    public string? WalletId { get; init; }
    public WalletOperationType? OperationType { get; init; }
    public DateTime? DateFrom { get; init; }
    public DateTime? DateTo { get; init; }
}
```

## File: Contracts/Wallets/WalletResponses.cs
```csharp
using Centraly.Api.Entities.Wallets;

namespace Centraly.Api.Contracts.Wallets;

public record WalletResponse(
    string Id,
    string Name,
    string PhoneNumber, string? OwnerName,
    decimal Balance,
    string? ImageUrl,
    bool IsActive,
    DateTime CreatedAt);

public record WalletOperationResponse(
    string Id,
    string WalletId,
    WalletOperationType OperationType,
    decimal TransferredAmount,
    decimal PhysicalCashAmount,
    decimal Profit,
    string? DrawerTransactionId,
    DateTime CreatedAt);

public record WalletDetailsResponse(
    string Id,
    string Name,
    string PhoneNumber, 
    string? OwnerName,
    decimal Balance,
    string? ImageUrl,
    bool IsActive,
    DateTime CreatedAt,
    decimal NetProfit);

public record WalletOperationsSummaryResponse(decimal TotalProfit);
```

## File: Controllers/AuthController.cs
```csharp
using Centraly.Api.Services;

namespace Centraly.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(ILogger<AuthController> logger,
    IAuthService authService) : ControllerBase
{

    private readonly ILogger<AuthController> _logger = logger;
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var authResult = await _authService.LoginAsync(request, cancellationToken);
            return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }
    }

    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
            return result.IsSuccess ? Ok() : result.ToProblem();
        }
        catch (OperationCanceledException)
        {
            return StatusCode(499);
        }
    }

}
```

## File: Controllers/CategoryController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("categories")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request, CancellationToken ct)
    {
        var result = await _categoryService.AddCategoryAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetCategory(string id, CancellationToken ct)
    {
        var result = await _categoryService.GetCategoryAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetAllCategories([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _categoryService.GetAllCategoriesAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateCategory(string id, [FromBody] UpdateCategoryRequest request, CancellationToken ct)
    {
        var result = await _categoryService.UpdateCategoryAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteCategory(string id, CancellationToken ct)
    {
        var result = await _categoryService.DeleteCategoryAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/CustomerController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("customers")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]
public class CustomerController(ICustomerService _customerService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken ct)
    {
        var result = await _customerService.AddCustomerAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(string id, CancellationToken ct)
    {
        var result = await _customerService.GetCustomerAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _customerService.GetAllCustomersAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/debt-history")]
    public async Task<IActionResult> GetCustomerDebtHistory(string id, CancellationToken ct)
    {
        var result = await _customerService.GetCustomerWithDebtHistoryAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(string id, [FromBody] UpdateCustomerRequest request, CancellationToken ct)
    {
        var result = await _customerService.UpdateCustomerAsync(id, request, User.GetUserId(), ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteCustomer(string id, CancellationToken ct)
    {
        var result = await _customerService.DeleteCustomerAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/CustomerTransactionController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("customers/{customerId}/transactions")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]

public class CustomerTransactionController(ICustomerTransactionService _transactionService) : ControllerBase
{
    [HttpPost("payments")]
    public async Task<IActionResult> AddPayment(string customerId, [FromBody] CreateCustomerPaymentRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddPaymentAsync(customerId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("returns")]
    public async Task<IActionResult> AddReturn(string customerId, [FromBody] CreateCustomerReturnRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddReturnAsync(customerId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("statement")]
    public async Task<IActionResult> GetStatement(string customerId, CancellationToken ct)
    {
        var result = await _transactionService.GetCustomerStatementAsync(customerId, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}
```

## File: Controllers/DepartmentController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("departments")]
[ApiController]
public class DepartmentController(IDepartmentService _departmentService) : ControllerBase
{

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request, CancellationToken ct)
    {
        var result = await _departmentService.AddDepartmentAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetDepartment(string id, CancellationToken ct)
    {
        var result = await _departmentService.GetDepartmentAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetAllDepartments([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _departmentService.GetAllDepartmentsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateDepartment(string id, [FromBody] UpdateDepartmentRequest request, CancellationToken ct)
    {
        var result = await _departmentService.UpdateDepartmentAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteDepartment(string id, CancellationToken ct)
    {
        var result = await _departmentService.DeleteDepartmentAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/DrawerController.cs
```csharp
using Centraly.Api.Abstractions.Consts;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Drawer;
using Centraly.Api.Extensions;
using Centraly.Api.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Centraly.Api.Controllers;

[Route("drawers")]
[ApiController]
[Authorize]
public class DrawerController(IDrawerService _drawerService) : ControllerBase
{
    private bool IsDrawerAccessAllowed(int? requestedType)
    {
        if (User.IsInRole(DefaultRoles.Admin.Name) || User.IsInRole(DefaultRoles.Manager.Name)) return true;
        if (User.IsInRole(DefaultRoles.Salesperson.Name)) return requestedType == 1;
        if (User.IsInRole(DefaultRoles.Technician.Name)) return requestedType == 2;
        return false;
    }

    [HttpPost("open")]
    public async Task<IActionResult> OpenSession([FromBody] OpenSessionRequest request, CancellationToken ct)
    {
        if (!IsDrawerAccessAllowed(request.Type)) return Forbid();
        
        var result = await _drawerService.OpenSessionAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("close")]
    public async Task<IActionResult> CloseSession([FromQuery] int type = 1, CancellationToken ct = default)
    {
        if (!IsDrawerAccessAllowed(type)) return Forbid();
        
        var result = await _drawerService.CloseSessionAsync(type, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveSession([FromQuery] int type = 1, CancellationToken ct = default)
    {
        if (!IsDrawerAccessAllowed(type)) return Forbid();
        
        var result = await _drawerService.GetActiveSessionAsync(type, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost("transactions/manual")]
    public async Task<IActionResult> AddManualTransaction([FromBody] AddManualTransactionRequest request, CancellationToken ct)
    {
        // Category 1 is Sales/General, Category 2 is Maintenance
        var type = request.Category == DrawerTransactionCategory.Maintenance ? 2 : 1; 
        if (!IsDrawerAccessAllowed(type)) return Forbid();

        var result = await _drawerService.AddManualTransactionAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetSessionsHistory([FromQuery] RequestFilters filters, [FromQuery] int? type = null, CancellationToken ct = default)
    {
        if (type.HasValue && !IsDrawerAccessAllowed(type.Value)) return Forbid();
        
        // If type is null (requesting all), restrict it for restricted roles
        if (!type.HasValue && !User.IsInRole(DefaultRoles.Admin.Name) && !User.IsInRole(DefaultRoles.Manager.Name))
        {
            type = User.IsInRole(DefaultRoles.Technician.Name) ? 2 : 1;
        }

        var result = await _drawerService.GetSessionsHistoryAsync(filters, type, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("history/{id}")]
    public async Task<IActionResult> GetSessionById(string id, CancellationToken ct = default)
    {
        var result = await _drawerService.GetSessionByIdAsync(id, ct);
        if (!result.IsSuccess) return NotFound(result.Error);
        
        // Ensure they are allowed to see this specific session
        if (!IsDrawerAccessAllowed(result.Value.Type)) return Forbid();
        
        return Ok(result.Value);
    }
}
```

## File: Controllers/ExpenseController.cs
```csharp
using Centraly.Api.Contracts.Finance;
namespace Centraly.Api.Controllers;

[ApiController]
[Route("expenses")]
[Authorize]

public class ExpenseController(IExpenseService _expenseService) : ControllerBase
{
    [Authorize(Roles = "Admin,Manager")]
    [HttpPost("categories")]
    public async Task<IActionResult> CreateCategory(CreateExpenseCategoryRequest request, CancellationToken ct)
    {
        var result = await _expenseService.CreateExpenseCategoryAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories(CancellationToken ct)
    {
        var result = await _expenseService.GetExpenseCategoriesAsync(ct);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> RecordExpense(CreateExpenseRequest request, CancellationToken ct)
    {
        var result = await _expenseService.RecordExpenseAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses([FromQuery] FinanceFilters filters, CancellationToken ct)
    {
        var result = await _expenseService.GetExpensesAsync(filters, ct);
        return Ok(result.Value);
    }
}
```

## File: Controllers/FinancePolicyController.cs
```csharp
namespace Centraly.Api.Controllers;

[ApiController]
[Route("finance-policies")]
[Authorize(Roles = "Admin,Manager")]
public class FinancePolicyController(IFinancePolicyService _financePolicyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPoliciesAsync(CancellationToken ct)
    {
        var result = await _financePolicyService.GetPoliciesAsync(ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{category}")]
    public async Task<IActionResult> UpdatePolicyAsync(string category, [FromBody] UpdateTransactionPolicyRequest request, CancellationToken ct)
    {
        var result = await _financePolicyService.UpdatePolicyAsync(category, request, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/MaintenanceController.cs
```csharp
using Centraly.Api.Contracts.Maintenance;

namespace Centraly.Api.Controllers;

[Route("maintenance")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Technician")]
public class MaintenanceController(IMaintenanceService _maintenanceService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMaintenance([FromBody] CreateMaintenanceRequest request, CancellationToken ct)
    {
        var result = await _maintenanceService.CreateMaintenanceAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaintenance(string id, [FromBody] UpdateMaintenanceRequest request, CancellationToken ct)
    {
        var result = await _maintenanceService.UpdateMaintenanceAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{id}/deliver")]
    public async Task<IActionResult> DeliverMaintenance(string id, CancellationToken ct)
    {
        var result = await _maintenanceService.DeliverMaintenanceAsync(id, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{id}/return")]
    public async Task<IActionResult> ReturnMaintenance(string id, CancellationToken ct)
    {
        var result = await _maintenanceService.ReturnMaintenanceAsync(id, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMaintenance([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _maintenanceService.GetAllMaintenanceAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var result = await _maintenanceService.GetByIdAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}
```

## File: Controllers/OwnerTransactionController.cs
```csharp
namespace Centraly.Api.Controllers;

[ApiController]
[Route("ownerTransactions")]
[Authorize(Roles = "Admin,Manager")]
public class OwnerTransactionController(IOwnerTransactionService _ownerTransactionService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOwnerTransaction([FromBody] CreateOwnerTransactionRequest request, CancellationToken cancellationToken)
    {

        var result = await _ownerTransactionService.CreateOwnerTransactionAsync(request, User.GetUserId()!, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetOwnerTransactions(CancellationToken cancellationToken)
    {
        var result = await _ownerTransactionService.GetOwnerTransactionsAsync(cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/ProductController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("products")]
[ApiController]
public class ProductController(IProductService _productService) : ControllerBase
{
    [Authorize(Roles = "Admin,Manager")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request, CancellationToken ct)
    {
        var result = await _productService.AddProductAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetProduct(string id, CancellationToken ct)
    {
        var result = await _productService.GetProductAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetAllProducts([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _productService.GetAllProductsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/suppliers")]
    [Authorize(Roles = "Admin,Manager,Salesperson,Technician")]
    public async Task<IActionResult> GetProductSuppliers(string id, CancellationToken ct)
    {
        var result = await _productService.GetProductSuppliersAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateProduct(string id, [FromForm] UpdateProductRequest request, CancellationToken ct)
    {
        var result = await _productService.UpdateProductAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPatch("{id}/adjust-quantity")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> AdjustQuantity(string id, [FromBody] AdjustProductQuantityRequest request, CancellationToken ct)
    {
        var result = await _productService.AdjustQuantityAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteProduct(string id, CancellationToken ct)
    {
        var result = await _productService.DeleteProductAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/PurchaseInvoiceController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("purchase-invoices")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class PurchaseInvoiceController(IPurchaseInvoiceService _invoiceService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePurchaseInvoice([FromBody] CreatePurchaseInvoiceRequest request, CancellationToken ct)
    {
        var result = await _invoiceService.AddPurchaseInvoiceAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPurchaseInvoice(string id, CancellationToken ct)
    {
        var result = await _invoiceService.GetPurchaseInvoiceAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPurchaseInvoices([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _invoiceService.GetAllPurchaseInvoicesAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/RoleController.cs
```csharp
using Centraly.Api.Contracts.Roles;
using Centraly.Api.Services;

namespace Centraly.Api.Controllers;

[Route("roles")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class RoleController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [HttpGet]
    public async Task<IActionResult> GetAllRoles([FromQuery] bool includeDisabled, CancellationToken ct)
    {
        var roles = await _roleService.GetAllAsync(includeDisabled, ct);
        return Ok(roles);
    }

    [HttpGet("permissions")]
    public IActionResult GetAllPermissions()
    {
        return Ok(Permissions.GetAllPermissions());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(string id)
    {
        var result = await _roleService.GetAsync(id);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleRequest request)
    {
        var result = await _roleService.AddAsync(request);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleRequest request)
    {
        var result = await _roleService.UpdateAsync(id, request);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpPatch("{id}/toggle-status")]
    public async Task<IActionResult> ToggleRoleStatus(string id)
    {
        var result = await _roleService.ToggleStatusAsync(id);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
```

## File: Controllers/SafeController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("Safe")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class SafeController(ISafeService _safeService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateSafe(CreateSafeRequest request, CancellationToken ct)
    {
        var result = await _safeService.CreateSafeAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetSafes(CancellationToken ct)
    {
        var result = await _safeService.GetSafesAsync(ct);
        return Ok(result.Value);
    }

    [HttpPost("{safeId}/deposit")]
    public async Task<IActionResult> DepositFromDrawer(string safeId, ReceiveDrawerDepositRequest request, CancellationToken ct)
    {
        var result = await _safeService.DepositFromDrawerAsync(safeId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{safeId}/manual-transaction")]
    public async Task<IActionResult> AddManualTransaction(string safeId, [FromBody] AddManualSafeTransactionRequest request, CancellationToken ct)
    {
        var result = await _safeService.AddManualTransactionAsync(safeId, request.Type, request.Category, request.Amount, 0, request.Notes, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{safeId}/transactions")]
    public async Task<IActionResult> GetSafeTransactions(string safeId, [FromQuery] FinanceFilters filters, CancellationToken ct)
    {
        var result = await _safeService.GetSafeTransactionsAsync(safeId, filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/SalesInvoiceController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("sales-invoices")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]
public class SalesInvoiceController(ISalesInvoiceService _salesInvoiceService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddInvoice([FromBody] CreateSalesInvoiceRequest request, CancellationToken ct)
    {
        var result = await _salesInvoiceService.AddInvoiceAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoice(string id, CancellationToken ct)
    {
        var result = await _salesInvoiceService.GetInvoiceAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInvoices([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _salesInvoiceService.GetAllInvoicesAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/SalesReturnController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("sales-returns")]
[ApiController]
[Authorize(Roles = "Admin,Manager,Salesperson")]
public class SalesReturnController(ISalesReturnService _salesReturnService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddReturn([FromBody] CreateCustomerReturnRequest request, CancellationToken ct)
    {
        var result = await _salesReturnService.AddReturnAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReturn(string id, CancellationToken ct)
    {
        var result = await _salesReturnService.GetReturnAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReturns([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _salesReturnService.GetAllReturnsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/SupplierController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("suppliers")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class SupplierController(ISupplierService _supplierService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierRequest request, CancellationToken ct)
    {
        var result = await _supplierService.AddSupplierAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplier(string id, CancellationToken ct)
    {
        var result = await _supplierService.GetSupplierAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSuppliers([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _supplierService.GetAllSuppliersAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSupplier(string id, [FromBody] UpdateSupplierRequest request, CancellationToken ct)
    {
        var result = await _supplierService.UpdateSupplierAsync(id, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupplier(string id, CancellationToken ct)
    {
        var result = await _supplierService.DeleteSupplierAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/statement")]
    public async Task<IActionResult> GetSupplierStatement(string id, [FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _supplierService.GetSupplierStatementAsync(id, filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetSupplierAvailableBatches(string id, CancellationToken ct)
    {
        var result = await _supplierService.GetSupplierAvailableBatchesAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/SupplierTransactionController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("supplier-transactions")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class SupplierTransactionController(ISupplierTransactionService _transactionService) : ControllerBase
{


    [HttpPost("payments")]
    public async Task<IActionResult> CreatePayment([FromBody] CreateSupplierPaymentRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddPaymentAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("payments/{id}")]
    public async Task<IActionResult> GetPayment(string id, CancellationToken ct)
    {
        var result = await _transactionService.GetPaymentAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("payments")]
    public async Task<IActionResult> GetAllPayments([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _transactionService.GetAllPaymentsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }


    [HttpPost("returns")]
    public async Task<IActionResult> CreateReturn([FromBody] CreateSupplierReturnRequest request, CancellationToken ct)
    {
        var result = await _transactionService.AddReturnAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("returns/{id}")]
    public async Task<IActionResult> GetReturn(string id, CancellationToken ct)
    {
        var result = await _transactionService.GetReturnAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("returns")]
    public async Task<IActionResult> GetAllReturns([FromQuery] RequestFilters filters, CancellationToken ct)
    {
        var result = await _transactionService.GetAllReturnsAsync(filters, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Controllers/UserController.cs
```csharp
using Centraly.Api.Contracts.Users;
using Centraly.Api.Services;
namespace Centraly.Api.Controllers;

[Route("users")]
[ApiController]
[Authorize(Roles = "Admin,Manager")]
public class UserController(IUserService _userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken ct)
    {
        var users = await _userService.GetAllAsync(ct);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var result = await _userService.GetAsync(id);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken ct)
    {
        var result = await _userService.AddAsync(request, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequest request, CancellationToken ct)
    {
        var result = await _userService.UpdateAsync(id, request, ct);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
```

## File: Controllers/WalletsController.cs
```csharp
namespace Centraly.Api.Controllers;

[Route("wallets")]
[ApiController]
public class WalletsController(IWalletService _walletService) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetWallets([FromQuery] PaginationFilter filter, CancellationToken ct)
    {
        var result = await _walletService.GetAllWalletsAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> CreateWallet([FromForm] CreateWalletRequest request, CancellationToken ct)
    {
        var result = await _walletService.CreateWalletAsync(request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("{walletId}/operations")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]

    public async Task<IActionResult> ProcessOperation(
        [FromRoute] string walletId, [FromBody] ProcessOperationRequest request, CancellationToken ct)
    {
        var result = await _walletService.ProcessOperationAsync(request with { WalletId = walletId }, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{walletId}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateWallet(
        [FromRoute] string walletId, [FromForm] UpdateWalletRequest request, CancellationToken ct)
    {
        var result = await _walletService.UpdateWalletAsync(walletId, request, User.GetUserId()!, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{walletId}")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetWallet([FromRoute] string walletId, CancellationToken ct)
    {
        var result = await _walletService.GetWalletByIdAsync(walletId, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("operations")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetOperations([FromQuery] WalletOperationFilter filter, CancellationToken ct)
    {
        var result = await _walletService.GetWalletOperationsAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("operations/summary")]
    [Authorize(Roles = "Admin,Manager,Salesperson")]
    public async Task<IActionResult> GetOperationsSummary([FromQuery] WalletOperationFilter filter, CancellationToken ct)
    {
        var result = await _walletService.GetWalletOperationsSummaryAsync(filter, ct);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
```

## File: Dependencies.cs
```csharp
using Centraly.Api.Authentication;
using Centraly.Api.Services;
using Centraly.Api.Services.Abstraction;
using Centraly.Api.Services.Implementation;
using FluentValidation.AspNetCore;
using Hangfire;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Centraly.Api;

public static class Dependencies
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddControllers();
        services.AddOpenApi();

        services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
            )
        );
        services.AddAuthConfig(configuration);
        services
            .AddSwaggerService()
            .AddFluentValidationConfig()
            .AddMapsterConfig();


        services.Scan(scan => scan
            .FromAssemblyOf<AuthService>()
            .AddClasses(classes => classes
                .InNamespaces("Centraly.Api.Services"))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddScoped<ISalesReturnService, SalesReturnService>();
        services.AddScoped<IFinancePolicyService, FinancePolicyService>();
        services.AddScoped<ITransactionRouterService, TransactionRouterService>();
        services.AddScoped<IOwnerTransactionService, OwnerTransactionService>();
        services.AddScoped<IWalletService, WalletService>();


        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));
        services.AddBackgroundJobsConfig(configuration);

        return services;
    }

    private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
    {
        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMapper>(new Mapper(mappingConfig));
        return services;
    }
    private static IServiceCollection AddAuthConfig(this IServiceCollection services,
     IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddSingleton<IJwtProvider, JwtProvider>();

        services.AddOptions<JwtOptions>()
            .BindConfiguration(JwtOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var jwtSettings = configuration
            .GetSection(JwtOptions.SectionName)
            .Get<JwtOptions>();
        // ── Authentication pipeline ─────────────────────────────────────────
        var authBuilder = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings!.Key)),
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience
            };

            // ── SignalR JWT from Query String ───────────────────────────────
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];
                    var path = context.HttpContext.Request.Path;

                    if (!string.IsNullOrEmpty(accessToken) &&
                        path.StartsWithSegments("/hubs"))
                    {
                        context.Token = accessToken;
                    }

                    return Task.CompletedTask;
                }
            };
        });

        // ── Prevent cookie redirects on API endpoints → return 401/403 ─────
        services.ConfigureApplicationCookie(options =>
        {
            options.Events = new Microsoft.AspNetCore.Authentication.Cookies
                .CookieAuthenticationEvents
            {
                OnRedirectToLogin = ctx =>
                {
                    if (ctx.Request.Path.StartsWithSegments("/api") ||
                        ctx.Request.Headers["Accept"].ToString()
                           .Contains("application/json"))
                    {
                        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    }
                    ctx.Response.Redirect(ctx.RedirectUri);
                    return Task.CompletedTask;
                },
                OnRedirectToAccessDenied = ctx =>
                {
                    if (ctx.Request.Path.StartsWithSegments("/api") ||
                        ctx.Request.Headers["Accept"].ToString()
                           .Contains("application/json"))
                    {
                        ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return Task.CompletedTask;
                    }
                    ctx.Response.Redirect(ctx.RedirectUri);
                    return Task.CompletedTask;
                }
            };
        });

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            options.SignIn.RequireConfirmedEmail = true;
            options.User.RequireUniqueEmail = true;
        });

        return services;
    }


    private static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
    private static IServiceCollection AddBackgroundJobsConfig(this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));

        services.AddHangfireServer();

        return services;
    }
}
```

## File: dotnet-tools.json
```json
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "dotnet-ef": {
      "version": "10.0.11",
      "commands": [
        "dotnet-ef"
      ],
      "rollForward": false
    }
  }
}
```

## File: drop_wallets.sql
```sql
DROP TABLE IF EXISTS [WalletTransactions];
DROP TABLE IF EXISTS [WalletOperations];
DROP TABLE IF EXISTS [Wallets];
DELETE FROM [__EFMigrationsHistory] WHERE [MigrationId] LIKE '%Wallets%';
DELETE FROM [__EFMigrationsHistory] WHERE [MigrationId] LIKE '%WalletFields%';
```

## File: Entities/ApplicationRole.cs
```csharp
using Centraly.Api.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace Centraly.Api.Entities;

public class ApplicationRole : IdentityRole, ISoftDelete
{
    public ApplicationRole()
    {
        Id = Guid.CreateVersion7().ToString();
    }

    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
```

## File: Entities/ApplicationUser.cs
```csharp
namespace Centraly.Api.Entities;

public sealed class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {

        Id = Guid.CreateVersion7().ToString();
        SecurityStamp = Guid.CreateVersion7().ToString();
    }
    public List<RefreshToken> RefreshTokens { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
```

## File: Entities/Common/BaseEntity.cs
```csharp
namespace Centraly.Api.Entities.Common;

public abstract class BaseEntity : ISoftDelete
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedByUserId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedByUserId { get; set; }

    [NotMapped]
    public bool IsUpdated => UpdatedAt.HasValue;

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeletedAt { get; set; }
}
```

## File: Entities/Common/Enums.cs
```csharp
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
```

## File: Entities/Common/ISoftDelete.cs
```csharp
namespace Centraly.Api.Entities.Common;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}
```

## File: Entities/Customers/Customer.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Sales;
using Centraly.Api.Entities.Maintenance;

namespace Centraly.Api.Entities.Customers;

[Microsoft.EntityFrameworkCore.Index(nameof(Phone))]
public class Customer : BaseEntity
{

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public decimal DebtBalance { get; set; } = 0;   // المديونية الحالية

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public ICollection<CustomerDebtPayment> DebtPayments { get; set; } = new List<CustomerDebtPayment>();
    public ICollection<MaintenanceDevice> MaintenanceDevices { get; set; } = new List<MaintenanceDevice>();
}
```

## File: Entities/Customers/CustomerDebtPayment.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Customers;

public class CustomerDebtPayment : BaseEntity
{
    public string CustomerId { get; set; } = string.Empty;
    public Customer? Customer { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
```

## File: Entities/Drawer/DrawerSession.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Drawer;

public class DrawerSession : BaseEntity
{
    public DrawerType Type { get; set; } = DrawerType.Sales;

    public decimal OpeningBalance { get; set; }

    public DateTime OpenedAt { get; set; } = DateTime.UtcNow;

    public string OpenedByUserId { get; set; } = string.Empty;

    public bool IsClosed { get; set; } = false;

    public DateTime? ClosedAt { get; set; }
    public decimal? TotalIncome { get; set; }
    public decimal? TotalExpense { get; set; }
    public decimal? ClosingBalance { get; set; }
    public decimal RunningBalance { get; set; }
    public decimal? TotalProfit { get; set; }

    public ICollection<DrawerTransaction> Transactions { get; set; } = [];
}
```

## File: Entities/Drawer/DrawerTransaction.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Drawer;

public class DrawerTransaction : BaseEntity
{
    public string DrawerSessionId { get; set; } = string.Empty;
    public DrawerSession? DrawerSession { get; set; }

    public DrawerTransactionType Type { get; set; }         // إيراد / صادر
    public DrawerTransactionCategory Category { get; set; } // مبيعات/موردين/صيانة/مرتجعات/تشغيلية

    public decimal Amount { get; set; }
    public decimal Profit { get; set; }
    public decimal Balance { get; set; }   // الرصيد الجاري بعد الحركة دي
    public string? Source { get; set; }    // مصدر الحركة اليدوية (كتابة حرة)
    public string? Notes { get; set; }

    public string UserId { get; set; } = string.Empty;
}
```

## File: Entities/Finance/FinanceEntities.cs
```csharp
using Centraly.Api.Entities.Common;
using System;
using System.Collections.Generic;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Entities.Finance;

public class Safe : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public bool IsMain { get; set; }
    public ICollection<SafeTransaction> Transactions { get; set; } = new List<SafeTransaction>();
}

public class SafeTransaction : BaseEntity
{
    public string SafeId { get; set; } = string.Empty;
    public Safe? Safe { get; set; }
    public DrawerTransactionType TransactionType { get; set; }
    public SafeTransactionCategory Category { get; set; }
    public decimal Amount { get; set; }
    public decimal Profit { get; set; }
    public decimal BalanceAfter { get; set; }
    public string? Notes { get; set; }
    public string? CreatedByUserId { get; set; }
}

public class ExpenseCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}

public class Expense : BaseEntity
{
    public string CategoryId { get; set; } = string.Empty;
    public ExpenseCategory? Category { get; set; }
    public decimal Amount { get; set; }
    public decimal Profit { get; set; }
    public PaymentSource PaymentSource { get; set; }
    public string? SourceTransactionId { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string? Notes { get; set; }
    public string? CreatedByUserId { get; set; }
}
```

## File: Entities/Finance/OwnerTransaction.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Finance;

public class OwnerTransaction : BaseEntity
{
    public GlobalTransactionCategory Category { get; set; }
    public decimal Amount { get; set; }
    public PaymentSource PaymentSource { get; set; }
    public string? Notes { get; set; }
}
```

## File: Entities/Finance/TransactionSourcePolicy.cs
```csharp
using Centraly.Api.Contracts.Shared.Enums;
using System;

namespace Centraly.Api.Entities.Finance;

public class TransactionSourcePolicy
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public GlobalTransactionCategory Category { get; set; }
    public PaymentSourcePolicy AllowedSource { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```

## File: Entities/Inventory/Category.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Inventory;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Fix: كان string? (اختياري) وده بيسمح بتصنيف من غير قسم - بقى إلزامي
    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}
```

## File: Entities/Inventory/Department.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Inventory;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
}
```

## File: Entities/Inventory/Product.cs
```csharp
using Centraly.Api.Entities.Returns;
using Centraly.Api.Entities.Sales;
using Centraly.Api.Entities.Suppliers;
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Inventory;

[Microsoft.EntityFrameworkCore.Index(nameof(Barcode))]
public class Product : BaseEntity
{
    public string? Barcode { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;

    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }

    public string CategoryId { get; set; } = string.Empty;
    public Category? Category { get; set; }

    public ProductUsage Usage { get; set; } = ProductUsage.SaleOnly;

    public int Quantity { get; set; } // Representing Total Available Quantity across all batches
    public string? ImageUrl { get; set; }

    public int MinQuantityAlert { get; set; }
    [System.ComponentModel.DataAnnotations.Timestamp] public byte[] Version { get; set; } = null!;
    public string? StorageLocation { get; set; }

    [NotMapped]
    public bool IsOutOfStock => Quantity <= 0;

    [NotMapped]
    public bool IsLowStock => Quantity > 0 && Quantity <= MinQuantityAlert;

    public ICollection<ProductBatch> Batches { get; set; } = new List<ProductBatch>();
    public ICollection<ProductProperty> Properties { get; set; } = new List<ProductProperty>();

    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    public ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();
    public ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = new List<PurchaseInvoiceItem>();
    public ICollection<SupplierReturnItem> SupplierReturnItems { get; set; } = new List<SupplierReturnItem>();
}
```

## File: Entities/Inventory/ProductBatch.cs
```csharp
using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Entities.Inventory;

public class ProductBatch : BaseEntity
{
    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    // How many units were initially bought in this batch
    public int InitialQuantity { get; set; }

    // How many units are still available for sale from this batch
    public int AvailableQuantity { get; set; }
    [System.ComponentModel.DataAnnotations.Timestamp] public byte[] Version { get; set; } = null!;

    public decimal PurchasePrice { get; set; }
    public decimal WholesalePrice { get; set; }
    public decimal RetailPrice { get; set; }
    public decimal MaintenancePrice { get; set; }   // Ø³Ø¹Ø± Ø§Ù„ØµÙŠØ§Ù†Ø© (Ù„Ù„Ù…Ù†ØªØ¬Ø§Øª Ø°Ø§Øª Ø§Ù„ØµÙŠØ§Ù†Ø©)

    public DateTime DateReceived { get; set; }
}
```

## File: Entities/Inventory/ProductProperty.cs
```csharp
namespace Centraly.Api.Entities.Inventory;

public class ProductProperty : BaseEntity
{
    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
```

## File: Entities/Maintenance/MaintenanceDevice.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Customers;
using Centraly.Api.Entities.Drawer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centraly.Api.Entities.Maintenance;

[Microsoft.EntityFrameworkCore.Index(nameof(Status))]
public class MaintenanceDevice : BaseEntity
{
    public string CustomerName { get; set; } = string.Empty;
    public string? CustomerPhone { get; set; }

    public string? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    // Optional description of the device being repaired
    public string? DeviceDescription { get; set; }
    public string? Problem { get; set; }
    public string? Solution { get; set; }

    // Financials
    public decimal ServicePrice { get; set; }
    public decimal TotalPartsPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalCost { get; set; } // COGS of parts
    public decimal PaidAmount { get; set; }

    [NotMapped]
    public decimal RemainingAmount => TotalPrice - PaidAmount;

    public DateTime? DeliveryDate { get; set; }

    public MaintenanceStatus Status { get; set; } = MaintenanceStatus.Pending;

    public ICollection<MaintenanceProductItem> ProductsUsed { get; set; } = [];

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
```

## File: Entities/Maintenance/MaintenanceProductItem.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Maintenance;

public class MaintenanceProductItem : BaseEntity
{
    public string MaintenanceDeviceId { get; set; } = string.Empty;
    public MaintenanceDevice? MaintenanceDevice { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    
    public decimal MaintenancePrice { get; set; } // Price charged to the customer
    public decimal CostPrice { get; set; } // Calculated from FIFO batches upon delivery
}
```

## File: Entities/RefreshToken.cs
```csharp
namespace Centraly.Api.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresOn { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? RevokedOn { get; set; }

    public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
    public bool IsActive => RevokedOn is null && !IsExpired;
}
```

## File: Entities/Returns/ReturnItem.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Returns;

public class ReturnItem : BaseEntity
{
    public string ReturnRecordId { get; set; } = string.Empty;
    public ReturnRecord? ReturnRecord { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string BatchId { get; set; } = string.Empty;
    public ProductBatch? Batch { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
```

## File: Entities/Returns/ReturnRecord.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Sales;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Returns;

public class ReturnRecord : BaseEntity
{
    public string InvoiceId { get; set; } = string.Empty;
    public Invoice? Invoice { get; set; }

    public bool IsFullInvoiceReturn { get; set; }

    public ReturnReason Reason { get; set; }

    public string? Notes { get; set; }

    public decimal TotalReturnedAmount { get; set; }

    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;

    public ICollection<ReturnItem> Items { get; set; } = new List<ReturnItem>();

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
```

## File: Entities/Sales/Invoice.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Customers;
using Centraly.Api.Entities.Returns;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Sales;

[Microsoft.EntityFrameworkCore.Index(nameof(CreatedAt))]
public class Invoice : BaseEntity
{

    public string InvoiceNumber { get; set; } = string.Empty;

    public string? CustomerId { get; set; }     // Ù…Ù…ÙƒÙ† Ø¨ÙŠØ¹ Ø¨Ø¯ÙˆÙ† Ø¹Ù…ÙŠÙ„
    public Customer? Customer { get; set; }

    public SaleType SaleType { get; set; }        // Ø¬Ù…Ù„Ø© / ØªØ¬Ø²Ø¦Ø©
    public PaymentMethod PaymentMethod { get; set; }  // ÙƒØ§Ø´ / Ø¢Ø¬Ù„

    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RecordedProfit { get; set; }

    [NotMapped]
    public decimal RemainingAmount => TotalAmount - PaidAmount;   // = Ù…Ø¯ÙŠÙˆÙ†ÙŠØ© Ù„Ùˆ Ø¯ÙØ¹ Ø£Ù‚Ù„ Ù…Ù† Ø§Ù„Ø¥Ø¬Ù…Ø§Ù„ÙŠ

    public string? Notes { get; set; }
    public string UserId { get; set; } = string.Empty;          // Ø§Ù„Ù…ÙˆØ¸Ù/Ø§Ù„Ù…Ø³ØªØ®Ø¯Ù… Ø§Ù„Ø°ÙŠ Ø£Ù†Ø´Ø£ Ø§Ù„ÙØ§ØªÙˆØ±Ø©

    public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public ICollection<ReturnRecord> Returns { get; set; } = new List<ReturnRecord>();

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
```

## File: Entities/Sales/InvoiceItem.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Sales;

public class InvoiceItem : BaseEntity
{
    public string InvoiceId { get; set; } = string.Empty;
    public Invoice? Invoice { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public string BatchId { get; set; } = string.Empty;
    public ProductBatch? Batch { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }     // Ø§Ù„Ø³Ø¹Ø± ÙˆÙ‚Øª Ø§Ù„Ø¨ÙŠØ¹ (Ø¬Ù…Ù„Ø©/ØªØ¬Ø²Ø¦Ø©)

    public decimal UnitCost { get; set; }      // Ø³Ø¹Ø± Ø§Ù„Ø´Ø±Ø§Ø¡ ÙˆÙ‚Øª Ø§Ù„Ø¨ÙŠØ¹ (Ù„Ø­Ø³Ø§Ø¨ Ø§Ù„Ø±Ø¨Ø­ Ù„Ø§Ø­Ù‚Ø§Ù‹)

    [NotMapped]
    public decimal LineTotal => Quantity * UnitPrice;
}
```

## File: Entities/Suppliers/PurchaseInvoice.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Suppliers;

// فاتورة توريد: كل مرة تجيب بضاعة من مورد، بتتسجل هنا يدويًا بمعرفة المدير
public class PurchaseInvoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty;

    public string SupplierId { get; set; } = string.Empty;
    public Supplier? Supplier { get; set; }

    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }

    [NotMapped]
    public decimal RemainingAmount => TotalAmount - PaidAmount;   // = بيتضاف على مديونية المورد

    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public ICollection<PurchaseInvoiceItem> Items { get; set; } = [];

    // لو دفعت جزء أو كل المبلغ كاش وقت التوريد نفسه
    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
```

## File: Entities/Suppliers/PurchaseInvoiceItem.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Suppliers;

public class PurchaseInvoiceItem : BaseEntity
{
    public string PurchaseInvoiceId { get; set; } = string.Empty;
    public PurchaseInvoice? PurchaseInvoice { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public int Quantity { get; set; }              // الكمية اللي دخلت المخزون

    public decimal UnitCost { get; set; }           // سعر الشراء وقت التوريد (بيحدّث Product.PurchasePrice)

    [NotMapped]
    public decimal LineTotal => Quantity * UnitCost;
}
```

## File: Entities/Suppliers/Supplier.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Suppliers;

public class Supplier : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Type { get; set; }        // نوع المورد

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public decimal DebtBalance { get; set; } = 0;   // المديونية للمورد (بتتحدث تلقائي من الفواتير والدفعات)

    public ICollection<SupplierPayment> Payments { get; set; } = [];
    public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = [];
    public ICollection<SupplierReturn> Returns { get; set; } = [];
}
```

## File: Entities/Suppliers/SupplierPayment.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Suppliers;

public class SupplierPayment : BaseEntity
{
    public string SupplierId { get; set; } = string.Empty;
    public Supplier? Supplier { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public string? DrawerTransactionId { get; set; }
    public DrawerTransaction? DrawerTransaction { get; set; }
}
```

## File: Entities/Suppliers/SupplierReturn.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Entities.Suppliers;

// تسجيل يدوي لإرجاع بضاعة للمورد (عطل / تغيير رأي)
public class SupplierReturn : BaseEntity
{
    public string SupplierId { get; set; } = string.Empty;
    public Supplier? Supplier { get; set; }

    public ReturnReason Reason { get; set; }

    public string? Notes { get; set; }

    public decimal TotalReturnedAmount { get; set; }     // بيتخصم من مديونية المورد أو يترد كاش

    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;

    public ICollection<SupplierReturnItem> Items { get; set; } = [];

    public string? DrawerTransactionId { get; set; }     // لو استرديت فلوس كاش من المورد
    public DrawerTransaction? DrawerTransaction { get; set; }
}
```

## File: Entities/Suppliers/SupplierReturnItem.cs
```csharp
using Centraly.Api.Entities.Common;
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Entities.Suppliers;

public class SupplierReturnItem : BaseEntity
{
    public string SupplierReturnId { get; set; } = string.Empty;
    public SupplierReturn? SupplierReturn { get; set; }

    public string ProductId { get; set; } = string.Empty;
    public Product? Product { get; set; }

    public int Quantity { get; set; }              // بتتخصم من Product.Quantity

    public decimal UnitCost { get; set; }
}
```

## File: Entities/Wallets/Wallet.cs
```csharp
namespace Centraly.Api.Entities.Wallets;

public class Wallet : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? OwnerName { get; set; }
    public decimal Balance { get; set; } = 0;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<WalletTransaction> Transactions { get; set; } = new List<WalletTransaction>();
    public ICollection<WalletOperation> Operations { get; set; } = new List<WalletOperation>();
}
```

## File: Entities/Wallets/WalletOperation.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Wallets;

public enum WalletOperationType
{
    CashIn = 1,   // إيداع لعميل
    CashOut = 2   // سحب من عميل
}

public class WalletOperation : BaseEntity
{
    public string WalletId { get; set; } = string.Empty;
    public Wallet Wallet { get; set; } = null!;

    public WalletOperationType OperationType { get; set; }
    public decimal TransferredAmount { get; set; }
    public decimal PhysicalCashAmount { get; set; }
    public decimal Profit { get; set; }
    
    public string? DrawerTransactionId { get; set; }
}
```

## File: Entities/Wallets/WalletTransaction.cs
```csharp
using Centraly.Api.Entities.Common;

namespace Centraly.Api.Entities.Wallets;

public enum WalletTransactionType
{
    Income = 1,
    Expense = 2
}

public class WalletTransaction : BaseEntity
{
    public string WalletId { get; set; } = string.Empty;
    public Wallet Wallet { get; set; } = null!;

    public WalletTransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public decimal BalanceAfter { get; set; }
    public string? Notes { get; set; }
}
```

## File: Errors/CategoryErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record CategoryErrors
{
    public static readonly Error CreationFailed =
        new("Category.CreationFailed", "Failed to create category", StatusCodes.Status400BadRequest);

    public static readonly Error CategoryNotFound =
        new("Category.NotFound", "Category not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Category.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error DepartmentNotFound =
        new("Category.DepartmentNotFound", "The specified department does not exist", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Category.UpdateFailed", "Failed to update category", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Category.DeleteFailed", "Failed to delete category", StatusCodes.Status400BadRequest);
}
```

## File: Errors/CustomerErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record CustomerErrors
{
    public static readonly Error CustomerNotFound =
        new("Customer.NotFound", "Customer not found", StatusCodes.Status404NotFound);

    public static readonly Error CreationFailed =
        new("Customer.CreationFailed", "Failed to create customer", StatusCodes.Status400BadRequest);

    public static readonly Error HasOutstandingDebt =
        new("Customer.HasOutstandingDebt", "Cannot delete a customer with an outstanding debt balance", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidSortColumn =
        new("Customer.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Customer.UpdateFailed", "Failed to update customer", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Customer.DeleteFailed", "Failed to delete customer", StatusCodes.Status400BadRequest);

    public static readonly Error Error =
        new("Customer.Error", "An error occurred while processing the request", StatusCodes.Status500InternalServerError);
}
```

## File: Errors/CustomerTransactionErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record CustomerTransactionErrors
{
    public static readonly Error PaymentFailed =
        new("CustomerTransaction.PaymentFailed", "Failed to process payment", StatusCodes.Status500InternalServerError);

    public static readonly Error ReturnFailed =
        new("CustomerTransaction.ReturnFailed", "Failed to process return", StatusCodes.Status500InternalServerError);

    public static readonly Error InvoiceNotFound =
        new("CustomerTransaction.InvoiceNotFound", "Invoice not found or does not belong to customer", StatusCodes.Status404NotFound);

    public static readonly Error InvalidReturn =
        new("CustomerTransaction.InvalidReturn", "Item not found in invoice or the returned quantity exceeds what remains", StatusCodes.Status400BadRequest);

    public static readonly Error BatchNotFound =
        new("CustomerTransaction.BatchNotFound", "Batch not found", StatusCodes.Status400BadRequest);
}
```

## File: Errors/DepartmentErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record DepartmentErrors
{
    public static readonly Error CreationFailed =
        new("Department.CreationFailed", "Failed to create department", StatusCodes.Status400BadRequest);

    public static readonly Error DepartmentNotFound =
        new("Department.NotFound", "Department not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Department.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Department.UpdateFailed", "Failed to update department", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Department.DeleteFailed", "Failed to delete department", StatusCodes.Status400BadRequest);
}
```

## File: Errors/DrawerErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record DrawerErrors
{
    public static readonly Error AlreadyOpen =
        new("Drawer.AlreadyOpen", "A drawer session is already open. You must close it first.", StatusCodes.Status400BadRequest);

    public static readonly Error NoActiveSession =
        new("Drawer.NoActiveSession", "No active drawer session found.", StatusCodes.Status404NotFound);

    public static readonly Error InvalidAmount =
        new("Drawer.InvalidAmount", "Amount must be greater than zero.", StatusCodes.Status400BadRequest);

    public static readonly Error SessionNotFound =
        new("Drawer.NotFound", "Drawer session not found.", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Drawer.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientFunds =
        new("Drawer.InsufficientFunds", "Drawer does not have enough balance for this expense.", StatusCodes.Status400BadRequest);
}
```

## File: Errors/ExpenseErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record ExpenseErrors
{
    public static readonly Error CategoryNotFound =
        new("Expense.CategoryNotFound", "Expense category not found", StatusCodes.Status404NotFound);
}
```

## File: Errors/FinancePolicyErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record FinancePolicyErrors
{
    public static readonly Error InvalidCategory =
        new("FinancePolicy.InvalidCategory", "Invalid transaction category", StatusCodes.Status400BadRequest);

    public static readonly Error PolicyNotFound =
        new("FinancePolicy.PolicyNotFound", "Policy not found", StatusCodes.Status404NotFound);
}
```

## File: Errors/MaintenanceErrors.cs
```csharp
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
        new("Maintenance.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static Error InsufficientStock(string productName) =>
        new("Maintenance.InsufficientStock", $"لا يوجد مخزون كافٍ للمنتج: {productName}", StatusCodes.Status400BadRequest);
}
```

## File: Errors/ProductErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record ProductErrors
{
    public static readonly Error CreationFailed =
        new("Product.CreationFailed", "Failed to create product", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("Product.NotFound", "Product not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Product.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error DepartmentNotFound =
        new("Product.DepartmentNotFound", "The specified department does not exist", StatusCodes.Status400BadRequest);

    public static readonly Error CategoryNotFound =
        new("Product.CategoryNotFound", "The specified category does not exist", StatusCodes.Status400BadRequest);

    public static readonly Error BarcodeAlreadyExists =
        new("Product.BarcodeAlreadyExists", "A product with this barcode already exists", StatusCodes.Status409Conflict);

    public static readonly Error BatchNotFound =
        new("Product.BatchNotFound", "The specified batch does not exist for this product", StatusCodes.Status404NotFound);

    public static readonly Error UpdateFailed =
        new("Product.UpdateFailed", "Failed to update product", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Product.DeleteFailed", "Failed to delete product", StatusCodes.Status400BadRequest);
}
```

## File: Errors/PurchaseInvoiceErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record PurchaseInvoiceErrors
{
    public static readonly Error CreationFailed =
        new("PurchaseInvoice.CreationFailed", "Failed to create purchase invoice", StatusCodes.Status400BadRequest);

    public static readonly Error InvoiceNotFound =
        new("PurchaseInvoice.NotFound", "Purchase invoice not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("PurchaseInvoice.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error SupplierNotFound =
        new("PurchaseInvoice.SupplierNotFound", "The specified supplier does not exist", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("PurchaseInvoice.ProductNotFound", "One or more products in the invoice do not exist", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidPaidAmount =
        new("PurchaseInvoice.InvalidPaidAmount", "Paid amount cannot be greater than total amount", StatusCodes.Status400BadRequest);
}
```

## File: Errors/RoleErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record RoleErrors
{
    public static readonly Error RoleNotFound =
        new("Role.RoleNotFound", "Role is not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidPermissions =
        new("Role.InvalidPermissions", "Invalid permissions", StatusCodes.Status400BadRequest);

    public static readonly Error DuplicatedRole =
        new("Role.DuplicatedRole", "Another role with the same name is already exists", StatusCodes.Status409Conflict);
}
```

## File: Errors/SafeErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record SafeErrors
{
    public static readonly Error SafeNotFound =
        new("Safe.NotFound", "Safe not found", StatusCodes.Status404NotFound);

    public static readonly Error DrawerNotFound =
        new("Safe.DrawerNotFound", "Drawer session not found", StatusCodes.Status404NotFound);

    public static readonly Error DrawerNotClosed =
        new("Safe.DrawerNotClosed", "Cannot deposit from an open drawer session", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientFunds =
        new("Safe.InsufficientFunds", "Safe does not have enough funds", StatusCodes.Status400BadRequest);
}
```

## File: Errors/SalesInvoiceErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record SalesInvoiceErrors
{
    public static readonly Error InvoiceNotFound =
        new("SalesInvoice.NotFound", "Invoice not found", StatusCodes.Status404NotFound);

    public static readonly Error CustomerNotFound =
        new("SalesInvoice.CustomerNotFound", "The specified customer does not exist", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidPayment =
        new("SalesInvoice.InvalidPayment", "Cash / walk-in sales must be paid in full", StatusCodes.Status400BadRequest);

    public static readonly Error BatchNotFound =
        new("SalesInvoice.BatchNotFound", "One or more batches were not found or do not match the requested product", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientQuantity =
        new("SalesInvoice.InsufficientQuantity", "Insufficient quantity in batch", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidSortColumn =
        new("SalesInvoice.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error CreationFailed =
        new("SalesInvoice.CreationFailed", "Error creating sales invoice", StatusCodes.Status500InternalServerError);
}
```

## File: Errors/SalesReturnErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record SalesReturnErrors
{
    public static readonly Error ReturnNotFound =
        new("SalesReturn.NotFound", "Return record not found", StatusCodes.Status404NotFound);

    public static readonly Error InvoiceNotFound =
        new("SalesReturn.InvoiceNotFound", "Invoice not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidReturn =
        new("SalesReturn.InvalidReturn", "Item not found in invoice or the returned quantity exceeds what remains", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("SalesReturn.ProductNotFound", "Product or batch not found for one of the returned items", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("SalesReturn.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error CreationFailed =
        new("SalesReturn.CreationFailed", "Failed to process return", StatusCodes.Status500InternalServerError);
}
```

## File: Errors/SupplierErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record SupplierErrors
{
    public static readonly Error CreationFailed =
        new("Supplier.CreationFailed", "Failed to create supplier", StatusCodes.Status400BadRequest);

    public static readonly Error SupplierNotFound =
        new("Supplier.NotFound", "Supplier not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidSortColumn =
        new("Supplier.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);

    public static readonly Error UpdateFailed =
        new("Supplier.UpdateFailed", "Failed to update supplier", StatusCodes.Status400BadRequest);

    public static readonly Error DeleteFailed =
        new("Supplier.DeleteFailed", "Failed to delete supplier", StatusCodes.Status400BadRequest);

    public static readonly Error HasOutstandingDebt =
        new("Supplier.HasOutstandingDebt", "Cannot delete supplier with outstanding debt", StatusCodes.Status400BadRequest);
}
```

## File: Errors/SupplierTransactionErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record SupplierTransactionErrors
{
    public static readonly Error PaymentCreationFailed =
        new("SupplierTransaction.PaymentCreationFailed", "Failed to create supplier payment", StatusCodes.Status400BadRequest);

    public static readonly Error ReturnCreationFailed =
        new("SupplierTransaction.ReturnCreationFailed", "Failed to create supplier return", StatusCodes.Status400BadRequest);

    public static readonly Error PaymentNotFound =
        new("SupplierTransaction.PaymentNotFound", "Supplier payment not found", StatusCodes.Status404NotFound);

    public static readonly Error ReturnNotFound =
        new("SupplierTransaction.ReturnNotFound", "Supplier return not found", StatusCodes.Status404NotFound);

    public static readonly Error SupplierNotFound =
        new("SupplierTransaction.SupplierNotFound", "The specified supplier does not exist", StatusCodes.Status400BadRequest);

    public static readonly Error ProductNotFound =
        new("SupplierTransaction.ProductNotFound", "One or more products in the return do not exist", StatusCodes.Status400BadRequest);

    public static readonly Error BatchNotFound =
        new("SupplierTransaction.BatchNotFound", "One or more batches in the return do not exist", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientQuantity =
        new("SupplierTransaction.InsufficientQuantity", "Cannot return quantity greater than what is in stock", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidSortColumn =
        new("SupplierTransaction.InvalidSortColumn", "The specified sort column is not allowed", StatusCodes.Status400BadRequest);
}
```

## File: Errors/TransactionRouterErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record TransactionRouterErrors
{
    public static readonly Error PolicyViolation =
        new("TransactionRouter.PolicyViolation", "The requested payment source is not allowed for this transaction category", StatusCodes.Status400BadRequest);

    public static readonly Error NoMainSafe =
        new("TransactionRouter.NoMainSafe", "No main safe found", StatusCodes.Status404NotFound);
}
```

## File: Errors/UserErrors.cs
```csharp
namespace Centraly.Api.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new("User.InvalidCredentials", "Invalid email/password", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicateEmail =
        new("User.DuplicateEmail", "Another user with the same email is already exists", StatusCodes.Status409Conflict);

    public static readonly Error EmailNotConfirmed =
        new("User.EmailNotConfirmed", "Email is not confirmed", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
        new("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized);

    public static readonly Error LockedUser =
        new("User.LockedUser", "Locked user, please contact with administrator", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidToken =
        new("User.InvalidToken", "Invalid token", StatusCodes.Status400BadRequest);

    public static readonly Error DuplicateEmailConfirmed =
        new("User.DuplicateEmailConfirmed", "Another user with the same email is already confirmed", StatusCodes.Status409Conflict);

    public static readonly Error UserNotFound =
        new("User.UserNotFound", "User not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidPassword =
        new("User.InvalidPassword", "Current password is incorrect", StatusCodes.Status401Unauthorized);
    public static readonly Error DisabledUser =
        new("User.DisabledUser", "User is disabled, please contact with administrator", StatusCodes.Status401Unauthorized);
    public static readonly Error UnexpectedError =
        new("User.UnexpectedError", "Unexpected error occurred", StatusCodes.Status500InternalServerError);
    public static readonly Error InvalidJwtToken =
        new("User.InvalidJwtToken", "Invalid JWT token", StatusCodes.Status401Unauthorized);

}
```

## File: Errors/WalletErrors.cs
```csharp
namespace Centraly.Api.Errors;

public record WalletErrors
{
    public static readonly Error NotFound =
        new("Wallet.NotFound", "Wallet not found", StatusCodes.Status404NotFound);

    public static readonly Error WalletNotFound = NotFound;

    public static readonly Error Inactive =
        new("Wallet.Inactive", "Wallet is not active", StatusCodes.Status400BadRequest);

    public static readonly Error InsufficientBalance =
        new("Wallet.InsufficientBalance", "Insufficient balance in wallet", StatusCodes.Status400BadRequest);

    public static readonly Error InvalidOperation =
        new("Wallet.InvalidOperation", "Invalid operation type", StatusCodes.Status400BadRequest);
}
```

## File: Extensions/QueryableFilterExtensions.cs
```csharp
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Centraly.Api.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, RequestFilters filters, Expression<Func<T, bool>>? searchPredicate = null, IEnumerable<string>? allowedSortColumns = null)
    {
        ArgumentNullException.ThrowIfNull(query);
        ArgumentNullException.ThrowIfNull(filters);

        if (!string.IsNullOrWhiteSpace(filters.SearchValue) && searchPredicate is not null)
            query = query.Where(searchPredicate);

        if (!string.IsNullOrWhiteSpace(filters.SortColumn))
        {
            var column = filters.SortColumn.Trim();

            if (allowedSortColumns is not null && !allowedSortColumns.Contains(column, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentException($"Sort column '{column}' is not allowed.");

            var direction = filters.SortDirection == SortDirection.Desc ? "DESC" : "ASC";
            query = query.OrderBy($"{column} {direction}");
        }

        return query;
    }

    public static Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, RequestFilters filters, CancellationToken cancellationToken = default)
        => PaginatedList<T>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);
}



//private static readonly string[] JobSortColumns = ["Title", "CreatedAt", "Salary"];

//    var jobs = await _context.Jobs
//        .Where(j => j.CompanyId == companyId)
//        .ApplyFilters(
//            filters,
//            searchPredicate: x => x.Title.Contains(filters.SearchValue!),
//            allowedSortColumns: JobSortColumns)
//        .ProjectToType<JobResponse>()
//        .AsNoTracking()
//        .ToPaginatedListAsync(filters, cancellationToken);
```

## File: Extensions/UserExtensions.cs
```csharp
namespace Centraly.Extensions;

public static class UserExtensions
{
    public static string? GetUserId(this ClaimsPrincipal user) =>
        user.FindFirstValue(ClaimTypes.NameIdentifier);
}
```

## File: fix_drawer.csx
```
using System.IO;
using System.Text.RegularExpressions;

var path = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\DrawerService.cs";
var content = File.ReadAllText(path);

// Fix OpenSessionAsync type variable
content = Regex.Replace(content, @"(public async Task<Result<DrawerSessionResponse>> OpenSessionAsync.*?\n\s*\{\n\s*var activeSession = await _dbContext\.DrawerSessions\.FirstOrDefaultAsync\(s => !s\.IsClosed && \(int\)s\.Type == )type", "$1request.Type");

// Fix RecordTransactionAsync type comparison
content = Regex.Replace(content, @"(public async Task<Result<DrawerTransactionResponse>> RecordTransactionAsync.*?\n\s*\{\n)(.*?\n.*?)&& \(int\)s\.Type == type", "$1        var targetDrawerType = category == DrawerTransactionCategory.Maintenance ? 2 : 1;\n$2&& (int)s.Type == targetDrawerType");

File.WriteAllText(path, content);
```

## File: GlobalUsings.cs
```csharp
global using Centraly.Api.Abstractions;
global using Centraly.Api.Abstractions.Consts;
global using Centraly.Api.Authentication;
global using Centraly.Api.Contracts.Authentication;
global using Centraly.Api.Contracts.Common;
global using Centraly.Api.Contracts.Customers;
global using Centraly.Api.Contracts.Drawer;
global using Centraly.Api.Contracts.Finance;
global using Centraly.Api.Contracts.Inventory.Categories;
global using Centraly.Api.Contracts.Inventory.Departments;
global using Centraly.Api.Contracts.Inventory.Products;
global using Centraly.Api.Contracts.Returns;
global using Centraly.Api.Contracts.Sales;
global using Centraly.Api.Contracts.Shared.Enums;
global using Centraly.Api.Contracts.Shared.Summaries;
global using Centraly.Api.Contracts.Suppliers;
global using Centraly.Api.Contracts.Wallets;
global using Centraly.Api.Entities;
global using Centraly.Api.Entities.Common;
global using Centraly.Api.Entities.Customers;
global using Centraly.Api.Entities.Drawer;
global using Centraly.Api.Entities.Finance;
global using Centraly.Api.Entities.Inventory;
global using Centraly.Api.Entities.Returns;
global using Centraly.Api.Entities.Sales;
global using Centraly.Api.Entities.Suppliers;
global using Centraly.Api.Entities.Wallets;
global using Centraly.Api.Errors;
global using Centraly.Api.Extensions;
global using Centraly.Api.Helpers;
global using Centraly.Api.Mappings;
global using Centraly.Api.Options;
global using Centraly.Api.Persistence;
global using Centraly.Api.Services.Abstraction;
global using Centraly.Extensions;
global using FluentValidation;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using System.Text.Json;
```

## File: Helpers/FileHelper.cs
```csharp
namespace Centraly.Api.Helpers;

public class FileHelper
{
    public async static Task<string?> UploadeFileAsync(IFormFile file, string location, IWebHostEnvironment env, IHttpContextAccessor accessor)
    {
        if (file is null)
            return null;
        var path = Path.Combine(env.WebRootPath, location);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var extention = Path.GetExtension(file.FileName);
        var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty);

        var fullPath = Path.Combine(path, fileName + extention);

        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);

        }
        var origin = accessor.HttpContext?.Request;

        return $"{origin.Scheme}://{origin.Host}/{location}/{fileName}{extention}";
    }

    //DeleteFile عمليه سريعه جدا علي الكورس
    public static void DeleteFile(string oldPath, string location, IWebHostEnvironment env)
    {
        if (string.IsNullOrEmpty(oldPath))
            return;

        var fileName = Path.GetFileName(new Uri(oldPath).LocalPath);
        var path = Path.Combine(env.WebRootPath, location, fileName);

        if (File.Exists(path))
            File.Delete(path);
    }
}
```

## File: Mappings/CategoryMapping.cs
```csharp
using Centraly.Api.Contracts.Inventory.Categories;
using Centraly.Api.Entities.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class CategoryMapping
{
    public static IQueryable<CategoryResponse> ProjectToResponse(this IQueryable<Category> query)
    {
        return query
            .Where(c => !c.IsDeleted)
            .AsNoTracking()
            .Select(c => new CategoryResponse(
                c.Id,
                c.Name,
                new DepartmentSummary(c.Department!.Id, c.Department.Name),
                c.Products.Count(p => !p.IsDeleted),
                c.CreatedAt));
    }
}
```

## File: Mappings/DepartmentMapping.cs
```csharp
using Centraly.Api.Contracts.Inventory.Departments;
using Centraly.Api.Entities.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class DepartmentMapping
{
    public static IQueryable<DepartmentResponse> ProjectToResponse(this IQueryable<Department> query)
    {
        return query
            .Where(d => !d.IsDeleted)
            .AsNoTracking()
            .Select(d => new DepartmentResponse(
                d.Id,
                d.Name,
                d.Categories.Count(c => !c.IsDeleted),
                d.Products.Count(p => !p.IsDeleted),
                d.CreatedAt));
    }
}
```

## File: Mappings/FinanceMapping.cs
```csharp
namespace Centraly.Api.Mappings;

public static class FinanceMapping
{
    // ─────────────────────────────────────────────────────────────────
    //  Safes
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SafeResponse> ProjectToResponse(this IQueryable<Safe> query)
    {
        return query
            .AsNoTracking()
            .Select(s => new SafeResponse(s.Id, s.Name, s.Balance, s.IsMain));
    }

    public static IQueryable<SafeTransactionResponse> ProjectToResponse(this IQueryable<SafeTransaction> query)
    {
        return query
            .AsNoTracking()
            .Select(t => new SafeTransactionResponse(
                t.Id, t.SafeId, t.TransactionType.ToString(), t.Category.ToString(), t.Amount, t.BalanceAfter, t.CreatedAt, t.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Drawer
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<DrawerSessionResponse> ProjectToResponse(this IQueryable<DrawerSession> query)
    {
        return query
            .AsNoTracking()
            .Select(s => new DrawerSessionResponse(
                s.Id,
                (int)s.Type,
                s.OpeningBalance,
                s.OpenedAt,
                s.OpenedByUserId,
                s.IsClosed,
                s.ClosedAt,
                s.TotalIncome,
                s.TotalExpense,
                s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), s.Transactions
                    .OrderByDescending(t => t.CreatedAt)
                    .Select(t => new DrawerTransactionResponse(
                        t.Id, t.Type, t.Category, t.Amount, t.Balance, t.Source, t.Notes, t.CreatedAt, t.UserId))
                    .ToList()));
    }

    public static IQueryable<DrawerSessionResponse> ProjectToSummaryResponse(this IQueryable<DrawerSession> query)
    {
        return query
            .AsNoTracking()
            .Select(s => new DrawerSessionResponse(
                s.Id, (int)s.Type, s.OpeningBalance, s.OpenedAt, s.OpenedByUserId, s.IsClosed, s.ClosedAt,
                s.TotalIncome, s.TotalExpense, s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), new List<DrawerTransactionResponse>()));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Expenses
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<ExpenseCategoryResponse> ProjectToResponse(this IQueryable<ExpenseCategory> query)
    {
        return query
            .AsNoTracking()
            .Select(c => new ExpenseCategoryResponse(c.Id, c.Name));
    }

    public static IQueryable<ExpenseResponse> ProjectToResponse(this IQueryable<Expense> query)
    {
        return query
            .AsNoTracking()
            .Select(e => new ExpenseResponse(
                e.Id, e.CategoryId, e.Category!.Name, e.Amount, e.PaymentSource.ToString(), e.ExpenseDate, e.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Owner Transactions
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<OwnerTransactionResponse> ProjectToResponse(this IQueryable<OwnerTransaction> query)
    {
        return query
            .AsNoTracking()
            .Select(t => new OwnerTransactionResponse(
                t.Id, t.Category, t.Amount, t.PaymentSource, t.Notes, t.CreatedAt, t.CreatedByUserId));
    }

    public static OwnerTransactionResponse ToResponse(this OwnerTransaction t)
    {
        return new OwnerTransactionResponse(
            t.Id, t.Category, t.Amount, t.PaymentSource, t.Notes, t.CreatedAt, t.CreatedByUserId);
    }
}
```

## File: Mappings/ProductMapping.cs
```csharp
using Centraly.Api.Contracts.Inventory.Categories;
using Centraly.Api.Contracts.Inventory.Departments;
using Centraly.Api.Contracts.Inventory.Products;
using Centraly.Api.Entities.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class ProductMapping
{
    public sealed record PropertyPair(string Name, string Value);

    public sealed record ProductProjection(
        string ProductId,
        string? Barcode,
        string? Name,
        string DepartmentId,
        string DepartmentName,
        string CategoryId,
        string CategoryName,
        int Quantity,
        string? ImageUrl,
        int MinQuantityAlert,
        string? StorageLocation,
        DateTime CreatedAt,
        Centraly.Api.Contracts.Shared.Enums.ProductUsageDto Usage,
        List<PropertyPair> Properties,
        List<ProductBatchResponse> Batches);

    public static IQueryable<ProductProjection> ProjectToIntermediate(this IQueryable<Product> query)
    {
        return query
            .Where(p => !p.IsDeleted)
            .AsNoTracking()
            .Select(p => new ProductProjection(
                p.Id,
                p.Barcode,
                p.Name,
                p.DepartmentId,
                p.Department != null ? p.Department.Name : "بدون قسم",
                p.CategoryId,
                p.Category != null ? p.Category.Name : "بدون تصنيف",
                p.Quantity,
                p.ImageUrl,
                p.MinQuantityAlert,
                p.StorageLocation,
                p.CreatedAt,
                (Centraly.Api.Contracts.Shared.Enums.ProductUsageDto)p.Usage,
                p.Properties.Select(prop => new PropertyPair(prop.Name, prop.Value)).ToList(),
                p.Batches
                    .Where(b => b.AvailableQuantity > 0 && !b.IsDeleted)
                    .Select(b => new ProductBatchResponse(
                        b.Id,
                        b.SupplierId,
                        b.Supplier != null ? b.Supplier.Name : null,
                        b.AvailableQuantity,
                        b.PurchasePrice,
                        b.WholesalePrice,
                        b.RetailPrice,
                        b.MaintenancePrice,
                        b.DateReceived))
                    .ToList()));
    }

    public static ProductResponse ToResponse(this ProductProjection p)
    {
        return new ProductResponse(
            p.ProductId,
            p.Barcode,
            p.Name,
            new DepartmentSummary(p.DepartmentId, p.DepartmentName),
            new CategorySummary(p.CategoryId, p.CategoryName),
            p.Quantity,
            p.ImageUrl,
            p.MinQuantityAlert,
            p.StorageLocation,
            p.Quantity <= 0,
            p.Quantity > 0 && p.Quantity <= p.MinQuantityAlert,
            p.CreatedAt,
            p.Usage,
            p.Properties.ToDictionary(x => x.Name, x => x.Value),
            p.Batches);
    }
}
```

## File: Mappings/PurchasingMapping.cs
```csharp
using Centraly.Api.Contracts.Inventory.Products;
using Centraly.Api.Contracts.Suppliers;
using Centraly.Api.Entities.Inventory;
using Centraly.Api.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class PurchasingMapping
{
    // ─────────────────────────────────────────────────────────────────
    //  Suppliers
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SupplierResponse> ProjectToResponse(this IQueryable<Supplier> query)
    {
        return query
            .Where(s => !s.IsDeleted)
            .AsNoTracking()
            .Select(s => new SupplierResponse(
                s.Id,
                s.Name,
                s.Type,
                s.Phone,
                s.Address,
                s.DebtBalance,
                s.PurchaseInvoices.Count(pi => !pi.IsDeleted),
                s.Returns.Count(r => !r.IsDeleted),
                s.CreatedAt));
    }

    public static IQueryable<SupplierBatchResponse> ProjectToResponse(this IQueryable<ProductBatch> query)
    {
        return query
            .Where(b => b.AvailableQuantity > 0 && !b.IsDeleted)
            .AsNoTracking()
            .Select(b => new SupplierBatchResponse(
                b.Id,
                b.ProductId,
                b.Product != null ? b.Product.Name : null,
                b.Product != null ? b.Product.Barcode : null,
                b.AvailableQuantity,
                b.PurchasePrice,
                b.DateReceived));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Purchase Invoices
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<PurchaseInvoiceResponse> ProjectToResponse(this IQueryable<PurchaseInvoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new PurchaseInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                new SupplierSummary(i.Supplier!.Id, i.Supplier.Name, i.Supplier.Phone),
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.InvoiceDate,
                i.Notes,
                i.Items.Select(item => new PurchaseInvoiceItemResponse(
                    item.Id,
                    new ProductSummary(item.ProductId, item.Product!.Name, item.Product.Barcode, item.Product.ImageUrl, 0, 0, item.Product.Quantity),
                    item.Quantity,
                    item.UnitCost,
                    item.Quantity * item.UnitCost))
                    .ToList()));
    }

    public static IQueryable<PurchaseInvoiceResponse> ProjectToSummaryResponse(this IQueryable<PurchaseInvoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new PurchaseInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                new SupplierSummary(i.Supplier!.Id, i.Supplier.Name, i.Supplier.Phone),
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.InvoiceDate,
                i.Notes,
                new List<PurchaseInvoiceItemResponse>()));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Supplier Payments
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SupplierPaymentResponse> ProjectToResponse(this IQueryable<SupplierPayment> query)
    {
        return query
            .Where(p => !p.IsDeleted)
            .AsNoTracking()
            .Select(p => new SupplierPaymentResponse(
                p.Id,
                new SupplierSummary(p.Supplier!.Id, p.Supplier.Name, p.Supplier.Phone),
                p.Amount,
                p.PaymentDate,
                p.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Supplier Returns
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SupplierReturnResponse> ProjectToResponse(this IQueryable<SupplierReturn> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new SupplierReturnResponse(
                r.Id,
                new SupplierSummary(r.Supplier!.Id, r.Supplier.Name, r.Supplier.Phone),
                (ReturnReasonDto)r.Reason,
                r.Notes,
                r.TotalReturnedAmount,
                r.ReturnDate,
                r.Items.Select(item => new SupplierReturnItemResponse(
                    item.Id,
                    new ProductSummary(item.ProductId, item.Product!.Name, item.Product.Barcode, item.Product.ImageUrl, 0, 0, item.Product.Quantity),
                    item.Quantity,
                    item.UnitCost,
                    item.Quantity * item.UnitCost))
                    .ToList()));
    }

    public static IQueryable<SupplierReturnResponse> ProjectToSummaryResponse(this IQueryable<SupplierReturn> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new SupplierReturnResponse(
                r.Id,
                new SupplierSummary(r.Supplier!.Id, r.Supplier.Name, r.Supplier.Phone),
                (ReturnReasonDto)r.Reason,
                r.Notes,
                r.TotalReturnedAmount,
                r.ReturnDate,
                new List<SupplierReturnItemResponse>()));
    }
}
```

## File: Mappings/SalesMapping.cs
```csharp
using Centraly.Api.Contracts.Customers;
using Centraly.Api.Contracts.Sales;
using Centraly.Api.Entities.Customers;
using Centraly.Api.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace Centraly.Api.Mappings;

public static class SalesMapping
{
    // ─────────────────────────────────────────────────────────────────
    //  Customers
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<CustomerResponse> ProjectToResponse(this IQueryable<Customer> query)
    {
        return query
            .Where(c => !c.IsDeleted)
            .AsNoTracking()
            .Select(c => new CustomerResponse(
                c.Id,
                c.Name,
                c.Phone,
                c.DebtBalance,
                c.Invoices.Count(i => !i.IsDeleted),
                c.CreatedAt));
    }

    public static IQueryable<CustomerInvoiceSummary> ProjectToSummary(this IQueryable<Invoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new CustomerInvoiceSummary(
                i.Id,
                i.InvoiceNumber,
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.CreatedAt));
    }

    public static IQueryable<CustomerDebtPaymentResponse> ProjectToResponse(this IQueryable<CustomerDebtPayment> query)
    {
        return query
            .AsNoTracking()
            .Select(p => new CustomerDebtPaymentResponse(
                p.Id,
                new CustomerSummary(p.Customer!.Id, p.Customer.Name, p.Customer.Phone),
                p.Amount,
                p.PaymentDate,
                p.Notes));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Sales Invoices
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<SalesInvoiceResponse> ProjectToResponse(this IQueryable<Invoice> query, ApplicationDbContext dbContext)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new SalesInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                i.Customer != null ? new CustomerSummary(i.Customer.Id, i.Customer.Name, i.Customer.Phone) : null,
                (SaleTypeDto)i.SaleType,
                (PaymentMethodDto)i.PaymentMethod,
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.Notes,
                i.CreatedAt,
                i.Returns.Any(r => !r.IsDeleted),
                i.Items.Select(item => new SalesInvoiceItemResponse(
                    item.Id,
                    item.ProductId,
                    item.Product != null ? item.Product.Name ?? "Unknown" : "Unknown",
                    item.BatchId,
                    item.Quantity,
                    dbContext.ReturnItems
                        .Where(ri => ri.ReturnRecord.InvoiceId == i.Id && ri.ProductId == item.ProductId && ri.BatchId == item.BatchId)
                        .Sum(ri => (int?)ri.Quantity) ?? 0,
                    item.UnitPrice,
                    item.UnitCost,
                    item.Quantity * item.UnitPrice))
                    .ToList()));
    }

    public static IQueryable<SalesInvoiceResponse> ProjectToSummaryResponse(this IQueryable<Invoice> query)
    {
        return query
            .Where(i => !i.IsDeleted)
            .AsNoTracking()
            .Select(i => new SalesInvoiceResponse(
                i.Id,
                i.InvoiceNumber,
                i.Customer != null ? new CustomerSummary(i.Customer.Id, i.Customer.Name, i.Customer.Phone) : null,
                (SaleTypeDto)i.SaleType,
                (PaymentMethodDto)i.PaymentMethod,
                i.TotalAmount,
                i.PaidAmount,
                i.TotalAmount - i.PaidAmount,
                i.Notes,
                i.CreatedAt,
                i.Returns.Any(r => !r.IsDeleted),
                new List<SalesInvoiceItemResponse>()));
    }
    // ─────────────────────────────────────────────────────────────────
    //  Sales Returns
    // ─────────────────────────────────────────────────────────────────

    public static IQueryable<ReturnRecordResponse> ProjectToResponse(this IQueryable<ReturnRecord> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new ReturnRecordResponse(
                r.Id,
                r.InvoiceId,
                r.Invoice != null ? r.Invoice.InvoiceNumber : "",
                r.IsFullInvoiceReturn,
                (ReturnReasonDto)r.Reason,
                r.Notes,
                false, // IsCashRefund
                r.TotalReturnedAmount,
                r.ReturnDate,
                r.Items.Select(item => new ReturnItemResponse(
                    item.Id, item.ProductId, item.BatchId, item.Quantity, item.UnitPrice))
                    .ToList()));
    }

    public static IQueryable<ReturnRecordResponse> ProjectToSummaryResponse(this IQueryable<ReturnRecord> query)
    {
        return query
            .Where(r => !r.IsDeleted)
            .AsNoTracking()
            .Select(r => new ReturnRecordResponse(
                r.Id,
                r.InvoiceId,
                r.Invoice != null ? r.Invoice.InvoiceNumber : "",
                r.IsFullInvoiceReturn,
                (ReturnReasonDto)r.Reason,
                r.Notes,
                false,
                r.TotalReturnedAmount,
                r.ReturnDate,
                new List<ReturnItemResponse>()));
    }
}
```

## File: Mappings/WalletMapping.cs
```csharp
using Centraly.Api.Contracts.Wallets;
using Centraly.Api.Entities.Wallets;

namespace Centraly.Api.Mappings;

public static class WalletMapping
{
    public static WalletResponse ToResponse(this Wallet wallet)
    {
        return new WalletResponse(
            wallet.Id,
            wallet.Name,
            wallet.PhoneNumber,
            wallet.OwnerName,
            wallet.Balance,
            wallet.ImageUrl,
            wallet.IsActive,
            wallet.CreatedAt
        );
    }

    public static WalletDetailsResponse ToDetailsResponse(this Wallet wallet, decimal netProfit)
    {
        return new WalletDetailsResponse(
            wallet.Id,
            wallet.Name,
            wallet.PhoneNumber,
            wallet.OwnerName,
            wallet.Balance,
            wallet.ImageUrl,
            wallet.IsActive,
            wallet.CreatedAt,
            netProfit
        );
    }

    public static WalletOperationResponse ToResponse(this WalletOperation operation)
    {
        return new WalletOperationResponse(
            operation.Id,
            operation.WalletId,
            operation.OperationType,
            operation.TransferredAmount,
            operation.PhysicalCashAmount,
            operation.Profit,
            operation.DrawerTransactionId,
            operation.CreatedAt
        );
    }
}
```

## File: Middlewares/GlobalCancellationMiddleware.cs
```csharp
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Centraly.Api.Middlewares;

public class GlobalCancellationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalCancellationMiddleware> _logger;

    public GlobalCancellationMiddleware(RequestDelegate next, ILogger<GlobalCancellationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Request was cancelled by the client.");
            context.Response.StatusCode = 499; // Client Closed Request
        }
        catch (Exception ex) when (ex.InnerException is OperationCanceledException || ex is TaskCanceledException)
        {
            _logger.LogInformation("Request was cancelled by the client (TaskCanceledException).");
            context.Response.StatusCode = 499; // Client Closed Request
        }
    }
}
```

## File: Options/JwtOptions.cs
```csharp
namespace Centraly.Api.Options;

public class JwtOptions
{
    public static string SectionName = "Jwt";

    [Required]
    public string Key { get; init; } = string.Empty;

    [Required]
    public string Issuer { get; init; } = string.Empty;

    [Required]
    public string Audience { get; init; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int ExpiryMinutes { get; init; }
}
```

## File: Persistence/ApplicationDbContext.cs
```csharp
using Centraly.Api.Entities.Maintenance;
using System.Linq.Expressions;

namespace Centraly.Api.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{
    // Inventory
    public DbSet<Department> Departments => Set<Department>();     // Ã˜Â§Ã™â€žÃ˜Â£Ã™â€šÃ˜Â³Ã˜Â§Ã™â€¦ Ã˜Â§Ã™â€žÃ˜Â±Ã˜Â¦Ã™Å Ã˜Â³Ã™Å Ã˜Â© (Ã™â€¦Ã˜Â«Ã™â€žÃ˜Â§Ã™â€¹: Ã™â€¦Ã™Ë†Ã˜Â¨Ã˜Â§Ã™Å Ã™â€žÃ˜Â§Ã˜ÂªÃ˜Å’ Ã˜Â¥Ã™Æ’Ã˜Â³Ã˜Â³Ã™Ë†Ã˜Â§Ã˜Â±Ã˜Â§Ã˜Âª)
    public DbSet<Category> Categories => Set<Category>();          // Ã˜Â§Ã™â€žÃ˜ÂªÃ˜ÂµÃ™â€ Ã™Å Ã™ÂÃ˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ™ÂÃ˜Â±Ã˜Â¹Ã™Å Ã˜Â© Ã˜Â¬Ã™Ë†Ã™â€¡ Ã™Æ’Ã™â€ž Ã™â€šÃ˜Â³Ã™â€¦
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductBatch> ProductBatches => Set<ProductBatch>();
    public DbSet<ProductProperty> ProductProperties => Set<ProductProperty>();

    // Customers
    public DbSet<Customer> Customers => Set<Customer>();                        // Ã˜Â¨Ã™Å Ã˜Â§Ã™â€ Ã˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™â€žÃ˜Â§Ã˜Â¡ Ã™Ë†Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜ÂªÃ™â€¡Ã™â€¦ Ã˜Â§Ã™â€žÃ˜Â­Ã˜Â§Ã™â€žÃ™Å Ã˜Â©
    public DbSet<CustomerDebtPayment> CustomerDebtPayments => Set<CustomerDebtPayment>();  // Ã˜Â¯Ã™ÂÃ˜Â¹Ã˜Â§Ã˜Âª Ã˜ÂªÃ˜Â³Ã˜Â¯Ã™Å Ã˜Â¯ Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜Â© Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™Å Ã™â€ž

    // Sales
    public DbSet<Invoice> Invoices => Set<Invoice>();               // Ã™ÂÃ™Ë†Ã˜Â§Ã˜ÂªÃ™Å Ã˜Â± Ã˜Â§Ã™â€žÃ˜Â¨Ã™Å Ã˜Â¹ (Ã˜Â¬Ã™â€¦Ã™â€žÃ˜Â©/Ã˜ÂªÃ˜Â¬Ã˜Â²Ã˜Â¦Ã˜Â©Ã˜Å’ Ã™Æ’Ã˜Â§Ã˜Â´/Ã˜Â¢Ã˜Â¬Ã™â€ž)
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();   // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã™ÂÃ˜Â§Ã˜ÂªÃ™Ë†Ã˜Â±Ã˜Â© Ã˜Â¨Ã™Å Ã˜Â¹ (Ã˜Â§Ã™â€žÃ™â€¦Ã™â€ Ã˜ÂªÃ˜Â¬Ã˜Å’ Ã˜Â§Ã™â€žÃ™Æ’Ã™â€¦Ã™Å Ã˜Â©Ã˜Å’ Ã˜Â§Ã™â€žÃ˜Â³Ã˜Â¹Ã˜Â± Ã™Ë†Ã™â€šÃ˜Âª Ã˜Â§Ã™â€žÃ˜Â¨Ã™Å Ã˜Â¹)

    // Returns
    public DbSet<ReturnRecord> Returns => Set<ReturnRecord>();      // Ã˜Â³Ã˜Â¬Ã™â€ž Ã™â€¦Ã˜Â±Ã˜ÂªÃ˜Â¬Ã˜Â¹Ã˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™â€žÃ˜Â§Ã˜Â¡ (Ã™â€¦Ã˜Â±Ã˜ÂªÃ˜Â¨Ã˜Â·Ã˜Â© Ã˜Â¨Ã™ÂÃ˜Â§Ã˜ÂªÃ™Ë†Ã˜Â±Ã˜Â© Ã˜Â¨Ã™Å Ã˜Â¹)
    public DbSet<ReturnItem> ReturnItems => Set<ReturnItem>();      // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã˜Â¹Ã™â€¦Ã™â€žÃ™Å Ã˜Â© Ã˜Â¥Ã˜Â±Ã˜Â¬Ã˜Â§Ã˜Â¹ (Ã˜Â§Ã™â€žÃ™â€¦Ã™â€ Ã˜ÂªÃ˜Â¬ Ã™Ë†Ã˜Â§Ã™â€žÃ™Æ’Ã™â€¦Ã™Å Ã˜Â© Ã˜Â§Ã™â€žÃ™â€¦Ã˜Â±Ã˜ÂªÃ˜Â¬Ã˜Â¹Ã˜Â©)

    // Maintenance
    public DbSet<MaintenanceDevice> MaintenanceDevices => Set<MaintenanceDevice>();  // Ã˜Â£Ã˜Â¬Ã™â€¡Ã˜Â²Ã˜Â© Ã˜Â§Ã™â€žÃ˜ÂµÃ™Å Ã˜Â§Ã™â€ Ã˜Â© Ã˜Â§Ã™â€žÃ™Ë†Ã˜Â§Ã˜Â±Ã˜Â¯Ã˜Â© Ã™â€¦Ã™â€  Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™â€žÃ˜Â§Ã˜Â¡ Ã™Ë†Ã˜Â­Ã˜Â§Ã™â€žÃ˜ÂªÃ™â€¡Ã˜Â§

    // Spare Parts
    public DbSet<MaintenanceProductItem> MaintenanceProductItems => Set<MaintenanceProductItem>();

    // Suppliers
    public DbSet<Supplier> Suppliers => Set<Supplier>();                             // Ã˜Â¨Ã™Å Ã˜Â§Ã™â€ Ã˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯Ã™Å Ã™â€  Ã™Ë†Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜ÂªÃ™â€¡Ã™â€¦
    public DbSet<PurchaseInvoice> PurchaseInvoices => Set<PurchaseInvoice>();         // Ã™ÂÃ™Ë†Ã˜Â§Ã˜ÂªÃ™Å Ã˜Â± Ã˜Â§Ã™â€žÃ˜ÂªÃ™Ë†Ã˜Â±Ã™Å Ã˜Â¯ (Ã˜Â´Ã˜Â±Ã˜Â§Ã˜Â¡ Ã˜Â¨Ã˜Â¶Ã˜Â§Ã˜Â¹Ã˜Â© Ã™â€¦Ã™â€  Ã™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯)
    public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems => Set<PurchaseInvoiceItem>();  // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã™ÂÃ˜Â§Ã˜ÂªÃ™Ë†Ã˜Â±Ã˜Â© Ã˜ÂªÃ™Ë†Ã˜Â±Ã™Å Ã˜Â¯
    public DbSet<SupplierPayment> SupplierPayments => Set<SupplierPayment>();         // Ã˜Â¯Ã™ÂÃ˜Â¹Ã˜Â§Ã˜Âª Ã˜ÂªÃ˜Â³Ã˜Â¯Ã™Å Ã˜Â¯ Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜Â© Ã˜Â§Ã™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯
    public DbSet<SupplierReturn> SupplierReturns => Set<SupplierReturn>();            // Ã˜Â¥Ã˜Â±Ã˜Â¬Ã˜Â§Ã˜Â¹ Ã˜Â¨Ã˜Â¶Ã˜Â§Ã˜Â¹Ã˜Â© Ã™â€žÃ™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯ (Ã˜Â¹Ã˜Â·Ã™â€ž/Ã˜ÂªÃ˜ÂºÃ™Å Ã™Å Ã˜Â± Ã˜Â±Ã˜Â£Ã™Å )
    public DbSet<SupplierReturnItem> SupplierReturnItems => Set<SupplierReturnItem>();  // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã˜Â¹Ã™â€¦Ã™â€žÃ™Å Ã˜Â© Ã˜Â¥Ã˜Â±Ã˜Â¬Ã˜Â§Ã˜Â¹ Ã™â€žÃ™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯

    // Drawer
    public DbSet<DrawerSession> DrawerSessions => Set<DrawerSession>();       // Ã˜Â¬Ã™â€žÃ˜Â³Ã˜Â§Ã˜Âª Ã™ÂÃ˜ÂªÃ˜Â­/Ã™â€šÃ™ÂÃ™â€ž Ã˜Â§Ã™â€žÃ˜Â¯Ã˜Â±Ã˜Â¬ (Ã˜Â±Ã˜ÂµÃ™Å Ã˜Â¯ Ã˜Â§Ã™ÂÃ˜ÂªÃ˜ÂªÃ˜Â§Ã˜Â­Ã™Å  Ã™Ë†Ã˜Â®Ã˜ÂªÃ˜Â§Ã™â€¦Ã™Å )
    public DbSet<DrawerTransaction> DrawerTransactions => Set<DrawerTransaction>();  // Ã™Æ’Ã™â€ž Ã˜Â­Ã˜Â±Ã™Æ’Ã˜Â© Ã™â€¦Ã˜Â§Ã™â€žÃ™Å Ã˜Â© Ã™ÂÃ˜Â¹Ã™â€žÃ™Å Ã˜Â© (Ã˜Â¥Ã™Å Ã˜Â±Ã˜Â§Ã˜Â¯/Ã˜ÂµÃ˜Â§Ã˜Â¯Ã˜Â±) Ã™ÂÃ™Å  Ã˜Â§Ã™â€žÃ˜Â¯Ã˜Â±Ã˜Â¬

    public DbSet<Safe> Safes => Set<Safe>();
    public DbSet<SafeTransaction> SafeTransactions => Set<SafeTransaction>();
    public DbSet<ExpenseCategory> ExpenseCategories => Set<ExpenseCategory>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<OwnerTransaction> OwnerTransactions => Set<OwnerTransaction>();
    public DbSet<TransactionSourcePolicy> TransactionSourcePolicies => Set<TransactionSourcePolicy>();

    // Wallets
    public DbSet<Wallet> Wallets => Set<Wallet>();
    public DbSet<WalletTransaction> WalletTransactions => Set<WalletTransaction>();
    public DbSet<WalletOperation> WalletOperations => Set<WalletOperation>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal(18, 4)");
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Safe>().HasData(
            new Safe
            {
                Id = DefaultSafe.MainSafeId,
                Name = DefaultSafe.MainSafeName,
                Balance = 0,
                IsMain = true,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(string)
                    && property.GetMaxLength() is null
                    && (property.Name == "Id" || property.Name.EndsWith("Id", StringComparison.Ordinal)))
                {
                    property.SetMaxLength(36);
                }
            }
        }
        var cascadeFKs = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade
                      && !fk.IsOwnership
                      && !fk.DeclaringEntityType.ClrType.Namespace!.Contains("Identity")
                      && !typeof(IdentityUser).IsAssignableFrom(fk.PrincipalEntityType.ClrType));

        foreach (var fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
                var condition = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(condition, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }


    public override int SaveChanges()
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditAndSoftDelete()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is BaseEntity baseEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        baseEntity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        baseEntity.UpdatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        baseEntity.IsDeleted = true;
                        baseEntity.DeletedAt = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
```

## File: Persistence/EntitiesConfigurations/CategoryConfiguration.cs
```csharp
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name).HasMaxLength(150).IsRequired();

        builder.HasOne(c => c.Department)
            .WithMany(d => d.Categories)
            .HasForeignKey(c => c.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
```

## File: Persistence/EntitiesConfigurations/CustomerConfiguration.cs
```csharp
using Centraly.Api.Entities.Customers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Name).HasMaxLength(150);
        builder.Property(c => c.Phone).HasMaxLength(20);
        builder.Property(c => c.DebtBalance).HasColumnType("decimal(18,2)");
    }
}
```

## File: Persistence/EntitiesConfigurations/CustomerDebtPaymentConfiguration.cs
```csharp
using Centraly.Api.Entities.Customers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class CustomerDebtPaymentConfiguration : IEntityTypeConfiguration<CustomerDebtPayment>
{
    public void Configure(EntityTypeBuilder<CustomerDebtPayment> builder)
    {
        builder.Property(c => c.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(c => c.Customer)
            .WithMany(c => c.DebtPayments)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.DrawerTransaction)
            .WithMany()
            .HasForeignKey(c => c.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(c => c.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
```

## File: Persistence/EntitiesConfigurations/DepartmentConfiguration.cs
```csharp
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Name).HasMaxLength(150).IsRequired();
    }
}
```

## File: Persistence/EntitiesConfigurations/DrawerSessionConfiguration.cs
```csharp
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class DrawerSessionConfiguration : IEntityTypeConfiguration<DrawerSession>
{
    public void Configure(EntityTypeBuilder<DrawerSession> builder)
    {
        builder.Property(d => d.OpeningBalance).HasColumnType("decimal(18,2)");
        builder.Property(d => d.TotalIncome).HasColumnType("decimal(18,2)");
        builder.Property(d => d.TotalExpense).HasColumnType("decimal(18,2)");
        builder.Property(d => d.ClosingBalance).HasColumnType("decimal(18,2)");
    }
}
```

## File: Persistence/EntitiesConfigurations/DrawerTransactionConfiguration.cs
```csharp
using Centraly.Api.Entities.Drawer;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class DrawerTransactionConfiguration : IEntityTypeConfiguration<DrawerTransaction>
{
    public void Configure(EntityTypeBuilder<DrawerTransaction> builder)
    {
        builder.Property(d => d.Amount).HasColumnType("decimal(18,2)");
        builder.Property(d => d.Balance).HasColumnType("decimal(18,2)");

        builder.HasOne(d => d.DrawerSession)
            .WithMany(s => s.Transactions)
            .HasForeignKey(d => d.DrawerSessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_DrawerTransaction_Amount", "[Amount] >= 0"));
    }
}
```

## File: Persistence/EntitiesConfigurations/InvoiceConfiguration.cs
```csharp
using Centraly.Api.Entities.Sales;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(i => i.InvoiceNumber).HasMaxLength(50).IsRequired();
        builder.Property(i => i.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(i => i.PaidAmount).HasColumnType("decimal(18,2)");

        builder.HasIndex(i => i.InvoiceNumber)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        builder.HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.DrawerTransaction)
            .WithMany()
            .HasForeignKey(i => i.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(i => i.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Invoice_PaidAmount", "[PaidAmount] >= 0 AND [PaidAmount] <= [TotalAmount]"));
    }
}
```

## File: Persistence/EntitiesConfigurations/InvoiceItemConfiguration.cs
```csharp
using Centraly.Api.Entities.Sales;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.Property(ii => ii.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(ii => ii.UnitCost).HasColumnType("decimal(18,2)");

        builder.HasOne(ii => ii.Invoice)
            .WithMany(i => i.Items)
            .HasForeignKey(ii => ii.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ii => ii.Product)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(ii => ii.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_InvoiceItem_Quantity", "[Quantity] > 0"));
    }
}
```

## File: Persistence/EntitiesConfigurations/MaintenanceDeviceConfiguration.cs
```csharp
using Centraly.Api.Entities.Maintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class MaintenanceDeviceConfiguration : IEntityTypeConfiguration<MaintenanceDevice>
{
    public void Configure(EntityTypeBuilder<MaintenanceDevice> builder)
    {
        builder.Property(m => m.ServicePrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.TotalPartsPrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.TotalCost).HasColumnType("decimal(18,2)");
        builder.Property(m => m.TotalPrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.PaidAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(m => m.Customer)
            .WithMany(c => c.MaintenanceDevices)
            .HasForeignKey(m => m.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.DrawerTransaction)
            .WithMany()
            .HasForeignKey(m => m.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_MaintenanceDevice_PaidAmount", "[PaidAmount] >= 0"));
    }
}
```

## File: Persistence/EntitiesConfigurations/MaintenanceProductItemConfiguration.cs
```csharp
using Centraly.Api.Entities.Maintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class MaintenanceProductItemConfiguration : IEntityTypeConfiguration<MaintenanceProductItem>
{
    public void Configure(EntityTypeBuilder<MaintenanceProductItem> builder)
    {
        builder.Property(m => m.MaintenancePrice).HasColumnType("decimal(18,2)");
        builder.Property(m => m.CostPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(m => m.MaintenanceDevice)
            .WithMany(md => md.ProductsUsed)
            .HasForeignKey(m => m.MaintenanceDeviceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Product)
            .WithMany()
            .HasForeignKey(m => m.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_MaintenanceProductItem_Quantity", "[Quantity] > 0"));
    }
}
```

## File: Persistence/EntitiesConfigurations/ProductConfiguration.cs
```csharp
using Centraly.Api.Entities.Inventory;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(200);

        // Fix: Barcode مش بينتهي بـ "Id" فمش بياخد الـ MaxLength convention العامة
        // في ApplicationDbContext تلقائيًا. لازم MaxLength صريح هنا لأنه داخل في
        // Unique Filtered Index تحت، وSQL Server مش بيسمح بعمود nvarchar(max)
        // يبقى جزء من Index.
        builder.Property(p => p.Barcode).HasMaxLength(64);


        // بديل عن Unique عادي - عشان الـ Soft Delete متعارضش معاه
        builder.HasIndex(p => p.Barcode)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0 AND [Barcode] IS NOT NULL");

        builder.HasOne(p => p.Department)
            .WithMany(d => d.Products)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_Product_Quantity", "[Quantity] >= 0"));
        builder.ToTable(t => t.HasCheckConstraint("CK_Product_MinQuantityAlert", "[MinQuantityAlert] >= 0"));
    }
}
```

## File: Persistence/EntitiesConfigurations/PurchaseInvoiceConfiguration.cs
```csharp
using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class PurchaseInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
{
    public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
    {
        builder.Property(pi => pi.InvoiceNumber).HasMaxLength(50).IsRequired();
        builder.Property(pi => pi.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(pi => pi.PaidAmount).HasColumnType("decimal(18,2)");

        builder.HasIndex(pi => pi.InvoiceNumber)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        builder.HasOne(pi => pi.Supplier)
            .WithMany(s => s.PurchaseInvoices)
            .HasForeignKey(pi => pi.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pi => pi.DrawerTransaction)
            .WithMany()
            .HasForeignKey(pi => pi.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(pi => pi.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");

        builder.ToTable(t => t.HasCheckConstraint(
            "CK_PurchaseInvoice_PaidAmount", "[PaidAmount] >= 0 AND [PaidAmount] <= [TotalAmount]"));
    }
}
```

## File: Persistence/EntitiesConfigurations/PurchaseInvoiceItemConfiguration.cs
```csharp
using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class PurchaseInvoiceItemConfiguration : IEntityTypeConfiguration<PurchaseInvoiceItem>
{
    public void Configure(EntityTypeBuilder<PurchaseInvoiceItem> builder)
    {
        builder.Property(pii => pii.UnitCost).HasColumnType("decimal(18,2)");

        builder.HasOne(pii => pii.PurchaseInvoice)
            .WithMany(pi => pi.Items)
            .HasForeignKey(pii => pii.PurchaseInvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pii => pii.Product)
            .WithMany(p => p.PurchaseInvoiceItems)
            .HasForeignKey(pii => pii.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_PurchaseInvoiceItem_Quantity", "[Quantity] > 0"));
    }
}
```

## File: Persistence/EntitiesConfigurations/ReturnItemConfiguration.cs
```csharp
using Centraly.Api.Entities.Returns;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class ReturnItemConfiguration : IEntityTypeConfiguration<ReturnItem>
{
    public void Configure(EntityTypeBuilder<ReturnItem> builder)
    {
        builder.Property(ri => ri.UnitPrice).HasColumnType("decimal(18,2)");

        builder.HasOne(ri => ri.ReturnRecord)
            .WithMany(r => r.Items)
            .HasForeignKey(ri => ri.ReturnRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ri => ri.Product)
            .WithMany(p => p.ReturnItems)
            .HasForeignKey(ri => ri.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
```

## File: Persistence/EntitiesConfigurations/ReturnRecordConfiguration.cs
```csharp
using Centraly.Api.Entities.Returns;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class ReturnRecordConfiguration : IEntityTypeConfiguration<ReturnRecord>
{
    public void Configure(EntityTypeBuilder<ReturnRecord> builder)
    {
        builder.Property(r => r.TotalReturnedAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(r => r.Invoice)
            .WithMany(i => i.Returns)
            .HasForeignKey(r => r.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.DrawerTransaction)
            .WithMany()
            .HasForeignKey(r => r.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => r.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
```

## File: Persistence/EntitiesConfigurations/RoleConfiguration.cs
```csharp
namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        //Default Data
        builder.HasData([
            new ApplicationRole
            {
                Id = DefaultRoles.Admin.Id,
                Name = DefaultRoles.Admin.Name,
                NormalizedName = DefaultRoles.Admin.Name.ToUpper(),
                ConcurrencyStamp = DefaultRoles.Admin.ConcurrencyStamp
            }
        ,
        new ApplicationRole
        {
            Id = DefaultRoles.Manager.Id,
            Name = DefaultRoles.Manager.Name,
            NormalizedName = DefaultRoles.Manager.Name.ToUpper(),
            ConcurrencyStamp = DefaultRoles.Manager.ConcurrencyStamp
        }
        ,
        new ApplicationRole
        {
            Id = DefaultRoles.Salesperson.Id,
            Name = DefaultRoles.Salesperson.Name,
            NormalizedName = DefaultRoles.Salesperson.Name.ToUpper(),
            ConcurrencyStamp = DefaultRoles.Salesperson.ConcurrencyStamp
        }
        ,
        new ApplicationRole
        {
            Id = DefaultRoles.Technician.Id,
            Name = DefaultRoles.Technician.Name,
            NormalizedName = DefaultRoles.Technician.Name.ToUpper(),
            ConcurrencyStamp = DefaultRoles.Technician.ConcurrencyStamp
        }

        ]);
    }
}
```

## File: Persistence/EntitiesConfigurations/SupplierConfiguration.cs
```csharp
using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.Property(s => s.Name).HasMaxLength(150).IsRequired();
        builder.Property(s => s.Phone).HasMaxLength(20);
        builder.Property(s => s.DebtBalance).HasColumnType("decimal(18,2)");
    }
}
```

## File: Persistence/EntitiesConfigurations/SupplierPaymentConfiguration.cs
```csharp
using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierPaymentConfiguration : IEntityTypeConfiguration<SupplierPayment>
{
    public void Configure(EntityTypeBuilder<SupplierPayment> builder)
    {
        builder.Property(sp => sp.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(sp => sp.Supplier)
            .WithMany(s => s.Payments)
            .HasForeignKey(sp => sp.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sp => sp.DrawerTransaction)
            .WithMany()
            .HasForeignKey(sp => sp.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(sp => sp.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
```

## File: Persistence/EntitiesConfigurations/SupplierReturnConfiguration.cs
```csharp
using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierReturnConfiguration : IEntityTypeConfiguration<SupplierReturn>
{
    public void Configure(EntityTypeBuilder<SupplierReturn> builder)
    {
        builder.Property(sr => sr.TotalReturnedAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(sr => sr.Supplier)
            .WithMany(s => s.Returns)
            .HasForeignKey(sr => sr.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sr => sr.DrawerTransaction)
            .WithMany()
            .HasForeignKey(sr => sr.DrawerTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(sr => sr.DrawerTransactionId)
            .IsUnique()
            .HasFilter("[DrawerTransactionId] IS NOT NULL");
    }
}
```

## File: Persistence/EntitiesConfigurations/SupplierReturnItemConfiguration.cs
```csharp
using Centraly.Api.Entities.Suppliers;

namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class SupplierReturnItemConfiguration : IEntityTypeConfiguration<SupplierReturnItem>
{
    public void Configure(EntityTypeBuilder<SupplierReturnItem> builder)
    {
        builder.Property(sri => sri.UnitCost).HasColumnType("decimal(18,2)");

        builder.HasOne(sri => sri.SupplierReturn)
            .WithMany(sr => sr.Items)
            .HasForeignKey(sri => sri.SupplierReturnId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sri => sri.Product)
            .WithMany(p => p.SupplierReturnItems)
            .HasForeignKey(sri => sri.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
```

## File: Persistence/EntitiesConfigurations/UserConfiguration.cs
```csharp
namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasMany(x => x.RefreshTokens)
           .WithOne()
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Cascade);
        builder.Navigation(x => x.RefreshTokens).AutoInclude(false);

        builder.HasData([new ApplicationUser
        {
            Id = DefaultUsers.Admin.Id,
            UserName = DefaultUsers.Admin.Email,
            NormalizedUserName = DefaultUsers.Admin.Email.ToUpper(),
            Email = DefaultUsers.Admin.Email,
            NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Admin.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Admin.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new ApplicationUser
        {
            Id = DefaultUsers.Manager.Id,
            UserName = DefaultUsers.Manager.Email,
            NormalizedUserName = DefaultUsers.Manager.Email.ToUpper(),
            Email = DefaultUsers.Manager.Email,
            NormalizedEmail = DefaultUsers.Manager.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Manager.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Manager.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Manager.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new ApplicationUser
        {
            Id = DefaultUsers.Salesperson.Id,
            UserName = DefaultUsers.Salesperson.Email,
            NormalizedUserName = DefaultUsers.Salesperson.Email.ToUpper(),
            Email = DefaultUsers.Salesperson.Email,
            NormalizedEmail = DefaultUsers.Salesperson.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Salesperson.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Salesperson.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Salesperson.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        },
        new ApplicationUser
        {
            Id = DefaultUsers.Technician.Id,
            UserName = DefaultUsers.Technician.Email,
            NormalizedUserName = DefaultUsers.Technician.Email.ToUpper(),
            Email = DefaultUsers.Technician.Email,
            NormalizedEmail = DefaultUsers.Technician.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Technician.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Technician.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Technician.PasswordHash,
            CreatedAt = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
        }

        ]);
    }
}
```

## File: Persistence/EntitiesConfigurations/UserRoleConfiguration.cs
```csharp
namespace Centraly.Api.Persistence.EntitiesConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Admin.Id,
                RoleId = DefaultRoles.Admin.Id
            },
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Manager.Id,
                RoleId = DefaultRoles.Manager.Id
            },
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Salesperson.Id,
                RoleId = DefaultRoles.Salesperson.Id
            },
            new IdentityUserRole<string>
            {
                UserId = DefaultUsers.Technician.Id,
                RoleId = DefaultRoles.Technician.Id
            }
        );
    }
}
```

## File: Program.cs
```csharp
using Centraly.Api;
using Hangfire;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddAuthorization(options =>
{
    foreach (var permission in Centraly.Api.Abstractions.Consts.Permissions.GetAllPermissions())
    {
        if (!string.IsNullOrEmpty(permission))
        {
            options.AddPolicy(permission, policy => policy.RequireClaim(Centraly.Api.Abstractions.Consts.Permissions.Type, permission));
        }
    }
});

var app = builder.Build();

app.UseMiddleware<Centraly.Api.Middlewares.GlobalCancellationMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    Authorization =
    [
        new HangfireCustomBasicAuthenticationFilter
        {
            User = app.Configuration.GetValue<string>("HangfireSettings:Username"),
            Pass = app.Configuration.GetValue<string>("HangfireSettings:Password")
        }
    ],
    DashboardTitle = "3lmny Dashboard",
    //IsReadOnlyFunc = (DashboardContext context) => true 
});
app.UseHttpsRedirection();

app.UseCors();

// Ensure uploads directory exists
var uploadsPath = Path.Combine(builder.Environment.ContentRootPath, "uploads");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

// Serve files from uploads folder
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();



// =====================================================================
// Ø®Ø·Ø© Ø¨Ù†Ø§Ø¡ Ø§Ù„Ù€ Services - ØªØ±ØªÙŠØ¨ Ø­Ø³Ø¨ Ø§Ù„Ù€ Dependencies + Ø´Ø±Ø­ Ù…Ø³Ø¤ÙˆÙ„ÙŠØ© ÙƒÙ„ ÙˆØ§Ø­Ø¯Ø©
// =====================================================================

// 1) Ø§Ù„Ø·Ø¨Ù‚Ø© Ø§Ù„Ø£Ø³Ø§Ø³ÙŠØ© (Ù…ÙÙŠÙ‡Ø§Ø´ Dependencies) //done

// - DepartmentService
//   CRUD Ø¹Ø§Ø¯ÙŠ Ø¹Ù„Ù‰ Ø§Ù„Ø£Ù‚Ø³Ø§Ù… (Department). Ù…ÙÙŠÙ‡Ø§Ø´ Ù…Ù†Ø·Ù‚ Ù…Ø¹Ù‚Ø¯ØŒ Ø¨Ø³ ØªØ£ÙƒØ¯ Ø¥Ù†
//   Ø§Ù„Ø­Ø°Ù Soft Delete ÙˆØ¥Ù†Ùƒ Ø¨ØªØªØ­Ù‚Ù‚ Ø¥Ù† Ù…ÙÙŠØ´ Categories/Products Ù…Ø±ØªØ¨Ø·Ø©
//   Ù‚Ø¨Ù„ Ù…Ø§ ØªÙ…Ù†Ø¹ Ø£Ùˆ ØªØ³Ù…Ø­ Ø¨Ø§Ù„Ø­Ø°Ù.

// - CustomerService         //done
//   CRUD Ø¹Ù„Ù‰ Ø§Ù„Ø¹Ù…Ù„Ø§Ø¡ (Ø§Ø³Ù…ØŒ ØªÙ„ÙŠÙÙˆÙ†). Ø¨Ø±Ø¶Ù‡ Ø¨ÙŠÙˆÙØ± Ø¯Ø§Ù„Ø© Ø²ÙŠ
//   GetCustomerWithDebtHistory Ø§Ù„Ù„ÙŠ Ø¨ØªØ±Ø¬Ø¹ Ø§Ù„Ø¹Ù…ÙŠÙ„ Ù…Ø¹ Ø§Ù„ÙÙˆØ§ØªÙŠØ± Ø§Ù„Ø¢Ø¬Ù„Ø©
//   ÙˆØ§Ù„Ø¯ÙØ¹Ø§Øª Ø¨ØªØ§Ø¹ØªÙ‡ Ø¹Ø´Ø§Ù† Ø´Ø§Ø´Ø© "ÙƒØ´Ù Ø­Ø³Ø§Ø¨ Ø§Ù„Ø¹Ù…ÙŠÙ„".

// - SupplierService  
//   CRUD Ø¹Ù„Ù‰ Ø§Ù„Ù…ÙˆØ±Ø¯ÙŠÙ†. Ù†ÙØ³ ÙÙƒØ±Ø© CustomerService Ø¨Ø³ Ù„Ù„Ø·Ø±Ù Ø§Ù„ØªØ§Ù†ÙŠ
//   (Ù…ÙˆØ±Ø¯ Ø¨Ø¯Ù„ Ø¹Ù…ÙŠÙ„) â€” GetSupplierWithDebtHistory Ù„ÙƒØ´Ù Ø­Ø³Ø§Ø¨ Ø§Ù„Ù…ÙˆØ±Ø¯.

// - SparePartService
//   CRUD Ø¹Ù„Ù‰ Ù‚Ø·Ø¹ Ø§Ù„ØºÙŠØ§Ø± + Ø¯Ø§Ù„Ø© Ù„Ø²ÙŠØ§Ø¯Ø©/Ø¥Ù†Ù‚Ø§Øµ Ø§Ù„ÙƒÙ…ÙŠØ© (AdjustQuantity)
//   ØªØ³ØªØ®Ø¯Ù…Ù‡Ø§ MaintenanceService Ù„Ù…Ø§ ØªØ³ØªÙ‡Ù„Ùƒ Ù‚Ø·Ø¹Ø© ÙÙŠ Ø¬Ù‡Ø§Ø² ØµÙŠØ§Ù†Ø©.

// 2) Ø¹Ù„ÙŠÙ‡Ø§ Dependency Ø¨Ø³ÙŠØ·

// - CategoryService
//   CRUD Ø¹Ù„Ù‰ Ø§Ù„ØªØµÙ†ÙŠÙØ§ØªØŒ Ø¨Ø³ Ø¨ÙŠØªØ­Ù‚Ù‚ Ø¥Ù† Ø§Ù„Ù€ DepartmentId Ø§Ù„Ù…Ø±Ø³Ù„ Ù…ÙˆØ¬ÙˆØ¯
//   ÙØ¹Ù„Ø§Ù‹ Ù‚Ø¨Ù„ Ø§Ù„Ø¥Ø¶Ø§ÙØ© (Ø¹Ù„Ø§Ù‚Ø© Ø¥Ù„Ø²Ø§Ù…ÙŠØ© Ø²ÙŠ Ù…Ø§ Ø§ØªÙÙ‚Ù†Ø§).

// - ProductService
//   CRUD Ø¹Ù„Ù‰ Ø§Ù„Ù…Ù†ØªØ¬Ø§Øª + Ø§Ù„ØªØ­Ù‚Ù‚ Ù…Ù† ØªÙƒØ±Ø§Ø± Ø§Ù„Ù€ Barcode (Ø¨Ø³Ø¨Ø¨ Ø§Ù„Ù€ Unique
//   Filtered Index). ÙƒÙ…Ø§Ù† Ø¨ÙŠÙˆÙØ± GetLowStockProducts Ùˆ
//   GetOutOfStockProducts Ù„Ù„ØªÙ†Ø¨ÙŠÙ‡Ø§ØªØŒ ÙˆØ¯Ø§Ù„Ø© AdjustQuantity Ø¯Ø§Ø®Ù„ÙŠØ©
//   (Ø²ÙŠØ§Ø¯Ø©/Ù†Ù‚ØµØ§Ù†) Ù‡ØªØ³ØªØ®Ø¯Ù…Ù‡Ø§ ÙƒÙ„ Ø®Ø¯Ù…Ø§Øª Ø§Ù„Ø¨ÙŠØ¹ ÙˆØ§Ù„ØªÙˆØ±ÙŠØ¯ ÙˆØ§Ù„Ù…Ø±ØªØ¬Ø¹Ø§Øª.

// 3) Ø§Ù„Ù…Ø­Ø±Ùƒ Ø§Ù„Ù…Ø§Ù„ÙŠ - Ù„Ø§Ø²Ù… ÙŠØ®Ù„Øµ Ù‚Ø¨Ù„ Ø£ÙŠ Transaction

// - DrawerService
//   - OpenSession: ÙØªØ­ Ø¬Ù„Ø³Ø© Ø¬Ø¯ÙŠØ¯Ø© Ø¨Ø±ØµÙŠØ¯ Ø§ÙØªØªØ§Ø­ÙŠ (Ù„Ùˆ Ù…ÙÙŠØ´ Ø¬Ù„Ø³Ø© Ù…ÙØªÙˆØ­Ø©
//     Ø£ØµÙ„Ø§Ù‹ØŒ Ù„Ø§Ø²Ù… ØªÙ…Ù†Ø¹ ÙØªØ­ Ø¬Ù„Ø³ØªÙŠÙ† ÙÙŠ Ù†ÙØ³ Ø§Ù„ÙˆÙ‚Øª).
//   - CloseSession: Ù‚ÙÙ„ Ø§Ù„Ø¬Ù„Ø³Ø©ØŒ Ø­Ø³Ø§Ø¨ TotalIncome/TotalExpense/ClosingBalance
//     Ù…Ù† Ù…Ø¬Ù…ÙˆØ¹ Ø§Ù„Ù€ DrawerTransactions Ø¨ØªØ§Ø¹ØªÙ‡Ø§.
//   - RecordTransaction: Ø§Ù„Ø¯Ø§Ù„Ø© Ø§Ù„Ù…Ø±ÙƒØ²ÙŠØ© Ø§Ù„Ù„ÙŠ Ø£ÙŠ Service ØªØ§Ù†ÙŠ Ù‡ÙŠÙ†Ø§Ø¯ÙŠÙ‡Ø§
//     Ø¹Ø´Ø§Ù† ÙŠØ³Ø¬Ù„ Ø­Ø±ÙƒØ© Ù…Ø§Ù„ÙŠØ© (Income/Expense) Ù…Ø±Ø¨ÙˆØ·Ø© Ø¨Ø§Ù„Ù€ Category Ø¨ØªØ§Ø¹ØªÙ‡Ø§
//     (Ù…Ø¨ÙŠØ¹Ø§Øª/Ù…ÙˆØ±Ø¯ÙŠÙ†/ØµÙŠØ§Ù†Ø©/Ù…Ø±ØªØ¬Ø¹Ø§Øª...)ØŒ ÙˆØ¨ØªØ±Ø¬Ø¹ Ø§Ù„Ù€ DrawerTransactionId
//     Ø¹Ø´Ø§Ù† Ø§Ù„Ø®Ø¯Ù…Ø© Ø§Ù„Ù„ÙŠ Ù†Ø§Ø¯Øª Ø¹Ù„ÙŠÙ‡Ø§ ØªØ±Ø¨Ø·Ù‡ Ø¨Ø§Ù„Ù€ Entity Ø¨ØªØ§Ø¹ØªÙ‡Ø§ (Invoice,
//     PurchaseInvoice... Ø¥Ù„Ø®).
//   - GetCurrentBalance: Ø§Ù„Ø±ØµÙŠØ¯ Ø§Ù„Ø­Ø§Ù„ÙŠ Ù„Ù„Ø¬Ù„Ø³Ø© Ø§Ù„Ù…ÙØªÙˆØ­Ø©.

// 4) Ø®Ø¯Ù…Ø§Øª Ø§Ù„Ù€ Transactions

// - InvoiceService (Ø¨ÙŠØ¹)
//   Ø¥Ù†Ø´Ø§Ø¡ ÙØ§ØªÙˆØ±Ø© Ø¨ÙŠØ¹: Ø¨ØªØªØ­Ù‚Ù‚ Ù…Ù† ØªÙˆÙØ± Ø§Ù„ÙƒÙ…ÙŠØ© ÙÙŠ Ø§Ù„Ù…Ø®Ø²ÙˆÙ† Ù„ÙƒÙ„ ItemØŒ
//   Ø¨ØªÙ†Ù‚Øµ Product.QuantityØŒ Ø¨ØªØ­Ø³Ø¨ TotalAmount Ù…Ù† Ø§Ù„Ø£ØµÙ†Ø§ÙØŒ ÙˆÙ„Ùˆ
//   PaymentMethod = Deferred Ø¨ØªØ²ÙˆÙ‘Ø¯ Customer.DebtBalance Ø¨Ø§Ù„Ù…ØªØ¨Ù‚ÙŠ.
//   Ø¨Ø¹Ø¯ Ø§Ù„Ø­ÙØ¸ Ø¨ØªÙ†Ø§Ø¯ÙŠ DrawerService.RecordTransaction Ø¨Ù…Ø¨Ù„Øº PaidAmount
//   (Ø§Ù„Ù„ÙŠ Ø§ØªØ¯ÙØ¹ ÙƒØ§Ø´ ÙØ¹Ù„Ø§Ù‹ Ø¨Ø³ØŒ Ù…Ø´ TotalAmount).

// - ReturnService (Ù…Ø±ØªØ¬Ø¹ Ø¹Ù…ÙŠÙ„)
//   Ø¨ØªØ§Ø®Ø¯ InvoiceId Ù…ÙˆØ¬ÙˆØ¯ØŒ Ø¨ØªØªØ­Ù‚Ù‚ Ø¥Ù† Ø§Ù„ÙƒÙ…ÙŠØ© Ø§Ù„Ù…Ø±ØªØ¬Ø¹Ø© Ù…Ø´ Ø£ÙƒØ¨Ø± Ù…Ù†
//   Ø§Ù„Ù…Ø¨Ø§Ø¹Ø©ØŒ Ø¨ØªØ±Ø¬Ø¹ Ø§Ù„ÙƒÙ…ÙŠØ© Ù„Ù€ Product.QuantityØŒ ÙˆØ¨ØªØ³Ø¬Ù„ DrawerTransaction
//   ÙƒÙ€ Expense (ÙÙ„ÙˆØ³ Ø¨ØªØ±Ø¬Ø¹ Ù„Ù„Ø¹Ù…ÙŠÙ„) Ù„Ùˆ Ø§Ù„Ø¥Ø±Ø¬Ø§Ø¹ ÙƒØ§Ø´.

// - PurchaseInvoiceService (ØªÙˆØ±ÙŠØ¯)
//   Ø¥Ù†Ø´Ø§Ø¡ ÙØ§ØªÙˆØ±Ø© Ø´Ø±Ø§Ø¡ Ù…Ù† Ù…ÙˆØ±Ø¯: Ø¨ØªØ²ÙˆÙ‘Ø¯ Product.Quantity Ù„ÙƒÙ„ ItemØŒ
//   ÙˆØ¨ØªØ­Ø¯Ù‘Ø« Product.PurchasePrice Ø¨Ø¢Ø®Ø± Ø³Ø¹Ø± Ø´Ø±Ø§Ø¡. Ù„Ùˆ Ù…Ø´ Ù‡ØªØ¯ÙØ¹ ÙƒÙ„
//   Ø§Ù„Ù…Ø¨Ù„Øº ÙƒØ§Ø´ØŒ Ø§Ù„ÙØ±Ù‚ Ø¨ÙŠØªØ¶Ø§Ù Ù„Ù€ Supplier.DebtBalance. Ù„Ùˆ Ø¯ÙØ¹Øª Ø¬Ø²Ø¡
//   ÙƒØ§Ø´ØŒ Ø¨ØªØ³Ø¬Ù„ DrawerTransaction ÙƒÙ€ Expense.

// - SupplierPaymentService
//   ØªØ³Ø¯ÙŠØ¯ Ø¬Ø²Ø¡ Ù…Ù† Ù…Ø¯ÙŠÙˆÙ†ÙŠØ© Ø§Ù„Ù…ÙˆØ±Ø¯: Ø¨ØªÙ†Ù‚Øµ Supplier.DebtBalance ÙˆØ¨ØªØ³Ø¬Ù„
//   DrawerTransaction ÙƒÙ€ Expense.

// - SupplierReturnService
//   Ø¥Ø±Ø¬Ø§Ø¹ Ø¨Ø¶Ø§Ø¹Ø© Ù„Ù…ÙˆØ±Ø¯: Ø¨ØªÙ†Ù‚Øµ Product.QuantityØŒ ÙˆØ¨ØªÙ†Ù‚Øµ
//   Supplier.DebtBalance (Ø£Ùˆ ØªØ³Ø¬Ù„ DrawerTransaction ÙƒÙ€ Income Ù„Ùˆ
//   Ø§Ø³ØªØ±Ø¯ÙŠØª ÙÙ„ÙˆØ³ ÙƒØ§Ø´ Ø¨Ø¯Ù„ Ø®ØµÙ…Ù‡Ø§ Ù…Ù† Ø§Ù„Ù…Ø¯ÙŠÙˆÙ†ÙŠØ©).

// - CustomerDebtPaymentService
//   ØªØ³Ø¯ÙŠØ¯ Ø¬Ø²Ø¡ Ù…Ù† Ù…Ø¯ÙŠÙˆÙ†ÙŠØ© Ø§Ù„Ø¹Ù…ÙŠÙ„: Ø¨ØªÙ†Ù‚Øµ Customer.DebtBalance ÙˆØ¨ØªØ³Ø¬Ù„
//   DrawerTransaction ÙƒÙ€ Income.

// - MaintenanceService
//   ØªØ³Ø¬ÙŠÙ„ Ø¬Ù‡Ø§Ø² ØµÙŠØ§Ù†Ø© Ø¬Ø¯ÙŠØ¯ØŒ ØªØ­Ø¯ÙŠØ« Ø­Ø§Ù„ØªÙ‡ (Pending/Delivered/Returned)ØŒ
//   ÙˆØ±Ø¨Ø· Ù‚Ø·Ø¹ Ø§Ù„ØºÙŠØ§Ø± Ø§Ù„Ù…Ø³ØªØ®Ø¯Ù…Ø© Ø¹Ù† Ø·Ø±ÙŠÙ‚ SparePartUsage (Ø¨ØªÙ†Ù‚Øµ
//   SparePart.Quantity Ù…Ù† Ø®Ù„Ø§Ù„ SparePartService.AdjustQuantity).
//   Ù„Ù…Ø§ Ø§Ù„Ø¬Ù‡Ø§Ø² ÙŠØªØ³Ù„Ù‘Ù… ÙˆÙŠØªØ­ØµÙ‘Ù„ ØªÙ…Ù†Ù‡ØŒ Ø¨ØªØ³Ø¬Ù„ DrawerTransaction ÙƒÙ€ Income.

// 5) Ø¢Ø®Ø± Ø­Ø§Ø¬Ø©

// - ReportService / DashboardService
//   Ù‚Ø±Ø§Ø¡Ø© Ø¨Ø³ØŒ Ù…ÙÙŠØ´ ØªØ¹Ø¯ÙŠÙ„ Ø¹Ù„Ù‰ Ø£ÙŠ Ø¨ÙŠØ§Ù†Ø§Øª. Ø¨ÙŠØ¬Ù…Ù‘Ø¹ Ù…Ù† ÙƒÙ„ Ø§Ù„Ø¬Ø¯Ø§ÙˆÙ„ ÙÙˆÙ‚:
//   Ø¥Ø¬Ù…Ø§Ù„ÙŠ Ø§Ù„Ù…Ø¨ÙŠØ¹Ø§ØªØŒ ØµØ§ÙÙŠ Ø§Ù„Ø±Ø¨Ø­ (Ø¨ÙŠØ¹ - ØªÙƒÙ„ÙØ© Ù…Ù† UnitCost)ØŒ Ø£Ø¹Ù„Ù‰
//   Ø§Ù„Ù…Ù†ØªØ¬Ø§Øª Ù…Ø¨ÙŠØ¹Ù‹Ø§ØŒ ØªÙ†Ø¨ÙŠÙ‡Ø§Øª Ø§Ù„Ù…Ø®Ø²ÙˆÙ† Ø§Ù„Ù…Ù†Ø®ÙØ¶ØŒ Ù…Ø¯ÙŠÙˆÙ†ÙŠØ§Øª Ø§Ù„Ø¹Ù…Ù„Ø§Ø¡
//   ÙˆØ§Ù„Ù…ÙˆØ±Ø¯ÙŠÙ†ØŒ ÙˆÙ…Ù„Ø®Øµ Ø¬Ù„Ø³Ø§Øª Ø§Ù„Ø¯Ø±Ø¬.

// =====================================================================
// Ù…Ù„Ø§Ø­Ø¸Ø© Ù…Ù‡Ù…Ø©: DrawerService Ù„Ø§Ø²Ù… ÙŠØ®Ù„Øµ ÙÙˆØ±Ù‹Ø§ Ø¨Ø¹Ø¯ Ø§Ù„Ù…Ø±Ø­Ù„Ø© Ø§Ù„Ø£Ø³Ø§Ø³ÙŠØ©ØŒ
// Ù„Ø£Ù† Ø£ÙŠ Service Ø¨Ø¹Ø¯Ù‡ Ù‡ÙŠØ­ØªØ§Ø¬Ù‡ Ø¹Ø´Ø§Ù† ÙŠØ³Ø¬Ù„ Ø­Ø±ÙƒØ© Ù…Ø§Ù„ÙŠØ©. Ù„Ùˆ Ø¨Ù†ÙŠØªÙ‡ Ø§Ù„Ø¢Ø®Ø±
// Ù‡ØªØ¶Ø·Ø± ØªØ±Ø¬Ø¹Ù„Ù‡ ÙƒÙ„ Ø§Ù„Ù€ Services Ø§Ù„Ù„ÙŠ ÙØ§ØªØª.
// =====================================================================
```

## File: Properties/launchSettings.json
```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5081",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:7073;http://localhost:5081",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## File: repomix.config.json
```json
{
  "output": {
    "filePath": "ai-context.md",
    "style": "markdown"
  },
  "ignore": {
    "customPatterns": [
      "ai-context.md",
      "repomix-output.xml",
      "keys/**",
      "wwwroot/**",
      "**/*.xml",
      "**/*.csproj",
      "**/*.sln",
      "**/*.user",
      "**/*.designer.cs",
      "**/*.g.cs",
      "**/bin/**",
      "**/obj/**",
      "**/.vs/**",
      "**/Migrations/**"
    ]
  }
}

//repomix --include "Services/**"
```

## File: restore.py
```python
import os

path = r'C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Dependencies.cs'
with open(path, 'r', encoding='utf-8') as f:
    c = f.read()

services_add = '''
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.IProductService, Centraly.Api.Services.Implementation.ProductService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ISupplierService, Centraly.Api.Services.Implementation.SupplierService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ISupplierTransactionService, Centraly.Api.Services.Implementation.SupplierTransactionService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.IPurchaseInvoiceService, Centraly.Api.Services.Implementation.PurchaseInvoiceService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ISalesInvoiceService, Centraly.Api.Services.Implementation.SalesInvoiceService>();
        services.AddScoped<Centraly.Api.Services.Abstraction.ICustomerTransactionService, Centraly.Api.Services.Implementation.CustomerTransactionService>();
'''
c = c.replace('services.AddScoped<IAuthService, AuthService>();', services_add)

with open(path, 'w', encoding='utf-8') as f:
    f.write(c)
```

## File: script.csx
```
using System.IO;
using System.Text.RegularExpressions;

var path = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\DrawerService.cs";
var content = File.ReadAllText(path);

content = Regex.Replace(content, "public async Task<Result<DrawerSessionResponse>> GetActiveSessionAsync\\(CancellationToken", "public async Task<Result<DrawerSessionResponse>> GetActiveSessionAsync(int type = 1, CancellationToken");

content = Regex.Replace(content, "public async Task<Result<DrawerSessionResponse>> CloseSessionAsync\\(string userId, CancellationToken", "public async Task<Result<DrawerSessionResponse>> CloseSessionAsync(int type, string userId, CancellationToken");

content = Regex.Replace(content, @"s => !s\.IsClosed", @"s => !s.IsClosed && (int)s.Type == type");

content = Regex.Replace(content, @"AnyAsync\(s => !s\.IsClosed", @"AnyAsync(s => !s.IsClosed && (int)s.Type == request.Type");

content = Regex.Replace(content, @"var session = new DrawerSession\s*\{", "var session = new DrawerSession\n        {\n            Type = (DrawerType)request.Type,");

File.WriteAllText(path, content);
```

## File: Services/Abstraction/IAuthService.cs
```csharp
namespace Centraly.Api.Services;

public interface IAuthService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<Result<LoginResponse>> GetRefreshTokenAsync(
       string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result> RevokeRefreshTokenAsync(
        string token, string refreshToken, CancellationToken cancellationToken = default);
}
```

## File: Services/Abstraction/ICategoryService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Inventory.Categories;

namespace Centraly.Api.Services.Abstraction;

public interface ICategoryService
{
    Task<Result<CategoryResponse>> AddCategoryAsync(CreateCategoryRequest request, string? userId, CancellationToken ct = default);
    Task<Result<CategoryResponse>> GetCategoryAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<CategoryResponse>>> GetAllCategoriesAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<CategoryResponse>> UpdateCategoryAsync(string id, UpdateCategoryRequest request, string? userId, CancellationToken ct = default);
    Task<Result<bool>> DeleteCategoryAsync(string id, CancellationToken ct = default);
}
```

## File: Services/Abstraction/ICustomerService.cs
```csharp
using Centraly.Api.Contracts.Customers;

namespace Centraly.Api.Services.Abstraction;

public interface ICustomerService
{
    Task<Result<CustomerResponse>> AddCustomerAsync(
        CreateCustomerRequest request, string? userId, CancellationToken ct = default);

    Task<Result<CustomerResponse>> GetCustomerAsync(
        string id, CancellationToken ct = default);

    Task<Result<PaginatedList<CustomerResponse>>> GetAllCustomersAsync(
        RequestFilters filters, CancellationToken ct = default);

    Task<Result<CustomerDebtHistoryResponse>> GetCustomerWithDebtHistoryAsync(
        string id, CancellationToken ct = default);

    Task<Result<CustomerResponse>> UpdateCustomerAsync(
        string id, UpdateCustomerRequest request, string? userId, CancellationToken ct = default);

    Task<Result<bool>> DeleteCustomerAsync(
        string id, CancellationToken ct = default);
}
```

## File: Services/Abstraction/ICustomerTransactionService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Customers;
using Centraly.Api.Contracts.Returns;

namespace Centraly.Api.Services.Abstraction;

public interface ICustomerTransactionService
{
    Task<Result<CustomerPaymentResponse>> AddPaymentAsync(string customerId, CreateCustomerPaymentRequest request, string? userId, CancellationToken ct = default);
    Task<Result<ReturnRecordResponse>> AddReturnAsync(string customerId, CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default);
    Task<Result<IEnumerable<CustomerStatementResponse>>> GetCustomerStatementAsync(string customerId, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IDepartmentService.cs
```csharp
namespace Centraly.Api.Services.Abstraction;

public interface IDepartmentService
{
    Task<Result<DepartmentResponse>> AddDepartmentAsync(
        CreateDepartmentRequest request, string? userId, CancellationToken ct = default);

    Task<Result<DepartmentResponse>> GetDepartmentAsync(
        string id, CancellationToken ct = default);

    Task<Result<PaginatedList<DepartmentResponse>>> GetAllDepartmentsAsync(
        RequestFilters filters, CancellationToken ct = default);

    Task<Result<DepartmentResponse>> UpdateDepartmentAsync(
        string id, UpdateDepartmentRequest request, string? userId, CancellationToken ct = default);

    Task<Result<bool>> DeleteDepartmentAsync(
        string id, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IDrawerService.cs
```csharp
namespace Centraly.Api.Services.Abstraction;

public interface IDrawerService
{
    Task<Result<DrawerSessionResponse>> OpenSessionAsync(OpenSessionRequest request, string userId, CancellationToken ct = default);
    Task<Result<DrawerSessionResponse>> CloseSessionAsync(int type, string userId, CancellationToken ct = default);
    Task<Result<DrawerTransactionResponse>> RecordTransactionAsync(DrawerTransactionCategory category, DrawerTransactionType type, decimal amount, decimal profit, string? notes, string? source, string userId, CancellationToken ct = default);
    Task<Result<DrawerTransactionResponse>> AddManualTransactionAsync(AddManualTransactionRequest request, string userId, CancellationToken ct = default);
    Task<Result<DrawerSessionResponse>> GetActiveSessionAsync(int type = 1, CancellationToken ct = default);
    Task<Result<DrawerSessionResponse>> GetSessionByIdAsync(string id, CancellationToken ct = default);

    /// <summary>
    /// Session history. Pass <paramref name="type"/> to see only one shift's history
    /// (e.g. 2 = Maintenance) - omit it to see every shift type mixed together.
    /// </summary>
    Task<Result<PaginatedList<DrawerSessionResponse>>> GetSessionsHistoryAsync(RequestFilters filters, int? type = null, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IExpenseService.cs
```csharp
using Centraly.Api.Contracts.Finance;

namespace Centraly.Api.Services.Abstraction;

public interface IExpenseService
{
    Task<Result<ExpenseCategoryResponse>> CreateExpenseCategoryAsync(CreateExpenseCategoryRequest request, string? userId, CancellationToken ct = default);
    Task<Result<IEnumerable<ExpenseCategoryResponse>>> GetExpenseCategoriesAsync(CancellationToken ct = default);
    Task<Result<ExpenseResponse>> RecordExpenseAsync(CreateExpenseRequest request, string? userId, CancellationToken ct = default);
    Task<Result<PaginatedList<ExpenseResponse>>> GetExpensesAsync(FinanceFilters filters, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IFinancePolicyService.cs
```csharp
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Centraly.Api.Contracts.Finance;
using Centraly.Api.Contracts.Shared.Enums;
using Centraly.Api.Abstractions;

namespace Centraly.Api.Services.Abstraction;

public interface IFinancePolicyService
{
    Task<Result<IEnumerable<TransactionPolicyResponse>>> GetPoliciesAsync(CancellationToken ct = default);
    Task<Result<TransactionPolicyResponse>> UpdatePolicyAsync(string categoryString, UpdateTransactionPolicyRequest request, CancellationToken ct = default);
    Task<Result<PaymentSourcePolicy>> GetPolicyForCategoryAsync(GlobalTransactionCategory category, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IMaintenanceService.cs
```csharp
using Centraly.Api.Contracts.Maintenance;

namespace Centraly.Api.Services.Abstraction;

public interface IMaintenanceService
{
    Task<Result<MaintenanceResponse>> CreateMaintenanceAsync(CreateMaintenanceRequest request, string userId, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> UpdateMaintenanceAsync(string id, UpdateMaintenanceRequest request, string userId, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> DeliverMaintenanceAsync(string id, string userId, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> ReturnMaintenanceAsync(string id, string userId, CancellationToken ct = default);
    Task<Result<PaginatedList<MaintenanceSummary>>> GetAllMaintenanceAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<MaintenanceResponse>> GetByIdAsync(string id, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IOwnerTransactionService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Finance;

namespace Centraly.Api.Services.Abstraction;

public interface IOwnerTransactionService
{
    Task<Result<OwnerTransactionResponse>> CreateOwnerTransactionAsync(CreateOwnerTransactionRequest request, string userId, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<OwnerTransactionResponse>>> GetOwnerTransactionsAsync(CancellationToken cancellationToken = default);
}
```

## File: Services/Abstraction/IProductService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Inventory.Products;

namespace Centraly.Api.Services.Abstraction;

public interface IProductService
{
    Task<Result<ProductResponse>> AddProductAsync(CreateProductRequest request, string? userId, CancellationToken ct = default);
    Task<Result<ProductResponse>> GetProductAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<ProductResponse>>> GetAllProductsAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<List<ProductSupplierResponse>>> GetProductSuppliersAsync(string productId, CancellationToken ct = default);
    Task<Result<ProductResponse>> UpdateProductAsync(string id, UpdateProductRequest request, string? userId, CancellationToken ct = default);
    Task<Result<bool>> DeleteProductAsync(string id, CancellationToken ct = default);
    Task<Result<ProductResponse>> AdjustQuantityAsync(string id, AdjustProductQuantityRequest request, string? userId, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IPurchaseInvoiceService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Suppliers;

namespace Centraly.Api.Services.Abstraction;

public interface IPurchaseInvoiceService
{
    Task<Result<PurchaseInvoiceResponse>> AddPurchaseInvoiceAsync(CreatePurchaseInvoiceRequest request, string? userId, CancellationToken ct = default);
    Task<Result<PurchaseInvoiceResponse>> GetPurchaseInvoiceAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<PurchaseInvoiceResponse>>> GetAllPurchaseInvoicesAsync(RequestFilters filters, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IReturnProcessingService.cs
```csharp
using Centraly.Api.Contracts.Returns;

namespace Centraly.Api.Services.Abstraction;

public interface IReturnProcessingService
{
    Task<Result<ReturnRecordResponse>> ProcessReturnAsync(
        CreateCustomerReturnRequest request, string? userId, string? expectedCustomerId, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IRoleService.cs
```csharp
using Centraly.Api.Contracts.Roles;

namespace Centraly.Api.Services;

public interface IRoleService
{
    Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<RoleDetailResponse>> GetAsync(string id);
    Task<Result<RoleDetailResponse>> AddAsync(RoleRequest request);
    Task<Result> UpdateAsync(string id, RoleRequest request);
    Task<Result> ToggleStatusAsync(string id);
}
```

## File: Services/Abstraction/ISafeService.cs
```csharp
using Centraly.Api.Contracts.Finance;
using Centraly.Api.Contracts.Shared.Enums;

namespace Centraly.Api.Services.Abstraction;

public interface ISafeService
{
    Task<Result<SafeResponse>> CreateSafeAsync(CreateSafeRequest request, string? userId, CancellationToken ct = default);
    Task<Result<IEnumerable<SafeResponse>>> GetSafesAsync(CancellationToken ct = default);
    Task<Result<SafeResponse>> GetMainSafeAsync(CancellationToken ct = default);
    Task<Result<SafeTransactionResponse>> DepositFromDrawerAsync(string safeId, ReceiveDrawerDepositRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SafeTransactionResponse>> AddManualTransactionAsync(string safeId, DrawerTransactionType type, SafeTransactionCategory category, decimal amount, decimal profit, string? notes, string? userId, CancellationToken ct = default);
    Task<Result<PaginatedList<SafeTransactionResponse>>> GetSafeTransactionsAsync(string safeId, FinanceFilters filters, CancellationToken ct = default);
}
```

## File: Services/Abstraction/ISalesInvoiceService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Sales;

namespace Centraly.Api.Services.Abstraction;

public interface ISalesInvoiceService
{
    Task<Result<SalesInvoiceResponse>> AddInvoiceAsync(CreateSalesInvoiceRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SalesInvoiceResponse>> GetInvoiceAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SalesInvoiceResponse>>> GetAllInvoicesAsync(RequestFilters filters, CancellationToken ct = default);
}
```

## File: Services/Abstraction/ISalesReturnService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Returns;
using Centraly.Api.Contracts.Shared;

namespace Centraly.Api.Services.Abstraction;

public interface ISalesReturnService
{
    Task<Result<ReturnRecordResponse>> AddReturnAsync(CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default);
    Task<Result<ReturnRecordResponse>> GetReturnAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<ReturnRecordResponse>>> GetAllReturnsAsync(RequestFilters filters, CancellationToken ct = default);
}
```

## File: Services/Abstraction/ISupplierService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Suppliers;

namespace Centraly.Api.Services.Abstraction;

public interface ISupplierService
{
    Task<Result<SupplierResponse>> AddSupplierAsync(CreateSupplierRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SupplierResponse>> GetSupplierAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SupplierResponse>>> GetAllSuppliersAsync(RequestFilters filters, CancellationToken ct = default);
    Task<Result<SupplierResponse>> UpdateSupplierAsync(string id, UpdateSupplierRequest request, string? userId, CancellationToken ct = default);
    Task<Result<bool>> DeleteSupplierAsync(string id, CancellationToken ct = default);
    Task<Result<List<SupplierStatementItemResponse>>> GetSupplierStatementAsync(string id, RequestFilters filters, CancellationToken ct = default);
    Task<Result<IReadOnlyList<SupplierBatchResponse>>> GetSupplierAvailableBatchesAsync(string supplierId, CancellationToken ct = default);
}
```

## File: Services/Abstraction/ISupplierTransactionService.cs
```csharp
using Centraly.Api.Abstractions;
using Centraly.Api.Contracts.Common;
using Centraly.Api.Contracts.Suppliers;

namespace Centraly.Api.Services.Abstraction;

public interface ISupplierTransactionService
{
    // Payments
    Task<Result<SupplierPaymentResponse>> AddPaymentAsync(CreateSupplierPaymentRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SupplierPaymentResponse>> GetPaymentAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SupplierPaymentResponse>>> GetAllPaymentsAsync(RequestFilters filters, CancellationToken ct = default);

    // Returns
    Task<Result<SupplierReturnResponse>> AddReturnAsync(CreateSupplierReturnRequest request, string? userId, CancellationToken ct = default);
    Task<Result<SupplierReturnResponse>> GetReturnAsync(string id, CancellationToken ct = default);
    Task<Result<PaginatedList<SupplierReturnResponse>>> GetAllReturnsAsync(RequestFilters filters, CancellationToken ct = default);
}
```

## File: Services/Abstraction/ITransactionRouterService.cs
```csharp
using System.Threading;
using System.Threading.Tasks;
using Centraly.Api.Contracts.Shared.Enums;
using Centraly.Api.Abstractions;

namespace Centraly.Api.Services.Abstraction;

public interface ITransactionRouterService
{
    Task<Result<(string Id, PaymentSource Source)>> RouteTransactionAsync(GlobalTransactionCategory category, decimal amount, decimal profit, PaymentSource? requestedSource, string? notes, string? referenceId, string userId, CancellationToken ct = default);
}
```

## File: Services/Abstraction/IUserService.cs
```csharp
using Centraly.Api.Contracts.Users;

namespace Centraly.Api.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<UserResponse>> GetAsync(string id);
    Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default);
}
```

## File: Services/Abstraction/IWalletService.cs
```csharp
using Centraly.Api.Contracts.Wallets;

namespace Centraly.Api.Services.Abstraction;

public interface IWalletService
{
    Task<Result<WalletResponse>> CreateWalletAsync(CreateWalletRequest request, string userId, CancellationToken ct = default);
    Task<Result<WalletResponse>> UpdateWalletAsync(string walletId, UpdateWalletRequest request, string userId, CancellationToken ct = default);
    Task<Result<WalletOperationResponse>> ProcessOperationAsync(ProcessOperationRequest request, string userId, CancellationToken ct = default);
    Task<Result<PaginatedList<WalletResponse>>> GetAllWalletsAsync(PaginationFilter filter, CancellationToken ct = default);
    Task<Result<WalletDetailsResponse>> GetWalletByIdAsync(string walletId, CancellationToken ct = default);
    Task<Result<PaginatedList<WalletOperationResponse>>> GetWalletOperationsAsync(WalletOperationFilter filter, CancellationToken ct = default);
    Task<Result<WalletOperationsSummaryResponse>> GetWalletOperationsSummaryAsync(WalletOperationFilter filter, CancellationToken ct = default);
}
```

## File: Services/Abstractions/IExpenseService.cs
```csharp

```

## File: Services/Implementation/AuthService.cs
```csharp
using System.Security.Cryptography;

namespace Centraly.Api.Services;

public class AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider,
    SignInManager<ApplicationUser> signInManager, ILogger<AuthService> logger, ApplicationDbContext context) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly ILogger<AuthService> _logger = logger;
    private readonly ApplicationDbContext _context = context;
    private readonly int _refreshTokenExpiryDays = 14;
    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {

        try
        {
            ApplicationUser? user = null;


            // If not found by email or doesn't contain @, try username
            if (user is null)
            {
                user = await _context.Users
                   .Include(u => u.RefreshTokens)
                   .FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);
            }
            if (user is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);


            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);

            if (result.Succeeded)
            {
                var (userRoles, userPermissions) =
                    await GetUserRolesAndPermissions(user, cancellationToken);

                var (token, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, userPermissions);
                var refreshToken = GenerateRefreshToken();
                var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

                user.RefreshTokens.Add(new RefreshToken
                {
                    Token = refreshToken,
                    ExpiresOn = refreshTokenExpiration
                });

                await _userManager.UpdateAsync(user);

                var response = new LoginResponse(
                    user.Id, user.UserName ?? string.Empty,
                    token, expiresIn, refreshToken, refreshTokenExpiration, userRoles, userPermissions);

                return Result.Success(response);
            }

            var error = result.IsNotAllowed ? UserErrors.EmailNotConfirmed
                      : result.IsLockedOut ? UserErrors.LockedUser
                                             : UserErrors.InvalidCredentials;

            return Result.Failure<LoginResponse>(error);
        }
        catch (Exception ex)
        {
            // _logger.LogError(ex, "Error occurred while generating token for user {username}", user.UserName);
            return Result.Failure<LoginResponse>(UserErrors.UnexpectedError);
        }
    }

    private async Task<(IEnumerable<string> roles, IEnumerable<string> permissions)>
        GetUserRolesAndPermissions(ApplicationUser user, CancellationToken cancellationToken)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        var userPermissions = await (
            from r in _context.Roles
            join p in _context.RoleClaims on r.Id equals p.RoleId
            where userRoles.Contains(r.Name!)
            select p.ClaimValue!)
            .Distinct()
            .ToListAsync(cancellationToken);

        return (userRoles, userPermissions);
    }
    private static string GenerateRefreshToken()
    => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    public async Task<Result<LoginResponse>> GetRefreshTokenAsync(
       string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        try
        {
            var userId = _jwtProvider.ValidateToken(token, validateLifetime: false);

            if (userId is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidJwtToken);

            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidJwtToken);

            var userRefreshToken = user.RefreshTokens
                .SingleOrDefault(x => x.Token == refreshToken && x.IsActive);

            if (userRefreshToken is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidRefreshToken);

            userRefreshToken.RevokedOn = DateTime.UtcNow;

            var (userRoles, userPermissions) =
                await GetUserRolesAndPermissions(user, cancellationToken);

            var (newToken, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, userPermissions);
            var newRefreshToken = GenerateRefreshToken();
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = newRefreshToken,
                ExpiresOn = refreshTokenExpiration
            });

            await _userManager.UpdateAsync(user);

            var response = new LoginResponse(
                user.Id, user.UserName ?? string.Empty,
                newToken, expiresIn, newRefreshToken, refreshTokenExpiration, userRoles, userPermissions);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while refreshing token");
            return Result.Failure<LoginResponse>(UserErrors.UnexpectedError);
        }
    }

    public async Task<Result> RevokeRefreshTokenAsync(
        string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        try
        {
            var userId = _jwtProvider.ValidateToken(token, validateLifetime: false);

            if (userId is null)
                return Result.Failure(UserErrors.InvalidJwtToken);

            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user is null)
                return Result.Failure(UserErrors.InvalidJwtToken);

            var userRefreshToken = user.RefreshTokens
                .SingleOrDefault(x => x.Token == refreshToken && x.IsActive);

            if (userRefreshToken is null)
                return Result.Failure(UserErrors.InvalidRefreshToken);

            userRefreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while revoking refresh token");
            return Result.Failure(UserErrors.UnexpectedError);
        }
    }

}
```

## File: Services/Implementation/CategoryService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class CategoryService(ApplicationDbContext dbContext, ILogger<CategoryService> logger) : ICategoryService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CategoryService> _logger = logger;

    private static readonly string[] AllowedCategorySortColumns = ["Name", "CreatedAt"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Category
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<CategoryResponse>> AddCategoryAsync(
        CreateCategoryRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var department = await _dbContext.Departments
                .Where(d => d.Id == request.DepartmentId && !d.IsDeleted)
                .Select(d => new DepartmentSummary(d.Id, d.Name))
                .FirstOrDefaultAsync(ct);

            if (department is null)
                return Result.Failure<CategoryResponse>(CategoryErrors.DepartmentNotFound);

            var category = new Category
            {
                Name = request.Name,
                DepartmentId = request.DepartmentId,
                CreatedByUserId = userId
            };

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync(ct);

            var response = new CategoryResponse(
                category.Id,
                category.Name,
                department,
                0,
                category.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating category for user {UserId}", userId);
            return Result.Failure<CategoryResponse>(CategoryErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Category By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<CategoryResponse>> GetCategoryAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Categories
            .Where(c => c.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<CategoryResponse>(CategoryErrors.CategoryNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Categories
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<CategoryResponse>>> GetAllCategoriesAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Categories
                .Where(c => !c.IsDeleted)
                .Where(c => filters.DepartmentId == null || c.DepartmentId == filters.DepartmentId)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Name.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedCategorySortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for categories");
            return Result.Failure<PaginatedList<CategoryResponse>>(CategoryErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Update Category
    // ─────────────────────────────────────────────────────────────────
    // Instead of Fetch(+Include Department) -> Track -> SaveChanges -> re-query counts,
    // this validates the new department only when it actually changes, then issues a
    // single ExecuteUpdateAsync (no tracking, no full entity load), then re-projects.

    public async Task<Result<CategoryResponse>> UpdateCategoryAsync(
        string id, UpdateCategoryRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var currentDepartmentId = await _dbContext.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .Select(c => (string?)c.DepartmentId)
                .FirstOrDefaultAsync(ct);

            if (currentDepartmentId is null)
                return Result.Failure<CategoryResponse>(CategoryErrors.CategoryNotFound);

            if (currentDepartmentId != request.DepartmentId)
            {
                var departmentExists = await _dbContext.Departments
                    .AnyAsync(d => d.Id == request.DepartmentId && !d.IsDeleted, ct);

                if (!departmentExists)
                    return Result.Failure<CategoryResponse>(CategoryErrors.DepartmentNotFound);
            }

            await _dbContext.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.Name, request.Name)
                    .SetProperty(c => c.DepartmentId, request.DepartmentId)
                    .SetProperty(c => c.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(c => c.UpdatedByUserId, userId), ct);

            var response = await _dbContext.Categories
                .Where(c => c.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating category {CategoryId}", id);
            return Result.Failure<CategoryResponse>(CategoryErrors.UpdateFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Soft Delete Category
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<bool>> DeleteCategoryAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Categories
                .Where(c => c.Id == id && !c.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.IsDeleted, true)
                    .SetProperty(c => c.DeletedAt, DateTime.UtcNow), ct);

            if (deleted == 0)
                return Result.Failure<bool>(CategoryErrors.CategoryNotFound);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting category {CategoryId}", id);
            return Result.Failure<bool>(CategoryErrors.DeleteFailed);
        }
    }

}
```

## File: Services/Implementation/CustomerService.cs
```csharp
using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class CustomerService(ApplicationDbContext dbContext, ILogger<CustomerService> logger) : ICustomerService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CustomerService> _logger = logger;

    private static readonly string[] AllowedCustomerSortColumns = ["Name", "CreatedAt", "DebtBalance"];

    // ════════════════════════════════════════════════════════════════
    //  Add Customer
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerResponse>> AddCustomerAsync(
        CreateCustomerRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var customer = new Customer
            {
                Name = request.Name,
                Phone = request.Phone,
                CreatedByUserId = userId
            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync(ct);

            var response = new CustomerResponse(
                customer.Id, customer.Name, customer.Phone, customer.DebtBalance, 0, customer.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating customer for user {UserId}", userId);
            return Result.Failure<CustomerResponse>(CustomerErrors.CreationFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Get Customer By Id
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerResponse>> GetCustomerAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Customers
            .Where(c => c.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<CustomerResponse>(CustomerErrors.CustomerNotFound)
            : Result.Success(response);
    }

    // ════════════════════════════════════════════════════════════════
    //  Get All Customers
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<PaginatedList<CustomerResponse>>> GetAllCustomersAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Customers
                .Where(c => !c.IsDeleted)
                .ApplyFilters(filters,
                    searchPredicate: x =>
                        (x.Name != null && x.Name.Contains(filters.SearchValue!)) ||
                        (x.Phone != null && x.Phone.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedCustomerSortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for customers");
            return Result.Failure<PaginatedList<CustomerResponse>>(CustomerErrors.InvalidSortColumn);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Get Customer With Debt History (كشف حساب)
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerDebtHistoryResponse>> GetCustomerWithDebtHistoryAsync(
        string id, CancellationToken ct = default)
    {
        var customer = await _dbContext.Customers
            .Where(c => c.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        if (customer is null)
            return Result.Failure<CustomerDebtHistoryResponse>(CustomerErrors.CustomerNotFound);

        var deferredInvoices = await _dbContext.Invoices
            .Where(i => i.CustomerId == id && i.PaymentMethod == PaymentMethod.Deferred)
            .ProjectToSummary()
            .OrderByDescending(i => i.CreatedAt)
            .ToListAsync(ct);

        var payments = await _dbContext.CustomerDebtPayments
            .Where(p => p.CustomerId == id)
            .ProjectToResponse()
            .OrderByDescending(p => p.PaymentDate)
            .ToListAsync(ct);

        var response = new CustomerDebtHistoryResponse(customer, deferredInvoices, payments);
        return Result.Success(response);
    }

    // ════════════════════════════════════════════════════════════════
    //  Update Customer
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<CustomerResponse>> UpdateCustomerAsync(
        string id, UpdateCustomerRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var updated = await _dbContext.Customers
                .Where(c => c.Id == id && !c.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.Name, request.Name)
                    .SetProperty(c => c.Phone, request.Phone)
                    .SetProperty(c => c.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(c => c.UpdatedByUserId, userId), ct);

            if (updated == 0)
                return Result.Failure<CustomerResponse>(CustomerErrors.CustomerNotFound);

            var response = await _dbContext.Customers
                .Where(c => c.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating customer {CustomerId}", id);
            return Result.Failure<CustomerResponse>(CustomerErrors.UpdateFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Soft Delete Customer
    // ════════════════════════════════════════════════════════════════
    // The debt-balance guard is folded into the ExecuteUpdateAsync predicate
    // itself, so the common (successful) path never fetches the entity.
    // A second lightweight query only runs to tell the two failure reasons
    // (not found vs. has debt) apart when the update affects 0 rows.

    public async Task<Result<bool>> DeleteCustomerAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Customers
                .Where(c => c.Id == id && !c.IsDeleted && c.DebtBalance == 0)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.IsDeleted, true)
                    .SetProperty(c => c.DeletedAt, DateTime.UtcNow), ct);

            if (deleted > 0)
                return Result.Success(true);

            var exists = await _dbContext.Customers.AnyAsync(c => c.Id == id && !c.IsDeleted, ct);
            return Result.Failure<bool>(exists ? CustomerErrors.HasOutstandingDebt : CustomerErrors.CustomerNotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting customer {CustomerId}", id);
            return Result.Failure<bool>(CustomerErrors.DeleteFailed);
        }
    }
}
```

## File: Services/Implementation/CustomerTransactionService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class CustomerTransactionService(
    ApplicationDbContext dbContext,
    ILogger<CustomerTransactionService> logger,
    ITransactionRouterService transactionRouter,
    IReturnProcessingService returnProcessor) : ICustomerTransactionService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<CustomerTransactionService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly IReturnProcessingService _returnProcessor = returnProcessor;

    // ─────────────────────────────────────────────────────────────────
    //  Add Payment (or refund)
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<CustomerPaymentResponse>> AddPaymentAsync(
        string customerId, CreateCustomerPaymentRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == customerId && !c.IsDeleted, ct);

            if (customer is null)
                return Result.Failure<CustomerPaymentResponse>(CustomerErrors.CustomerNotFound);

            var payment = new CustomerDebtPayment
            {
                CustomerId = customer.Id,
                Amount = request.Amount,
                Notes = request.Notes,
                CreatedByUserId = userId
            };

            var category = request.Amount < 0 ? GlobalTransactionCategory.CustomerRefund : GlobalTransactionCategory.CustomerPayment;
            decimal profitToRecord = 0;
            if (!string.IsNullOrEmpty(request.InvoiceId))
            {
                var invoice = await _dbContext.Invoices.Include(i => i.Items)
                    .FirstOrDefaultAsync(i => i.Id == request.InvoiceId && i.CustomerId == customerId, ct);
                if (invoice is not null)
                {
                    var totalPotentialProfit = invoice.Items.Sum(i => (i.UnitPrice - i.UnitCost) * i.Quantity);
                    var remainingProfit = totalPotentialProfit - invoice.RecordedProfit;
                    var remainingDebt = invoice.TotalAmount - invoice.PaidAmount;
                    var portion = remainingDebt <= 0 ? 0 : Math.Min(1m, request.Amount / remainingDebt);
                    profitToRecord = Math.Round(remainingProfit * portion, 2);
                    
                    invoice.RecordedProfit += profitToRecord;
                    invoice.PaidAmount += request.Amount;
                }
            }

            var routerResult = await _transactionRouter.RouteTransactionAsync(category, Math.Abs(request.Amount), profitToRecord, request.PaymentSource, request.Notes, payment.Id, userId, ct);

            if (routerResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<CustomerPaymentResponse>(routerResult.Error);
            }

            customer.DebtBalance -= request.Amount; // if Amount is negative, it adds to DebtBalance (Customer Refund increases their debt to us or returns their credit). Wait, if customer pays us, they reduce their debt. DebtBalance -= Amount. If it's a refund (we pay them back), DebtBalance += Math.Abs(Amount) which is DebtBalance -= (-Math.Abs) -> DebtBalance -= request.Amount. Correct!
            customer.UpdatedAt = DateTime.UtcNow;
            customer.UpdatedByUserId = userId;

            _dbContext.CustomerDebtPayments.Add(payment);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return Result.Success(new CustomerPaymentResponse(
                payment.Id, payment.CustomerId, payment.Amount, payment.PaymentDate, payment.Notes));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error occurred while processing payment for customer {CustomerId}", customerId);
            return Result.Failure<CustomerPaymentResponse>(CustomerTransactionErrors.PaymentFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Add Return
    // ─────────────────────────────────────────────────────────────────
    // The actual workflow (validate invoice/items, restock batches, record
    // the return, route refund or adjust debt) lives in ReturnProcessingService
    // so it isn't duplicated between here and SalesReturnService. Passing
    // customerId scopes the check to "this invoice must belong to this customer".

    public Task<Result<ReturnRecordResponse>> AddReturnAsync(
        string customerId, CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default) =>
        _returnProcessor.ProcessReturnAsync(request, userId, expectedCustomerId: customerId, ct);

    // ─────────────────────────────────────────────────────────────────
    //  Customer Statement
    // ─────────────────────────────────────────────────────────────────
    // Only ever checked for existence, so this uses AnyAsync instead of
    // loading the full Customer entity.

    public async Task<Result<IEnumerable<CustomerStatementResponse>>> GetCustomerStatementAsync(
        string customerId, CancellationToken ct = default)
    {
        var customerExists = await _dbContext.Customers.AnyAsync(c => c.Id == customerId && !c.IsDeleted, ct);
        if (!customerExists)
            return Result.Failure<IEnumerable<CustomerStatementResponse>>(CustomerErrors.CustomerNotFound);

        var rawInvoices = await _dbContext.Invoices
            .Where(i => i.CustomerId == customerId && !i.IsDeleted)
            .Select(i => new { i.CreatedAt, i.Id, i.TotalAmount, i.PaidAmount, i.Notes })
            .AsNoTracking()
            .ToListAsync(ct);

        var invoices = rawInvoices
            .Select(i => new { Date = i.CreatedAt, Type = "Invoice", i.Id, Debit = i.TotalAmount, Credit = 0m, i.Notes })
            .ToList();

        var invoicePayments = rawInvoices
            .Where(i => i.PaidAmount > 0)
            .Select(i => new { Date = i.CreatedAt, Type = "InvoicePayment", i.Id, Debit = 0m, Credit = i.PaidAmount, Notes = "سداد نقدي للفاتورة" })
            .ToList();

        var payments = await _dbContext.CustomerDebtPayments
            .Where(p => p.CustomerId == customerId && !p.IsDeleted)
            .Select(p => new
            {
                Date = p.PaymentDate,
                Type = p.Amount >= 0 ? "Payment" : "Refund",
                p.Id,
                Debit = p.Amount < 0 ? Math.Abs(p.Amount) : 0m,
                Credit = p.Amount >= 0 ? p.Amount : 0m,
                Notes = (string?)p.Notes
            })
            .AsNoTracking()
            .ToListAsync(ct);

        var returns = await _dbContext.Returns
            .Where(r => r.Invoice!.CustomerId == customerId && !r.IsDeleted)
            .Select(r => new { Date = r.ReturnDate, Type = "Return", r.Id, Debit = 0m, Credit = r.TotalReturnedAmount, Notes = (string?)r.Notes })
            .AsNoTracking()
            .ToListAsync(ct);

        var allTransactions = invoices.Concat(invoicePayments).Concat(payments).Concat(returns).OrderBy(t => t.Date);

        var runningBalance = 0m;
        var result = new List<CustomerStatementResponse>();

        foreach (var t in allTransactions)
        {
            runningBalance += t.Debit - t.Credit;
            result.Add(new CustomerStatementResponse(t.Date, t.Type, t.Id, t.Debit, t.Credit, runningBalance, t.Notes));
        }

        return Result.Success<IEnumerable<CustomerStatementResponse>>(result);
    }
}
```

## File: Services/Implementation/DepartmentService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class DepartmentService(ApplicationDbContext dbContext, ILogger<DepartmentService> logger) : IDepartmentService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<DepartmentService> _logger = logger;

    private static readonly string[] AllowedDepartmentSortColumns = ["Name", "CreatedAt"];

    // ════════════════════════════════════════════════════════════════
    //  Add Department
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<DepartmentResponse>> AddDepartmentAsync(
        CreateDepartmentRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var department = new Department
            {
                Name = request.Name,
                CreatedByUserId = userId
            };

            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync(ct);

            var response = new DepartmentResponse(
                department.Id, department.Name, 0, 0, department.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating department for user {UserId}", userId);
            return Result.Failure<DepartmentResponse>(DepartmentErrors.CreationFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Get Department By Id
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<DepartmentResponse>> GetDepartmentAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Departments
            .Where(d => d.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<DepartmentResponse>(DepartmentErrors.DepartmentNotFound)
            : Result.Success(response);
    }

    // ════════════════════════════════════════════════════════════════
    //  Get All Departments
    // ════════════════════════════════════════════════════════════════

    public async Task<Result<PaginatedList<DepartmentResponse>>> GetAllDepartmentsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Departments
                .Where(d => !d.IsDeleted)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Name.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedDepartmentSortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for departments");
            return Result.Failure<PaginatedList<DepartmentResponse>>(DepartmentErrors.InvalidSortColumn);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Update Department
    // ════════════════════════════════════════════════════════════════
    // Uses ExecuteUpdateAsync: issues a single UPDATE statement directly
    // against the database with no entity fetch and no change tracking,
    // instead of Fetch -> Track -> SaveChanges -> re-query counts (3 round-trips).

    public async Task<Result<DepartmentResponse>> UpdateDepartmentAsync(
        string id, UpdateDepartmentRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var updated = await _dbContext.Departments
                .Where(d => d.Id == id && !d.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(d => d.Name, request.Name)
                    .SetProperty(d => d.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(d => d.UpdatedByUserId, userId), ct);

            if (updated == 0)
                return Result.Failure<DepartmentResponse>(DepartmentErrors.DepartmentNotFound);

            var response = await _dbContext.Departments
                .Where(d => d.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating department {DepartmentId}", id);
            return Result.Failure<DepartmentResponse>(DepartmentErrors.UpdateFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Soft Delete Department
    // ════════════════════════════════════════════════════════════════
    // Same idea: soft delete happens in a single UPDATE, with no fetch beforehand.

    public async Task<Result<bool>> DeleteDepartmentAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Departments
                .Where(d => d.Id == id && !d.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(d => d.IsDeleted, true)
                    .SetProperty(d => d.DeletedAt, DateTime.UtcNow), ct);

            if (deleted == 0)
                return Result.Failure<bool>(DepartmentErrors.DepartmentNotFound);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting department {DepartmentId}", id);
            return Result.Failure<bool>(DepartmentErrors.DeleteFailed);
        }
    }

    // ════════════════════════════════════════════════════════════════
    //  Shared projection (selection loading - no Include anywhere)
    // ════════════════════════════════════════════════════════════════

}
```

## File: Services/Implementation/DrawerService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class DrawerService(ApplicationDbContext dbContext) : IDrawerService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    private static readonly string[] AllowedSessionSortColumns = ["OpenedAt", "ClosingBalance"];

    // ─────────────────────────────────────────────────────────────────
    //  Open Session
    // ─────────────────────────────────────────────────────────────────
    // "Already open" is scoped per DrawerType, so a Sales shift being open
    // does not block opening an independent Maintenance shift, and vice versa.

    public async Task<Result<DrawerSessionResponse>> OpenSessionAsync(OpenSessionRequest request, string userId, CancellationToken ct = default)
    {
        var hasActiveSession = await _dbContext.DrawerSessions.AnyAsync(s => !s.IsClosed && (int)s.Type == request.Type, ct);
        if (hasActiveSession)
            return Result.Failure<DrawerSessionResponse>(DrawerErrors.AlreadyOpen);

        var session = new DrawerSession
        {
            Type = (DrawerType)request.Type,
            OpeningBalance = request.OpeningBalance,
            OpenedAt = DateTime.UtcNow,
            OpenedByUserId = userId,
            IsClosed = false,
            CreatedByUserId = userId
        };

        _dbContext.DrawerSessions.Add(session);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new DrawerSessionResponse(
            session.Id, (int)session.Type, session.OpeningBalance, session.OpenedAt, session.OpenedByUserId,
            session.IsClosed, session.ClosedAt, session.TotalIncome, session.TotalExpense, session.ClosingBalance, 0, []));
    }

    // ─────────────────────────────────────────────────────────────────
    //  Close Session
    // ─────────────────────────────────────────────────────────────────
    // Sums are computed in SQL (SumAsync) instead of loading every
    // transaction into memory, then the session row is closed with a
    // single ExecuteUpdateAsync (no tracking, no full entity load).

    public async Task<Result<DrawerSessionResponse>> CloseSessionAsync(int type, string userId, CancellationToken ct = default)
    {
        var session = await _dbContext.DrawerSessions
            .Where(s => !s.IsClosed && (int)s.Type == type)
            .Select(s => new { s.Id, s.OpeningBalance })
            .FirstOrDefaultAsync(ct);

        if (session is null)
            return Result.Failure<DrawerSessionResponse>(DrawerErrors.NoActiveSession);

        var totalIncome = await _dbContext.DrawerTransactions
            .Where(t => t.DrawerSessionId == session.Id && t.Type == DrawerTransactionType.Income)
            .SumAsync(t => t.Amount, ct);

        var totalExpense = await _dbContext.DrawerTransactions
            .Where(t => t.DrawerSessionId == session.Id && t.Type == DrawerTransactionType.Expense)
            .SumAsync(t => t.Amount, ct);

        var closingBalance = session.OpeningBalance + totalIncome - totalExpense;

        var totalProfit = await _dbContext.DrawerTransactions
            .Where(t => t.DrawerSessionId == session.Id)
            .SumAsync(t => t.Profit, ct);

        await _dbContext.DrawerSessions
            .Where(s => s.Id == session.Id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.TotalIncome, totalIncome)
                .SetProperty(s => s.TotalExpense, totalExpense)
                .SetProperty(s => s.ClosingBalance, closingBalance)
                .SetProperty(s => s.TotalProfit, totalProfit)
                .SetProperty(s => s.IsClosed, true)
                .SetProperty(s => s.ClosedAt, DateTime.UtcNow)
                .SetProperty(s => s.UpdatedAt, DateTime.UtcNow)
                .SetProperty(s => s.UpdatedByUserId, userId), ct);

        return await GetSessionByIdAsync(session.Id, ct);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Record Transaction
    // ─────────────────────────────────────────────────────────────────
    // The target shift (Sales vs Maintenance) is resolved automatically from
    // the transaction category, so callers never need to know about DrawerType.
    // The running balance is derived from the *last* transaction's Balance
    // (a single row) instead of re-summing every transaction the session has
    // ever had - this used to get slower as the shift went on.

    public async Task<Result<DrawerTransactionResponse>> RecordTransactionAsync(
        DrawerTransactionCategory category, DrawerTransactionType type, decimal amount, decimal profit,
        string? notes, string? source, string userId, CancellationToken ct = default)
    {
        var targetType = ResolveType(category);

        var ownsTransaction = _dbContext.Database.CurrentTransaction == null;
        var dbTransaction = ownsTransaction ? await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, ct) : null;
        try
        {
        var session = await _dbContext.DrawerSessions
            .Where(s => !s.IsClosed && s.Type == targetType)
            .FirstOrDefaultAsync(ct);

        if (session is null)
            return Result.Failure<DrawerTransactionResponse>(DrawerErrors.NoActiveSession);

        if (amount < 0 || (amount == 0 && profit == 0))
            return Result.Failure<DrawerTransactionResponse>(DrawerErrors.InvalidAmount);

        if (type == DrawerTransactionType.Expense && session.RunningBalance < amount)
            return Result.Failure<DrawerTransactionResponse>(DrawerErrors.InsufficientFunds);

        var newBalance = type == DrawerTransactionType.Income ? session.RunningBalance + amount : session.RunningBalance - amount;
        session.RunningBalance = newBalance;

        var transaction = new DrawerTransaction
        {
            DrawerSessionId = session.Id,
            Type = type,
            Category = category,
            Amount = amount,
            Profit = profit,
            Balance = newBalance,
            Source = source,
            Notes = notes,
            UserId = userId,
            CreatedByUserId = userId
        };

        _dbContext.DrawerTransactions.Add(transaction);
        await _dbContext.SaveChangesAsync(ct);
        if (ownsTransaction) await dbTransaction.CommitAsync(ct);

        return Result.Success(new DrawerTransactionResponse(
            transaction.Id, transaction.Type, transaction.Category, transaction.Amount, transaction.Balance,
            transaction.Source, transaction.Notes, transaction.CreatedAt, transaction.UserId));
        }
        catch
        {
            if (ownsTransaction) await dbTransaction.RollbackAsync(ct);
            throw;
        }
        finally
        {
            if (ownsTransaction) await dbTransaction.DisposeAsync();
        }
    }

    public Task<Result<DrawerTransactionResponse>> AddManualTransactionAsync(
        AddManualTransactionRequest request, string userId, CancellationToken ct = default)
    {
        decimal profit = request.Type == DrawerTransactionType.Expense ? -request.Amount : 0m;
        return RecordTransactionAsync(request.Category, request.Type, request.Amount, profit, request.Notes, request.Source, userId, ct);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Active Session / By Id (full detail, including transactions)
    // ─────────────────────────────────────────────────────────────────
    // NOTE - bug fix: these used to filter (.Where) AFTER SelectSessionResponse,
    // i.e. on the already-projected DrawerSessionResponse DTO - which itself
    // contains a nested subquery (Transactions...ToList()). EF Core cannot
    // translate a filter applied on top of a projection that already embeds a
    // materialized subquery, and threw "could not be translated". The fix is to
    // filter the raw DrawerSession entities first (where IsClosed/Type/Id map
    // directly to columns) and only then project to the response shape.

    public async Task<Result<DrawerSessionResponse>> GetActiveSessionAsync(int type = 1, CancellationToken ct = default)
    {
        var query = _dbContext.DrawerSessions
            .Where(s => !s.IsClosed && (int)s.Type == type);

        var response = await SelectSessionResponse(query).FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<DrawerSessionResponse>(DrawerErrors.NoActiveSession)
            : Result.Success(response);
    }

    public async Task<Result<DrawerSessionResponse>> GetSessionByIdAsync(string id, CancellationToken ct = default)
    {
        var query = _dbContext.DrawerSessions
            .Where(s => s.Id == id);

        var response = await SelectSessionResponse(query).FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<DrawerSessionResponse>(DrawerErrors.SessionNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Sessions History (list view - summary only; optionally scoped to one shift type)
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<DrawerSessionResponse>>> GetSessionsHistoryAsync(
        RequestFilters filters, int? type = null, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.DrawerSessions
                .Where(s => type == null || (int)s.Type == type)
                .Where(s => filters.StartDate == null || s.OpenedAt >= filters.StartDate)
                .Where(s => filters.EndDate == null || s.OpenedAt <= filters.EndDate)
                .ApplyFilters(filters, allowedSortColumns: AllowedSessionSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(s => s.OpenedAt);

            var mappedQuery = query
                .Select(s => new DrawerSessionResponse(
                    s.Id, (int)s.Type, s.OpeningBalance, s.OpenedAt, s.OpenedByUserId, s.IsClosed, s.ClosedAt,
                    s.TotalIncome, s.TotalExpense, s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), new List<DrawerTransactionResponse>()))
                .AsNoTracking();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException)
        {
            return Result.Failure<PaginatedList<DrawerSessionResponse>>(DrawerErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Helpers
    // ─────────────────────────────────────────────────────────────────

    private static DrawerType ResolveType(DrawerTransactionCategory category) =>
        category == DrawerTransactionCategory.Maintenance ? DrawerType.Maintenance : DrawerType.Sales;

    private static IQueryable<DrawerSessionResponse> SelectSessionResponse(IQueryable<DrawerSession> query) =>
        query
            .Select(s => new DrawerSessionResponse(
                s.Id,
                (int)s.Type,
                s.OpeningBalance,
                s.OpenedAt,
                s.OpenedByUserId,
                s.IsClosed,
                s.ClosedAt,
                s.TotalIncome,
                s.TotalExpense,
                s.ClosingBalance, s.TotalProfit ?? s.Transactions.Sum(t => (decimal?)t.Profit), s.Transactions
                    .OrderByDescending(t => t.CreatedAt)
                    .Select(t => new DrawerTransactionResponse(
                        t.Id, t.Type, t.Category, t.Amount, t.Balance, t.Source, t.Notes, t.CreatedAt, t.UserId))
                    .ToList()))
            .AsNoTracking();
}
```

## File: Services/Implementation/ExpenseService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class ExpenseService : IExpenseService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ITransactionRouterService _transactionRouter;

    public ExpenseService(ApplicationDbContext dbContext, ITransactionRouterService transactionRouter)
    {
        _dbContext = dbContext;
        _transactionRouter = transactionRouter;
    }

    public async Task<Result<ExpenseCategoryResponse>> CreateExpenseCategoryAsync(CreateExpenseCategoryRequest request, string? userId, CancellationToken ct = default)
    {
        var cat = new ExpenseCategory
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            CreatedByUserId = userId
        };

        await _dbContext.ExpenseCategories.AddAsync(cat, ct);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new ExpenseCategoryResponse(cat.Id, cat.Name));
    }

    public async Task<Result<IEnumerable<ExpenseCategoryResponse>>> GetExpenseCategoriesAsync(CancellationToken ct = default)
    {
        var categories = await _dbContext.ExpenseCategories.Where(c => !c.IsDeleted).Select(c => new ExpenseCategoryResponse(c.Id, c.Name)).ToListAsync(ct);
        return Result.Success<IEnumerable<ExpenseCategoryResponse>>(categories);
    }

    public async Task<Result<ExpenseResponse>> RecordExpenseAsync(CreateExpenseRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var category = await _dbContext.ExpenseCategories.FirstOrDefaultAsync(c => c.Id == request.CategoryId && !c.IsDeleted, ct);
            if (category is null) return Result.Failure<ExpenseResponse>(new Error("Expense.CategoryNotFound", "Expense category not found", 404));

            string? sourceTxId = null;

            var routeResult = await _transactionRouter.RouteTransactionAsync(GlobalTransactionCategory.Expense, request.Amount, 0, request.PaymentSource, request.Notes, null, userId ?? "", ct);
            if (routeResult.IsFailure) return Result.Failure<ExpenseResponse>(routeResult.Error);

            var expense = new Expense
            {
                Id = Guid.NewGuid().ToString(),
                CategoryId = category.Id,
                Amount = request.Amount,
                PaymentSource = request.PaymentSource ?? PaymentSource.Drawer, // Temp fallback if not nullable
                SourceTransactionId = sourceTxId,
                ExpenseDate = DateTime.UtcNow,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            await _dbContext.Expenses.AddAsync(expense, ct);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
            return Result.Success(new ExpenseResponse(expense.Id, category.Id, category.Name, expense.Amount, expense.PaymentSource.ToString(), expense.ExpenseDate, expense.Notes));
        }
        catch
        {
            await transaction.RollbackAsync(ct);
            throw;
        }
    }

    public async Task<Result<PaginatedList<ExpenseResponse>>> GetExpensesAsync(FinanceFilters filters, CancellationToken ct = default)
    {
        var query = _dbContext.Expenses.Where(e => !e.IsDeleted);

        if (filters.StartDate.HasValue)
            query = query.Where(e => e.ExpenseDate >= filters.StartDate.Value);
        if (filters.EndDate.HasValue)
            query = query.Where(e => e.ExpenseDate <= filters.EndDate.Value);

        var totalCount = await query.CountAsync(ct);
        var items = await query
            .OrderByDescending(e => e.ExpenseDate)
            .Select(e => new ExpenseResponse(e.Id, e.CategoryId, e.Category!.Name, e.Amount, e.PaymentSource.ToString(), e.ExpenseDate, e.Notes))
            .Skip((filters.PageNumber - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<ExpenseResponse>(items, filters.PageNumber, filters.PageSize, totalCount));
    }
}
```

## File: Services/Implementation/FinancePolicyService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class FinancePolicyService(ApplicationDbContext dbContext) : IFinancePolicyService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Result<IEnumerable<TransactionPolicyResponse>>> GetPoliciesAsync(CancellationToken ct = default)
    {
        var policies = await _dbContext.TransactionSourcePolicies
            .AsNoTracking()
            .Select(p => new TransactionPolicyResponse(p.Id, p.Category.ToString(), p.AllowedSource.ToString()))
            .ToListAsync(ct);

        return Result.Success<IEnumerable<TransactionPolicyResponse>>(policies);
    }

    public async Task<Result<TransactionPolicyResponse>> UpdatePolicyAsync(
        string categoryString, UpdateTransactionPolicyRequest request, CancellationToken ct = default)
    {
        if (!Enum.TryParse<GlobalTransactionCategory>(categoryString, out var category))
            return Result.Failure<TransactionPolicyResponse>(FinancePolicyErrors.InvalidCategory);

        var updated = await _dbContext.TransactionSourcePolicies
            .Where(p => p.Category == category)
            .ExecuteUpdateAsync(setters => setters.SetProperty(p => p.AllowedSource, request.AllowedSource), ct);

        if (updated == 0)
            return Result.Failure<TransactionPolicyResponse>(FinancePolicyErrors.PolicyNotFound);

        var policy = await _dbContext.TransactionSourcePolicies
            .AsNoTracking()
            .Where(p => p.Category == category)
            .Select(p => new TransactionPolicyResponse(p.Id, p.Category.ToString(), p.AllowedSource.ToString()))
            .FirstAsync(ct);

        return Result.Success(policy);
    }

    public async Task<Result<PaymentSourcePolicy>> GetPolicyForCategoryAsync(
        GlobalTransactionCategory category, CancellationToken ct = default)
    {
        var allowedSource = await _dbContext.TransactionSourcePolicies
            .Where(p => p.Category == category)
            .Select(p => (PaymentSourcePolicy?)p.AllowedSource)
            .FirstOrDefaultAsync(ct);

        // Default to 'Either' if no policy is configured yet, rather than failing the transaction.
        return Result.Success(allowedSource ?? PaymentSourcePolicy.Either);
    }
}
```

## File: Services/Implementation/MaintenanceService.cs
```csharp
using Centraly.Api.Contracts.Maintenance;
using Centraly.Api.Entities.Maintenance;

namespace Centraly.Api.Services.Implementation;

public class MaintenanceService(
    ApplicationDbContext dbContext,
    IDrawerService drawerService,
    ILogger<MaintenanceService> logger) : IMaintenanceService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IDrawerService _drawerService = drawerService;
    private readonly ILogger<MaintenanceService> _logger = logger;

    private static readonly string[] AllowedSortColumns = ["CreatedAt", "DeliveryDate", "TotalPrice"];

    // ─────────────────────────────────────────────────────────────────
    //  Create Maintenance Ticket
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> CreateMaintenanceAsync(
        CreateMaintenanceRequest request, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var device = new MaintenanceDevice
            {
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                CustomerId = string.IsNullOrWhiteSpace(request.CustomerId) ? null : request.CustomerId,
                DeviceDescription = request.DeviceDescription,
                Problem = request.Problem,
                PaidAmount = request.PaidAmount,
                DeliveryDate = request.DeliveryDate,
                Status = MaintenanceStatus.Pending,
                CreatedByUserId = userId
            };

            _dbContext.MaintenanceDevices.Add(device);
            await _dbContext.SaveChangesAsync(ct);

            if (request.PaidAmount > 0)
            {
                var drawerResult = await _drawerService.RecordTransactionAsync(
                    DrawerTransactionCategory.Maintenance,
                    DrawerTransactionType.Income,
                    request.PaidAmount,
                    0, // profit
                    $"مقدم صيانة - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);

                if (drawerResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<MaintenanceResponse>(drawerResult.Error);
                }
            }

            await transaction.CommitAsync(ct);
            return Result.Success(MapToResponse(device));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating maintenance ticket");
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Update Maintenance Ticket
    // ─────────────────────────────────────────────────────────────────
    // NOTE - root cause (confirmed from SQL logs): this app has a global soft-delete
    // interceptor (ApplicationDbContext.ApplyAuditAndSoftDelete) that converts every
    // EntityState.Deleted entry into EntityState.Modified + IsDeleted = true, so
    // Remove()/RemoveRange() never issues a real SQL DELETE for any BaseEntity.
    //
    // The problem: before that interceptor runs, EF has already performed its normal
    // relationship fixup for a dependent being removed from a REQUIRED collection
    // navigation - it nulls the dependent's FK in memory, on the assumption the row
    // is about to be deleted for real. Since the row is actually only soft-deleted
    // (an UPDATE, not a DELETE), that null FK gets sent to the database and is
    // rejected because MaintenanceDeviceId is NOT NULL.
    //
    // Fix: never call Remove()/RemoveRange() on MaintenanceProductItem here. Soft-
    // delete it by hand (IsDeleted/DeletedAt as plain property assignments) so EF's
    // change tracker only ever sees a partial UPDATE of those two columns, and the
    // FK is never touched. The existing global query filter (WHERE IsDeleted = 0)
    // already keeps these rows out of every other query.
    //
    // Product items are also reconciled (matched by ProductId) instead of being
    // deleted-and-recreated wholesale: unchanged items are left completely alone,
    // matched items just get their Quantity/MaintenancePrice updated, removed items
    // are soft-deleted as above, and only genuinely new items are inserted.

    public async Task<Result<MaintenanceResponse>> UpdateMaintenanceAsync(
        string id, UpdateMaintenanceRequest request, string userId, CancellationToken ct = default)
    {
        var device = await _dbContext.MaintenanceDevices
            .Include(m => m.ProductsUsed)
            .FirstOrDefaultAsync(m => m.Id == id, ct);

        if (device is null)
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound);

        if (device.Status != MaintenanceStatus.Pending)
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.InvalidStatus);

        // Reconciliation assumes one row per product per ticket.
        var requestedProductIds = request.ProductsUsed.Select(p => p.ProductId).ToList();
        if (requestedProductIds.Distinct().Count() != requestedProductIds.Count)
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.DuplicateProduct);

        if (requestedProductIds.Count > 0)
        {
            var existingProductCount = await _dbContext.Products
                .CountAsync(p => requestedProductIds.Contains(p.Id) && !p.IsDeleted, ct);

            if (existingProductCount != requestedProductIds.Count)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.ProductNotFound);
        }

        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            device.CustomerName = request.CustomerName;
            device.CustomerPhone = request.CustomerPhone;
            device.CustomerId = string.IsNullOrWhiteSpace(request.CustomerId) ? null : request.CustomerId;
            device.DeviceDescription = request.DeviceDescription;
            device.Problem = request.Problem;
            device.Solution = request.Solution;
            device.ServicePrice = request.ServicePrice;
            device.DeliveryDate = request.DeliveryDate;
            device.PaidAmount = request.PaidAmount;
            device.UpdatedAt = DateTime.UtcNow;
            device.UpdatedByUserId = userId;

            var existingItemsByProductId = device.ProductsUsed.ToDictionary(i => i.ProductId);
            var requestedByProductId = request.ProductsUsed.ToDictionary(p => p.ProductId);

            // 1) Items that existed before but aren't in the new list anymore ->
            // soft-delete by hand. Do NOT call Remove()/RemoveRange() and do NOT
            // touch device.ProductsUsed - see the note above on why that nulls the
            // required MaintenanceDeviceId FK via EF's relationship fixup.
            var itemsToRemove = device.ProductsUsed
                .Where(i => !requestedByProductId.ContainsKey(i.ProductId))
                .ToList();

            foreach (var item in itemsToRemove)
            {
                item.IsDeleted = true;
                item.DeletedAt = DateTime.UtcNow;
                item.UpdatedAt = DateTime.UtcNow;
                item.UpdatedByUserId = userId;
            }

            // 2) Items present in both -> update in place (no FK touched at all).
            foreach (var requested in request.ProductsUsed)
            {
                if (existingItemsByProductId.TryGetValue(requested.ProductId, out var existing))
                {
                    existing.Quantity = requested.Quantity;
                    existing.MaintenancePrice = requested.MaintenancePrice;
                    existing.UpdatedAt = DateTime.UtcNow;
                    existing.UpdatedByUserId = userId;
                }
            }

            // 3) Items only in the new list -> insert as new rows.
            var newItems = request.ProductsUsed
                .Where(p => !existingItemsByProductId.ContainsKey(p.ProductId))
                .Select(p => new MaintenanceProductItem
                {
                    MaintenanceDeviceId = device.Id,
                    MaintenanceDevice = device,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    MaintenancePrice = p.MaintenancePrice,
                    CreatedByUserId = userId
                })
                .ToList();

            if (newItems.Count > 0)
            {
                _dbContext.MaintenanceProductItems.AddRange(newItems);
            }

            device.TotalPartsPrice = request.ProductsUsed.Sum(p => p.MaintenancePrice * p.Quantity);
            device.TotalPrice = device.ServicePrice + device.TotalPartsPrice;

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return await GetByIdAsync(device.Id, ct);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error updating maintenance ticket {MaintenanceId}", id);
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.UpdateFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Deliver Maintenance Ticket
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> DeliverMaintenanceAsync(
        string id, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var device = await _dbContext.MaintenanceDevices
                .Include(m => m.ProductsUsed)
                    .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id, ct);

            if (device is null)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound);

            if (device.Status != MaintenanceStatus.Pending)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.AlreadyDelivered);

            decimal totalCost = 0;

            foreach (var item in device.ProductsUsed)
            {
                var batches = await _dbContext.ProductBatches
                    .Where(b => b.ProductId == item.ProductId && b.AvailableQuantity > 0)
                    .OrderBy(b => b.CreatedAt)
                    .ToListAsync(ct);

                var remaining = item.Quantity;
                decimal itemCost = 0;

                foreach (var batch in batches)
                {
                    if (remaining <= 0) break;

                    var toDeduct = Math.Min(remaining, batch.AvailableQuantity);
                    batch.AvailableQuantity -= toDeduct;
                    batch.UpdatedAt = DateTime.UtcNow;
                    itemCost += toDeduct * batch.PurchasePrice;
                    remaining -= toDeduct;
                }

                if (remaining > 0)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<MaintenanceResponse>(MaintenanceErrors.InsufficientStock(item.Product?.Name ?? item.ProductId));
                }

                if (item.Product is not null)
                {
                    item.Product.Quantity -= item.Quantity;
                    item.Product.UpdatedAt = DateTime.UtcNow;
                }

                item.CostPrice = item.Quantity > 0 ? itemCost / item.Quantity : 0;
                totalCost += itemCost;
            }

            device.TotalCost = totalCost;
            device.Status = MaintenanceStatus.Delivered;
            device.UpdatedAt = DateTime.UtcNow;
            device.UpdatedByUserId = userId;

            decimal profit = device.TotalPrice - totalCost;
            var remainingAmount = device.TotalPrice - device.PaidAmount;

            Result<Centraly.Api.Contracts.Drawer.DrawerTransactionResponse> drawerResult;
            if (remainingAmount >= 0)
            {
                drawerResult = await _drawerService.RecordTransactionAsync(
                    DrawerTransactionCategory.Maintenance,
                    DrawerTransactionType.Income,
                    remainingAmount,
                    profit,
                    $"تسليم صيانة - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);
            }
            else
            {
                drawerResult = await _drawerService.RecordTransactionAsync(
                    DrawerTransactionCategory.Maintenance,
                    DrawerTransactionType.Expense,
                    Math.Abs(remainingAmount),
                    profit,
                    $"رد فرق تسليم صيانة - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);
            }

            if (drawerResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<MaintenanceResponse>(drawerResult.Error);
            }

            device.PaidAmount = device.TotalPrice;

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return Result.Success(MapToResponse(device));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error delivering maintenance ticket {Id}", id);
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.DeliveryFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Return Maintenance Ticket (before repair - no parts were consumed yet)
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> ReturnMaintenanceAsync(
        string id, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var device = await _dbContext.MaintenanceDevices.FirstOrDefaultAsync(m => m.Id == id, ct);

            if (device is null)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound);

            if (device.Status != MaintenanceStatus.Pending)
                return Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotPending);

            device.Status = MaintenanceStatus.Returned;
            device.UpdatedAt = DateTime.UtcNow;
            device.UpdatedByUserId = userId;

            if (device.PaidAmount > 0)
            {
                var drawerResult = await _drawerService.RecordTransactionAsync(DrawerTransactionCategory.Maintenance, DrawerTransactionType.Expense, device.PaidAmount, 0, $"رد مقدم صيانة (إرجاع بدون إصلاح) - العميل: {device.CustomerName}",
                    device.Id,
                    userId,
                    ct);

                if (drawerResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<MaintenanceResponse>(drawerResult.Error);
                }

                device.PaidAmount = 0;
            }

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return Result.Success(MapToResponse(device));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error returning maintenance ticket {Id}", id);
            return Result.Failure<MaintenanceResponse>(MaintenanceErrors.ReturnFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All (paginated, searchable, sortable)
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<PaginatedList<MaintenanceSummary>>> GetAllMaintenanceAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.MaintenanceDevices.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Status) && Enum.TryParse<MaintenanceStatus>(filters.Status, true, out var statusEnum))
            {
                query = query.Where(m => m.Status == statusEnum);
            }

            if (filters.StartDate.HasValue)
                query = query.Where(m => m.CreatedAt >= filters.StartDate.Value);
            
            if (filters.EndDate.HasValue)
                query = query.Where(m => m.CreatedAt <= filters.EndDate.Value);

            query = query.ApplyFilters(filters,
                    searchPredicate: x => x.CustomerName.Contains(filters.SearchValue!) ||
                                          (x.CustomerPhone != null && x.CustomerPhone.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(m => m.CreatedAt);

            var mappedQuery = query
                .Select(m => new MaintenanceSummary(
                    m.Id, m.CustomerName, m.CustomerPhone, m.DeviceDescription, m.Problem,
                    m.TotalPrice, m.PaidAmount, m.RemainingAmount, m.DeliveryDate, m.Status.ToString(), m.CreatedAt))
                .AsNoTracking();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for maintenance tickets");
            return Result.Failure<PaginatedList<MaintenanceSummary>>(MaintenanceErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get By Id (selection loading - no Include)
    // ─────────────────────────────────────────────────────────────────
    public async Task<Result<MaintenanceResponse>> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.MaintenanceDevices
            .Where(m => m.Id == id)
            .Select(m => new MaintenanceResponse(
                m.Id, m.CustomerName, m.CustomerPhone, m.CustomerId, m.DeviceDescription, m.Problem, m.Solution,
                m.ServicePrice, m.TotalPartsPrice, m.TotalPrice, m.TotalCost, m.PaidAmount, m.RemainingAmount,
                m.DeliveryDate, m.Status.ToString(),
                m.ProductsUsed.Select(p => new MaintenanceProductItemDto(
                    p.ProductId, p.Product != null ? p.Product.Name ?? string.Empty : string.Empty,
                    p.Quantity, p.MaintenancePrice, p.CostPrice))
                    .ToList(),
                m.CreatedAt))
            .AsNoTracking()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<MaintenanceResponse>(MaintenanceErrors.NotFound)
            : Result.Success(response);
    }

    private static MaintenanceResponse MapToResponse(MaintenanceDevice m) => new(
        m.Id, m.CustomerName, m.CustomerPhone, m.CustomerId, m.DeviceDescription, m.Problem, m.Solution,
        m.ServicePrice, m.TotalPartsPrice, m.TotalPrice, m.TotalCost, m.PaidAmount, m.RemainingAmount,
        m.DeliveryDate, m.Status.ToString(),
        m.ProductsUsed.Select(p => new MaintenanceProductItemDto(
            p.ProductId, p.Product?.Name ?? string.Empty, p.Quantity, p.MaintenancePrice, p.CostPrice)).ToList(),
        m.CreatedAt);
}
```

## File: Services/Implementation/OwnerTransactionService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class OwnerTransactionService(
    ApplicationDbContext dbContext,
    ITransactionRouterService transactionRouter) : IOwnerTransactionService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;

    public async Task<Result<OwnerTransactionResponse>> CreateOwnerTransactionAsync(
        CreateOwnerTransactionRequest request, string userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var ownerTransaction = new OwnerTransaction
            {
                Category = request.Category,
                Amount = request.Amount,
                PaymentSource = request.PaymentSource,
                Notes = request.Notes,
                CreatedByUserId = userId
            };

            _dbContext.OwnerTransactions.Add(ownerTransaction);

            var routeResult = await _transactionRouter.RouteTransactionAsync(category: ownerTransaction.Category, amount: ownerTransaction.Amount, profit: 0,
                requestedSource: ownerTransaction.PaymentSource,
                notes: ownerTransaction.Notes,
                referenceId: ownerTransaction.Id,
                userId: userId,
                ct: ct);

            if (routeResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<OwnerTransactionResponse>(routeResult.Error);
            }

            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            var response = ownerTransaction.ToResponse();
            return Result.Success(response);
        }
        catch
        {
            await transaction.RollbackAsync(ct);
            throw;
        }
    }

    public async Task<Result<IEnumerable<OwnerTransactionResponse>>> GetOwnerTransactionsAsync(CancellationToken ct = default)
    {
        var transactions = await _dbContext.OwnerTransactions
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedAt)
            .ProjectToResponse()
            .ToListAsync(ct);

        return Result.Success<IEnumerable<OwnerTransactionResponse>>(transactions);
    }
}
```

## File: Services/Implementation/ProductService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class ProductService(
    ApplicationDbContext _dbContext,
    IWebHostEnvironment _env,
    IHttpContextAccessor _accessor,
    ILogger<ProductService> _logger) : IProductService
{
    public async Task<Result<ProductResponse>> AddProductAsync(CreateProductRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var departmentExists = await _dbContext.Departments.AnyAsync(d => d.Id == request.DepartmentId && !d.IsDeleted, ct);
            if (!departmentExists) return Result.Failure<ProductResponse>(ProductErrors.DepartmentNotFound);

            var category = await _dbContext.Categories
                .Where(c => c.Id == request.CategoryId && c.DepartmentId == request.DepartmentId && !c.IsDeleted)
                .FirstOrDefaultAsync(ct);

            if (category is null) return Result.Failure<ProductResponse>(ProductErrors.CategoryNotFound);

            if (!string.IsNullOrWhiteSpace(request.Barcode))
            {
                var barcodeExists = await _dbContext.Products.AnyAsync(p => p.Barcode == request.Barcode && !p.IsDeleted, ct);
                if (barcodeExists) return Result.Failure<ProductResponse>(ProductErrors.BarcodeAlreadyExists);
            }

            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Barcode = request.Barcode,
                Name = request.Name,
                DepartmentId = request.DepartmentId,
                CategoryId = request.CategoryId,
                Quantity = 0, // Opens with 0, requires Purchase Invoice
                MinQuantityAlert = request.MinQuantityAlert,
                StorageLocation = request.StorageLocation,
                Usage = (ProductUsage)request.Usage,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            if (request.Image is not null)
            {
                product.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/products", _env, _accessor);
            }

            if (request.Properties is not null && request.Properties.Any())
            {
                foreach (var prop in request.Properties)
                {
                    product.Properties.Add(new ProductProperty
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = prop.Key,
                        Value = prop.Value,
                        CreatedAt = DateTime.UtcNow,
                        CreatedByUserId = userId
                    });
                }
            }

            await _dbContext.Products.AddAsync(product, ct);
            await _dbContext.SaveChangesAsync(ct);

            return await GetProductAsync(product.Id, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a product");
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<ProductResponse>> GetProductAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var productProjection = await _dbContext.Products
                .Where(p => p.Id == id)
                .ProjectToIntermediate()
                .FirstOrDefaultAsync(ct);

            if (productProjection is null)
                return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);

            return Result.Success(productProjection.ToResponse());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving product {ProductId}", id);
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<PaginatedList<ProductResponse>>> GetAllProductsAsync(RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Products
                .AsNoTracking()
                .Where(p => !p.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.SearchValue))
            {
                string search = filters.SearchValue.Trim().ToLower();
                query = query.Where(p => p.Name!.ToLower().Contains(search) || (p.Barcode != null && p.Barcode.Contains(search)));
            }

            if (!string.IsNullOrWhiteSpace(filters.CategoryId))
            {
                query = query.Where(p => p.CategoryId == filters.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(filters.DepartmentId))
            {
                query = query.Where(p => p.DepartmentId == filters.DepartmentId);
            }

            if (!string.IsNullOrWhiteSpace(filters.StockStatus))
            {
                if (filters.StockStatus.Equals("OutOfStock", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(p => p.Quantity <= 0);
                }
                else if (filters.StockStatus.Equals("LowStock", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(p => p.Quantity > 0 && p.Quantity <= p.MinQuantityAlert);
                }
                else if (filters.StockStatus.Equals("InStock", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(p => p.Quantity > p.MinQuantityAlert);
                }
            }

            // Fixed Usage filter mapping based on Claude's analysis
            if (filters.Usage.HasValue)
            {
                query = query.Where(p => p.Usage == (ProductUsage)filters.Usage.Value);
            }
            if (filters.ExcludeUsage.HasValue)
            {
                query = query.Where(p => p.Usage != (ProductUsage)filters.ExcludeUsage.Value);
            }

            var totalCount = await query.CountAsync(ct);

            query = filters.SortDirection == SortDirection.Desc
                 ? query.OrderByDescending(p => p.CreatedAt).ThenBy(p => p.Id)
                 : query.OrderBy(p => p.CreatedAt).ThenBy(p => p.Id);

            var pagedProductIds = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize)
                .Select(p => p.Id)
                .ToListAsync(ct);

            var projections = await _dbContext.Products
                .Where(p => pagedProductIds.Contains(p.Id))
                .ProjectToIntermediate()
                .ToListAsync(ct);

            var responses = projections
                .OrderBy(p => pagedProductIds.IndexOf(p.ProductId))
                .Select(p => p.ToResponse())
                .ToList();

            return Result.Success(new PaginatedList<ProductResponse>(responses, filters.PageNumber, filters.PageSize, totalCount));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving products");
            return Result.Failure<PaginatedList<ProductResponse>>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<List<ProductSupplierResponse>>> GetProductSuppliersAsync(string productId, CancellationToken ct = default)
    {
        try
        {
            var productExists = await _dbContext.Products.AnyAsync(p => p.Id == productId && !p.IsDeleted, ct);
            if (!productExists) return Result.Failure<List<ProductSupplierResponse>>(ProductErrors.ProductNotFound);

            var batches = await _dbContext.ProductBatches
                .Include(b => b.Supplier)
                .Where(b => b.ProductId == productId && !b.IsDeleted)
                .Select(b => new
                {
                    b.SupplierId,
                    SupplierName = b.Supplier!.Name,
                    b.PurchasePrice,
                    b.InitialQuantity,
                    b.DateReceived
                })
                .ToListAsync(ct);

            var result = batches
                .Where(x => x.SupplierId != null)
                .GroupBy(x => new { x.SupplierId, x.SupplierName })
                .Select(g => new ProductSupplierResponse(
                    g.Key.SupplierId!,
                    g.Key.SupplierName,
                    g.OrderByDescending(x => x.DateReceived).First().PurchasePrice,
                    g.Max(x => x.DateReceived),
                    g.Sum(x => x.InitialQuantity)
                ))
                .OrderByDescending(x => x.LastPurchaseDate)
                .ToList();

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving suppliers for product {ProductId}", productId);
            return Result.Failure<List<ProductSupplierResponse>>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<ProductResponse>> UpdateProductAsync(string id, UpdateProductRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var product = await _dbContext.Products
                .Include(p => p.Properties)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, ct);

            if (product is null) return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);

            if (product.DepartmentId != request.DepartmentId)
            {
                var departmentExists = await _dbContext.Departments.AnyAsync(d => d.Id == request.DepartmentId && !d.IsDeleted, ct);
                if (!departmentExists) return Result.Failure<ProductResponse>(ProductErrors.DepartmentNotFound);
                product.DepartmentId = request.DepartmentId;
            }

            if (product.CategoryId != request.CategoryId)
            {
                var categoryExists = await _dbContext.Categories.AnyAsync(c => c.Id == request.CategoryId && !c.IsDeleted, ct);
                if (!categoryExists) return Result.Failure<ProductResponse>(ProductErrors.CategoryNotFound);
                product.CategoryId = request.CategoryId;
            }

            if (!string.IsNullOrWhiteSpace(request.Barcode) && request.Barcode != product.Barcode)
            {
                var barcodeExists = await _dbContext.Products.AnyAsync(p => p.Barcode == request.Barcode && p.Id != id && !p.IsDeleted, ct);
                if (barcodeExists) return Result.Failure<ProductResponse>(ProductErrors.BarcodeAlreadyExists);
            }

            product.Barcode = request.Barcode;
            product.Name = request.Name;
            product.MinQuantityAlert = request.MinQuantityAlert;
            product.StorageLocation = request.StorageLocation;
            product.Usage = (ProductUsage)request.Usage;

            if (request.Image is not null)
            {
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    FileHelper.DeleteFile(product.ImageUrl, "uploads/products", _env);
                }
                product.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/products", _env, _accessor);
            }

            if (request.Properties is not null)
            {
                _dbContext.ProductProperties.RemoveRange(product.Properties);
                foreach (var prop in request.Properties)
                {
                    product.Properties.Add(new ProductProperty
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = prop.Key,
                        Value = prop.Value,
                        CreatedAt = DateTime.UtcNow,
                        CreatedByUserId = userId
                    });
                }
            }

            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedByUserId = userId;

            await _dbContext.SaveChangesAsync(ct);
            return await GetProductAsync(product.Id, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating product {ProductId}", id);
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<ProductResponse>> AdjustQuantityAsync(
        string id, AdjustProductQuantityRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, ct);

            if (product is null) return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);

            int diff = request.NewQuantity - product.Quantity;
            if (diff != 0)
            {
                // Fix for Claude issue 1.4: Instead of just changing Product.Quantity, we add an adjustment batch
                // to maintain perfect sync with the Batches system.
                var adjustmentBatch = new ProductBatch
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = id,
                    InitialQuantity = diff,
                    AvailableQuantity = diff, // Handles both positive (surplus) and negative (loss/shrinkage)
                    PurchasePrice = 0,
                    WholesalePrice = 0,
                    RetailPrice = 0,
                    MaintenancePrice = 0,
                    DateReceived = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = userId
                };
                await _dbContext.ProductBatches.AddAsync(adjustmentBatch, ct);
            }

            product.Quantity = request.NewQuantity;
            product.UpdatedAt = DateTime.UtcNow;
            product.UpdatedByUserId = userId;

            await _dbContext.SaveChangesAsync(ct);
            return await GetProductAsync(id, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adjusting quantity for product {ProductId}", id);
            return Result.Failure<ProductResponse>(ProductErrors.ProductNotFound);
        }
    }

    public async Task<Result<bool>> DeleteProductAsync(string id, CancellationToken ct = default)
    {
        try
        {
            // Improved Delete utilizing ExecuteUpdateAsync (Issue 2.2)
            var rowsAffected = await _dbContext.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.IsDeleted, true)
                    .SetProperty(p => p.DeletedAt, DateTime.UtcNow), ct);

            if (rowsAffected == 0) return Result.Failure<bool>(ProductErrors.ProductNotFound);

            return Result.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting product {ProductId}", id);
            return Result.Failure<bool>(ProductErrors.ProductNotFound);
        }
    }
}
```

## File: Services/Implementation/PurchaseInvoiceService.cs
```csharp
using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class PurchaseInvoiceService(
    ApplicationDbContext dbContext,
    ILogger<PurchaseInvoiceService> logger,
    ITransactionRouterService transactionRouter) : IPurchaseInvoiceService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<PurchaseInvoiceService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;

    private static readonly string[] AllowedInvoiceSortColumns = ["InvoiceNumber", "InvoiceDate", "TotalAmount", "PaidAmount"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Purchase Invoice
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PurchaseInvoiceResponse>> AddPurchaseInvoiceAsync(
        CreatePurchaseInvoiceRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var supplier = await _dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.SupplierId && !s.IsDeleted, ct);

            if (supplier is null)
                return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.SupplierNotFound);

            var productIds = request.Items.Select(i => i.ProductId).ToList();

            var products = await _dbContext.Products
                .Where(p => productIds.Contains(p.Id) && !p.IsDeleted)
                .ToDictionaryAsync(p => p.Id, ct);

            if (products.Count != request.Items.Count)
                return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.ProductNotFound);

            var invoiceNumber = $"PI-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";

            var invoice = new PurchaseInvoice
            {
                InvoiceNumber = invoiceNumber,
                SupplierId = supplier.Id,
                PaidAmount = request.PaidAmount,
                Notes = request.Notes,
                InvoiceDate = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            decimal totalAmount = 0;
            var responseItems = new List<PurchaseInvoiceItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var product = products[itemReq.ProductId];
                var lineTotal = itemReq.Quantity * itemReq.UnitCost;
                totalAmount += lineTotal;

                product.Quantity += itemReq.Quantity;
                product.UpdatedAt = DateTime.UtcNow;
                product.UpdatedByUserId = userId;

                var invoiceItem = new PurchaseInvoiceItem
                {
                    PurchaseInvoiceId = invoice.Id,
                    ProductId = product.Id,
                    Quantity = itemReq.Quantity,
                    UnitCost = itemReq.UnitCost,
                    CreatedByUserId = userId
                };

                var batch = new ProductBatch
                {
                    ProductId = product.Id,
                    SupplierId = supplier.Id,
                    InitialQuantity = itemReq.Quantity,
                    AvailableQuantity = itemReq.Quantity,
                    PurchasePrice = itemReq.UnitCost,
                    WholesalePrice = itemReq.WholesalePrice,
                    RetailPrice = itemReq.RetailPrice,
                    MaintenancePrice = itemReq.MaintenancePrice ?? 0,
                    DateReceived = invoice.InvoiceDate,
                    CreatedByUserId = userId
                };

                _dbContext.ProductBatches.Add(batch);
                invoice.Items.Add(invoiceItem);

                responseItems.Add(new PurchaseInvoiceItemResponse(
                    invoiceItem.Id,
                    new ProductSummary(product.Id, product.Name, product.Barcode, product.ImageUrl, batch.RetailPrice, batch.WholesalePrice, product.Quantity),
                    invoiceItem.Quantity,
                    invoiceItem.UnitCost,
                    lineTotal));
            }

            if (request.PaidAmount > totalAmount)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.InvalidPaidAmount);
            }

            invoice.TotalAmount = totalAmount;

            var remaining = invoice.TotalAmount - invoice.PaidAmount;
            supplier.DebtBalance += remaining;
            supplier.UpdatedAt = DateTime.UtcNow;
            supplier.UpdatedByUserId = userId;

            _dbContext.PurchaseInvoices.Add(invoice);
            await _dbContext.SaveChangesAsync(ct);

            if (request.PaidAmount > 0)
            {
                var routeResult = await _transactionRouter.RouteTransactionAsync(GlobalTransactionCategory.CashPurchase, request.PaidAmount, 0, request.PaymentSource,
                    $"Purchase Invoice {invoice.Id}", invoice.Id, userId ?? "", ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<PurchaseInvoiceResponse>(routeResult.Error);
                }
            }

            await transaction.CommitAsync(ct);

            var response = new PurchaseInvoiceResponse(
                invoice.Id,
                invoice.InvoiceNumber,
                new SupplierSummary(supplier.Id, supplier.Name, supplier.Phone),
                invoice.TotalAmount,
                invoice.PaidAmount,
                invoice.RemainingAmount,
                invoice.InvoiceDate,
                invoice.Notes,
                responseItems);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error occurred while creating purchase invoice for user {UserId}", userId);
            return Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Purchase Invoice By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PurchaseInvoiceResponse>> GetPurchaseInvoiceAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.PurchaseInvoices
            .Where(i => i.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<PurchaseInvoiceResponse>(PurchaseInvoiceErrors.InvoiceNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Purchase Invoices
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<PurchaseInvoiceResponse>>> GetAllPurchaseInvoicesAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.PurchaseInvoices
                .Where(i => !i.IsDeleted)
                .Where(i => filters.SupplierId == null || i.SupplierId == filters.SupplierId)
                .Where(i => filters.StartDate == null || i.InvoiceDate >= filters.StartDate)
                .Where(i => filters.EndDate == null || i.InvoiceDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => (x.InvoiceNumber != null && x.InvoiceNumber.Contains(filters.SearchValue!)) ||
                                          (x.Supplier!.Name != null && x.Supplier.Name.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedInvoiceSortColumns)
                .ProjectToSummaryResponse();

            var result = await query.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for purchase invoices");
            return Result.Failure<PaginatedList<PurchaseInvoiceResponse>>(PurchaseInvoiceErrors.InvalidSortColumn);
        }
    }
}
```

## File: Services/Implementation/ReturnProcessingService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class ReturnProcessingService(
    ApplicationDbContext dbContext,
    ITransactionRouterService transactionRouter,
    ILogger<ReturnProcessingService> logger) : IReturnProcessingService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;
    private readonly ILogger<ReturnProcessingService> _logger = logger;

    public async Task<Result<ReturnRecordResponse>> ProcessReturnAsync(
        CreateCustomerReturnRequest request, string? userId, string? expectedCustomerId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var invoice = await _dbContext.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == request.InvoiceId && !i.IsDeleted, ct);

            if (invoice is null)
                return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.InvoiceNotFound);

            // If the caller is scoped to a specific customer (e.g. /customers/{id}/returns),
            // make sure the invoice actually belongs to that customer.
            if (expectedCustomerId is not null && invoice.CustomerId != expectedCustomerId)
                return Result.Failure<ReturnRecordResponse>(CustomerErrors.CustomerNotFound);

            var returnRecord = new ReturnRecord
            {
                InvoiceId = invoice.Id,
                IsFullInvoiceReturn = false,
                Reason = (ReturnReason)request.Reason,
                Notes = request.Notes,
                ReturnDate = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            var existingReturns = await _dbContext.ReturnItems
                .Where(ri => ri.ReturnRecord.InvoiceId == invoice.Id)
                .ToListAsync(ct);

            decimal totalReturnedAmount = 0;
            decimal totalReversedProfit = 0;
            var responseItems = new List<ReturnItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var invoiceItem = invoice.Items.FirstOrDefault(i => i.ProductId == itemReq.ProductId && i.BatchId == itemReq.BatchId);
                var returnedSoFar = existingReturns
                    .Where(ri => ri.ProductId == itemReq.ProductId && ri.BatchId == itemReq.BatchId)
                    .Sum(ri => ri.Quantity);

                if (invoiceItem is null || itemReq.Quantity > invoiceItem.Quantity - returnedSoFar)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.InvalidReturn);
                }

                var batch = await _dbContext.ProductBatches
                    .Include(b => b.Product)
                    .FirstOrDefaultAsync(b => b.Id == itemReq.BatchId && !b.IsDeleted, ct);

                if (batch?.Product is null)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.ProductNotFound);
                }

                batch.AvailableQuantity += itemReq.Quantity;
                batch.UpdatedAt = DateTime.UtcNow;

                batch.Product.Quantity += itemReq.Quantity;
                batch.Product.UpdatedAt = DateTime.UtcNow;

                // NOTE - bug fix: the refunded/credited amount must be based on the price
                // actually charged on the original invoice line, not on whatever UnitPrice
                // the caller happens to send in the request. Trusting the client value here
                // let a return be priced higher than what the customer ever paid.
                var unitPrice = invoiceItem.UnitPrice;
                var lineTotal = itemReq.Quantity * unitPrice;
                totalReturnedAmount += lineTotal;
                totalReversedProfit += (unitPrice - invoiceItem.UnitCost) * itemReq.Quantity;

                var returnItem = new ReturnItem
                {
                    ReturnRecordId = returnRecord.Id,
                    ProductId = itemReq.ProductId,
                    BatchId = itemReq.BatchId,
                    Quantity = itemReq.Quantity,
                    UnitPrice = unitPrice,
                    CreatedByUserId = userId
                };

                returnRecord.Items.Add(returnItem);

                responseItems.Add(new ReturnItemResponse(
                    returnItem.Id, returnItem.ProductId, returnItem.BatchId, returnItem.Quantity, returnItem.UnitPrice));
            }

            returnRecord.TotalReturnedAmount = totalReturnedAmount;

            if (request.IsCashRefund)
            {
                var routerResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.SalesReturn, totalReturnedAmount, -totalReversedProfit, request.PaymentSource,
                    $"Refund for Invoice {invoice.InvoiceNumber}", returnRecord.Id, userId ?? string.Empty, ct);

                if (routerResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<ReturnRecordResponse>(routerResult.Error);
                }

                if (routerResult.Value.Source == PaymentSource.Drawer)
                {
                    returnRecord.DrawerTransactionId = routerResult.Value.Id;
                    await _dbContext.SaveChangesAsync(ct);
                }
            }
            else if (!string.IsNullOrEmpty(invoice.CustomerId))
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == invoice.CustomerId && !c.IsDeleted, ct);
                if (customer is not null)
                {
                    var invoiceOutstandingDebt = Math.Max(0, invoice.TotalAmount - invoice.PaidAmount);
                    var creditableAmount = Math.Min(totalReturnedAmount, invoiceOutstandingDebt);

                    customer.DebtBalance -= creditableAmount;
                    invoice.PaidAmount += creditableAmount; // Reduce remaining debt

                    var cashOwedToCustomer = totalReturnedAmount - creditableAmount;
                    if (cashOwedToCustomer > 0)
                    {
                        await transaction.RollbackAsync(ct);
                        return Result.Failure<ReturnRecordResponse>(new Error("Return.RequiresCashRefund", $"Return amount exceeds outstanding debt by {cashOwedToCustomer}; must be processed as a cash refund.", 400));
                    }

                    customer.UpdatedAt = DateTime.UtcNow;
                    customer.UpdatedByUserId = userId;
                }
            }
            else
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.InvalidReturn);
            }

            _dbContext.Returns.Add(returnRecord);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            var response = new ReturnRecordResponse(
                returnRecord.Id, returnRecord.InvoiceId, invoice.InvoiceNumber, returnRecord.IsFullInvoiceReturn,
                (ReturnReasonDto)returnRecord.Reason, returnRecord.Notes, request.IsCashRefund,
                returnRecord.TotalReturnedAmount, returnRecord.ReturnDate, responseItems);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error processing return for invoice {InvoiceId}", request.InvoiceId);
            return Result.Failure<ReturnRecordResponse>(SalesReturnErrors.CreationFailed);
        }
    }
}
```

## File: Services/Implementation/RoleService.cs
```csharp
using Centraly.Api.Contracts.Roles;
using Mapster;

namespace Centraly.Api.Services;

public class RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context) : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
        await _roleManager.Roles
            .Where(x => !x.IsDefault && (!x.IsDeleted || includeDisabled))
            .ProjectToType<RoleResponse>()
            .ToListAsync(cancellationToken);

    public async Task<Result<RoleDetailResponse>> GetAsync(string id)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);

        var permissions = await _roleManager.GetClaimsAsync(role);

        var response = new RoleDetailResponse(role.Id, role.Name!, role.IsDeleted, permissions.Select(x => x.Value));

        return Result.Success(response);
    }

    public async Task<Result<RoleDetailResponse>> AddAsync(RoleRequest request)
    {
        var roleIsExists = await _roleManager.RoleExistsAsync(request.Name);

        if (roleIsExists)
            return Result.Failure<RoleDetailResponse>(RoleErrors.DuplicatedRole);

        var allowedPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure<RoleDetailResponse>(RoleErrors.InvalidPermissions);

        var role = new ApplicationRole
        {
            Name = request.Name,
            ConcurrencyStamp = Guid.CreateVersion7().ToString()
        };

        var result = await _roleManager.CreateAsync(role);

        if (result.Succeeded)
        {
            var permissions = request.Permissions
                .Select(x => new IdentityRoleClaim<string>
                {
                    ClaimType = Permissions.Type,
                    ClaimValue = x,
                    RoleId = role.Id
                });

            await _context.AddRangeAsync(permissions);
            await _context.SaveChangesAsync();

            var response = new RoleDetailResponse(role.Id, role.Name, role.IsDeleted, request.Permissions);

            return Result.Success(response);
        }

        var error = result.Errors.First();

        return Result.Failure<RoleDetailResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> UpdateAsync(string id, RoleRequest request)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure(RoleErrors.RoleNotFound);

        var roleIsExists = await _roleManager.Roles
            .AnyAsync(x => x.Name == request.Name && x.Id != id);

        if (roleIsExists)
            return Result.Failure(RoleErrors.DuplicatedRole);

        var allowedPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure(RoleErrors.InvalidPermissions);

        role.Name = request.Name;

        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            var currentPermissions = await _context.RoleClaims
                .Where(x => x.RoleId == id && x.ClaimType == Permissions.Type)
                .Select(x => x.ClaimValue)
                .ToListAsync();

            var newPermissions = request.Permissions
                .Except(currentPermissions)
                .Select(x => new IdentityRoleClaim<string>
                {
                    ClaimType = Permissions.Type,
                    ClaimValue = x,
                    RoleId = role.Id
                });

            var removedPermissions = currentPermissions
                .Except(request.Permissions);

            await _context.RoleClaims
                .Where(x =>
                    x.RoleId == id &&
                    removedPermissions.Contains(x.ClaimValue))
                .ExecuteDeleteAsync();

            await _context.AddRangeAsync(newPermissions);

            await _context.SaveChangesAsync();

            return Result.Success();
        }

        var error = result.Errors.First();

        return Result.Failure(
            new Error(
                error.Code,
                error.Description,
                StatusCodes.Status400BadRequest));
    }

    public async Task<Result> ToggleStatusAsync(string id)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);

        role.IsDeleted = !role.IsDeleted;

        await _roleManager.UpdateAsync(role);

        return Result.Success();
    }
}
```

## File: Services/Implementation/SafeService.cs
```csharp
using Centraly.Api.Contracts.Finance;
using Centraly.Api.Contracts.Shared;
using Centraly.Api.Extensions;
namespace Centraly.Api.Services.Implementation;

public class SafeService(ApplicationDbContext dbContext) : ISafeService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Result<SafeResponse>> CreateSafeAsync(CreateSafeRequest request, string? userId, CancellationToken ct = default)
    {
        var safe = new Safe
        {
            Name = request.Name,
            Balance = request.InitialBalance,
            IsMain = request.IsMain,
            CreatedByUserId = userId
        };

        if (request.InitialBalance > 0)
        {
            safe.Transactions.Add(new SafeTransaction
            {
                TransactionType = DrawerTransactionType.Income,
                Category = SafeTransactionCategory.OwnerDeposit,
                Amount = request.InitialBalance,
                BalanceAfter = request.InitialBalance,
                Notes = "Initial Balance",
                CreatedByUserId = userId
            });
        }

        _dbContext.Safes.Add(safe);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new SafeResponse(safe.Id, safe.Name, safe.Balance, safe.IsMain));
    }

    public async Task<Result<IEnumerable<SafeResponse>>> GetSafesAsync(CancellationToken ct = default)
    {
        var safes = await _dbContext.Safes
            .Where(s => !s.IsDeleted)
            .ProjectToResponse()
            .ToListAsync(ct);

        return Result.Success<IEnumerable<SafeResponse>>(safes);
    }

    // Used by TransactionRouterService to find the main safe without pulling
    // every safe in the system over the wire just to filter client-side.
    public async Task<Result<SafeResponse>> GetMainSafeAsync(CancellationToken ct = default)
    {
        var safe = await _dbContext.Safes
            .Where(s => s.IsMain && !s.IsDeleted)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return safe is null
            ? Result.Failure<SafeResponse>(TransactionRouterErrors.NoMainSafe)
            : Result.Success(safe);
    }

    public async Task<Result<SafeTransactionResponse>> DepositFromDrawerAsync(
        string safeId, ReceiveDrawerDepositRequest request, string? userId, CancellationToken ct = default)
    {
        var safe = await _dbContext.Safes.FirstOrDefaultAsync(s => s.Id == safeId && !s.IsDeleted, ct);
        if (safe is null)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.SafeNotFound);

        var drawerSession = await _dbContext.DrawerSessions.FirstOrDefaultAsync(s => s.Id == request.DrawerSessionId, ct);
        if (drawerSession is null)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.DrawerNotFound);

        if (!drawerSession.IsClosed)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.DrawerNotClosed);
        // In a real system, we'd mark the DrawerSession as 'Deposited' to avoid double deposits.

        safe.Balance += request.Amount;
        safe.UpdatedAt = DateTime.UtcNow;
        safe.UpdatedByUserId = userId;

        var safeTx = new SafeTransaction
        {
            SafeId = safe.Id,
            TransactionType = DrawerTransactionType.Income,
            Category = SafeTransactionCategory.DrawerDeposit,
            Amount = request.Amount,
            BalanceAfter = safe.Balance,
            Notes = request.Notes ?? $"Deposit from Drawer Session: {request.DrawerSessionId}",
            CreatedByUserId = userId
        };

        _dbContext.SafeTransactions.Add(safeTx);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new SafeTransactionResponse(
            safeTx.Id, safeTx.SafeId, safeTx.TransactionType.ToString(), safeTx.Category.ToString(), safeTx.Amount, safeTx.BalanceAfter, safeTx.CreatedAt, safeTx.Notes));
    }

    public async Task<Result<SafeTransactionResponse>> AddManualTransactionAsync(
        string safeId, DrawerTransactionType type, SafeTransactionCategory category, decimal amount, decimal profit, string? notes, string? userId, CancellationToken ct = default)
    {
        var safe = await _dbContext.Safes.FirstOrDefaultAsync(s => s.Id == safeId && !s.IsDeleted, ct);
        if (safe is null)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.SafeNotFound);

        if (type == DrawerTransactionType.Expense && safe.Balance < amount)
            return Result.Failure<SafeTransactionResponse>(SafeErrors.InsufficientFunds);

        safe.Balance += type == DrawerTransactionType.Income ? amount : -amount;
        safe.UpdatedAt = DateTime.UtcNow;
        safe.UpdatedByUserId = userId;

        var safeTx = new SafeTransaction
        {
            SafeId = safe.Id,
            TransactionType = type,
            Category = category,
            Amount = amount,
            Profit = profit,
            BalanceAfter = safe.Balance,
            Notes = notes,
            CreatedByUserId = userId
        };

        _dbContext.SafeTransactions.Add(safeTx);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Success(new SafeTransactionResponse(
            safeTx.Id, safeTx.SafeId, safeTx.TransactionType.ToString(), safeTx.Category.ToString(), safeTx.Amount, safeTx.BalanceAfter, safeTx.CreatedAt, safeTx.Notes));
    }

    public async Task<Result<PaginatedList<SafeTransactionResponse>>> GetSafeTransactionsAsync(string safeId, FinanceFilters filters, CancellationToken ct = default)
    {
        var safeExists = await _dbContext.Safes.AnyAsync(s => s.Id == safeId && !s.IsDeleted, ct);
        if (!safeExists)
            return Result.Failure<PaginatedList<SafeTransactionResponse>>(SafeErrors.SafeNotFound);

        var query = _dbContext.SafeTransactions.Where(t => t.SafeId == safeId && !t.IsDeleted);

        if (filters.StartDate.HasValue)
            query = query.Where(t => t.CreatedAt >= filters.StartDate.Value);
        if (filters.EndDate.HasValue)
            query = query.Where(t => t.CreatedAt <= filters.EndDate.Value);

        var totalCount = await query.CountAsync(ct);
        var items = await query
            .OrderByDescending(t => t.CreatedAt)
            .ProjectToResponse()
            .Skip((filters.PageNumber - 1) * filters.PageSize)
            .Take(filters.PageSize)
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<SafeTransactionResponse>(items, totalCount, filters.PageNumber, filters.PageSize));
    }
}
```

## File: Services/Implementation/SalesInvoiceService.cs
```csharp
using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SalesInvoiceService(
    ApplicationDbContext dbContext,
    ILogger<SalesInvoiceService> logger,
    ITransactionRouterService transactionRouter) : ISalesInvoiceService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<SalesInvoiceService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;

    private static readonly string[] AllowedInvoiceSortColumns = ["CreatedAt", "InvoiceNumber", "TotalAmount"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Sales Invoice
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SalesInvoiceResponse>> AddInvoiceAsync(
        CreateSalesInvoiceRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            Customer? customer = null;
            var finalCustomerId = request.CustomerId;

            if (!string.IsNullOrWhiteSpace(finalCustomerId))
            {
                // Customer was passed explicitly - validate it actually exists.
                customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == finalCustomerId && !c.IsDeleted, ct);
                if (customer is null)
                    return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.CustomerNotFound);
            }
            else if (!string.IsNullOrWhiteSpace(request.CustomerPhone))
            {
                customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Phone == request.CustomerPhone && !c.IsDeleted, ct);

                if (customer is null)
                {
                    customer = new Customer
                    {
                        Name = string.IsNullOrWhiteSpace(request.CustomerName) ? "بدون اسم" : request.CustomerName,
                        Phone = request.CustomerPhone,
                        CreatedByUserId = userId
                    };
                    _dbContext.Customers.Add(customer);
                }

                finalCustomerId = customer.Id;
            }

            if (finalCustomerId is null && request.PaymentMethod == PaymentMethodDto.Deferred)
                return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InvalidPayment);

            var invoice = new Invoice
            {
                InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMddHHmmss}",
                CustomerId = finalCustomerId,
                SaleType = (SaleType)request.SaleType,
                PaymentMethod = (PaymentMethod)request.PaymentMethod,
                PaidAmount = request.PaidAmount,
                Notes = request.Notes,
                UserId = userId ?? string.Empty,
                CreatedByUserId = userId
            };

            decimal totalAmount = 0;
            var responseItems = new List<SalesInvoiceItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var batches = await _dbContext.ProductBatches
                    .Include(b => b.Product)
                    .Where(b => b.ProductId == itemReq.ProductId && b.AvailableQuantity > 0 && !b.IsDeleted)
                    .OrderBy(b => b.CreatedAt)
                    .ToListAsync(ct);

                int remainingQty = itemReq.Quantity;

                foreach (var batch in batches)
                {
                    if (remainingQty <= 0) break;

                    if (itemReq.SellingPrice != batch.RetailPrice && itemReq.SellingPrice != batch.WholesalePrice)
                    {
                        await transaction.RollbackAsync(ct);
                        return Result.Failure<SalesInvoiceResponse>(new Error("SalesInvoice.InvalidPrice", $"السعر {itemReq.SellingPrice} غير مطابق لسعر الجملة أو التجزئة للدفعة المستخدمة من المنتج {batch.Product?.Name}.", 400));
                    }

                    var toDeduct = Math.Min(remainingQty, batch.AvailableQuantity);
                    var lineTotal = toDeduct * itemReq.SellingPrice;
                    totalAmount += lineTotal;

                    batch.AvailableQuantity -= toDeduct;
                    batch.UpdatedAt = DateTime.UtcNow;

                    batch.Product.Quantity -= toDeduct;
                    batch.Product.UpdatedAt = DateTime.UtcNow;

                    var invoiceItem = new InvoiceItem
                    {
                        InvoiceId = invoice.Id,
                        ProductId = itemReq.ProductId,
                        BatchId = batch.Id,
                        Quantity = toDeduct,
                        UnitPrice = itemReq.SellingPrice,
                        UnitCost = batch.PurchasePrice,
                        CreatedByUserId = userId
                    };

                    invoice.Items.Add(invoiceItem);

                    responseItems.Add(new SalesInvoiceItemResponse(
                        invoiceItem.Id, invoiceItem.ProductId, batch.Product.Name ?? "Unknown", invoiceItem.BatchId,
                        invoiceItem.Quantity, 0, invoiceItem.UnitPrice, invoiceItem.UnitCost, lineTotal));

                    remainingQty -= toDeduct;
                }

                if (remainingQty > 0)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InsufficientQuantity);
                }
            }

            invoice.TotalAmount = totalAmount;

            if (invoice.PaidAmount > invoice.TotalAmount)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<SalesInvoiceResponse>(new Error("SalesInvoice.InvalidPayment", "Paid amount cannot exceed total amount.", 400));
            }

            if (finalCustomerId is null && invoice.PaidAmount < invoice.TotalAmount)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InvalidPayment);
            }

            if (customer is not null && invoice.PaidAmount < invoice.TotalAmount)
            {
                customer.DebtBalance += invoice.RemainingAmount;
                customer.UpdatedAt = DateTime.UtcNow;
                customer.UpdatedByUserId = userId;
            }

            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync(ct);

            if (request.PaidAmount > 0)
            {
                decimal totalProfit = invoice.Items.Sum(i => (i.UnitPrice - i.UnitCost) * i.Quantity);
                // If deferred and partially paid, calculate proportional profit for this payment
                decimal recordedProfit = request.PaidAmount >= totalAmount ? totalProfit : Math.Round(totalProfit * (request.PaidAmount / totalAmount), 2);
                invoice.RecordedProfit = recordedProfit;
                
                var routeResult = await _transactionRouter.RouteTransactionAsync(
                    GlobalTransactionCategory.CashSale, request.PaidAmount, recordedProfit, request.PaymentSource,
                    $"Sales Invoice {invoice.Id}", invoice.Id, userId ?? "", ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SalesInvoiceResponse>(routeResult.Error);
                }

                if (routeResult.Value.Source == PaymentSource.Drawer)
                {
                    invoice.DrawerTransactionId = routeResult.Value.Id;
                    await _dbContext.SaveChangesAsync(ct);
                }
            }

            await transaction.CommitAsync(ct);

            var customerSummary = customer is not null ? new CustomerSummary(customer.Id, customer.Name, customer.Phone) : null;

            var response = new SalesInvoiceResponse(
                invoice.Id, invoice.InvoiceNumber, customerSummary, (SaleTypeDto)invoice.SaleType,
                (PaymentMethodDto)invoice.PaymentMethod, invoice.TotalAmount, invoice.PaidAmount,
                invoice.RemainingAmount, invoice.Notes, invoice.CreatedAt, false, responseItems);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating sales invoice");
            return Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Invoice By Id or InvoiceNumber
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SalesInvoiceResponse>> GetInvoiceAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Invoices
            .Where(i => i.Id == id || i.InvoiceNumber == id)
            .ProjectToResponse(_dbContext)
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SalesInvoiceResponse>(SalesInvoiceErrors.InvoiceNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Invoices
    // ─────────────────────────────────────────────────────────────────
    // NOTE - bug fix: the previous version bypassed ApplyFilters/ToPaginatedListAsync
    // and hand-rolled Skip/Take, then constructed PaginatedList with its constructor
    // arguments in the wrong order (totalCount/pageNumber/pageSize were shuffled),
    // which silently corrupted TotalPages/HasNextPage for every response.

    public async Task<Result<PaginatedList<SalesInvoiceResponse>>> GetAllInvoicesAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Invoices
                .Where(i => !i.IsDeleted)
                .Where(i => filters.CustomerId == null || i.CustomerId == filters.CustomerId)
                .Where(i => filters.StartDate == null || i.CreatedAt >= filters.StartDate)
                .Where(i => filters.EndDate == null || i.CreatedAt <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => x.InvoiceNumber.Contains(filters.SearchValue!) ||
                                          (x.Customer != null && x.Customer.Name!.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedInvoiceSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(i => i.CreatedAt);

            var mappedQuery = query.ProjectToSummaryResponse();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for sales invoices");
            return Result.Failure<PaginatedList<SalesInvoiceResponse>>(SalesInvoiceErrors.InvalidSortColumn);
        }
    }
}
```

## File: Services/Implementation/SalesReturnService.cs
```csharp
using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SalesReturnService(
    ApplicationDbContext dbContext,
    IReturnProcessingService returnProcessor,
    ILogger<SalesReturnService> logger) : ISalesReturnService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IReturnProcessingService _returnProcessor = returnProcessor;
    private readonly ILogger<SalesReturnService> _logger = logger;

    private static readonly string[] AllowedReturnSortColumns = ["ReturnDate", "TotalReturnedAmount"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Return
    // ─────────────────────────────────────────────────────────────────
    // The actual workflow (validate invoice/items, restock batches, record
    // the return, route refund or adjust debt) lives in ReturnProcessingService
    // so it isn't duplicated between here and CustomerTransactionService.

    public Task<Result<ReturnRecordResponse>> AddReturnAsync(
        CreateCustomerReturnRequest request, string? userId, CancellationToken ct = default) =>
        _returnProcessor.ProcessReturnAsync(request, userId, expectedCustomerId: null, ct);

    // ─────────────────────────────────────────────────────────────────
    //  Get Return By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<ReturnRecordResponse>> GetReturnAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Returns
            .Where(r => r.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<ReturnRecordResponse>(SalesReturnErrors.ReturnNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Returns
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<ReturnRecordResponse>>> GetAllReturnsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Returns
                .Where(r => !r.IsDeleted)
                .Where(r => filters.StartDate == null || r.ReturnDate >= filters.StartDate)
                .Where(r => filters.EndDate == null || r.ReturnDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Invoice != null && x.Invoice.InvoiceNumber.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedReturnSortColumns);

            if (string.IsNullOrWhiteSpace(filters.SortColumn))
                query = query.OrderByDescending(r => r.ReturnDate);

            var mappedQuery = query.ProjectToSummaryResponse();

            var result = await mappedQuery.ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for sales returns");
            return Result.Failure<PaginatedList<ReturnRecordResponse>>(SalesReturnErrors.InvalidSortColumn);
        }
    }
}
```

## File: Services/Implementation/SupplierService.cs
```csharp
using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SupplierService(ApplicationDbContext dbContext, ILogger<SupplierService> logger) : ISupplierService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<SupplierService> _logger = logger;

    private static readonly string[] AllowedSupplierSortColumns = ["Name", "DebtBalance", "CreatedAt"];

    // ─────────────────────────────────────────────────────────────────
    //  Add Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SupplierResponse>> AddSupplierAsync(
        CreateSupplierRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var supplier = new Supplier
            {
                Name = request.Name,
                Type = request.Type,
                Phone = request.Phone,
                Address = request.Address,
                CreatedByUserId = userId
            };

            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync(ct);

            var response = new SupplierResponse(
                supplier.Id, supplier.Name, supplier.Type, supplier.Phone, supplier.Address,
                supplier.DebtBalance, 0, 0, supplier.CreatedAt);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating supplier for user {UserId}", userId);
            return Result.Failure<SupplierResponse>(SupplierErrors.CreationFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get Supplier By Id
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SupplierResponse>> GetSupplierAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.Suppliers
            .Where(s => s.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SupplierResponse>(SupplierErrors.SupplierNotFound)
            : Result.Success(response);
    }

    // ─────────────────────────────────────────────────────────────────
    //  Get All Suppliers
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<PaginatedList<SupplierResponse>>> GetAllSuppliersAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.Suppliers
                .Where(s => !s.IsDeleted)
                .ApplyFilters(filters,
                    searchPredicate: x => (x.Name != null && x.Name.Contains(filters.SearchValue!)) ||
                                          (x.Phone != null && x.Phone.Contains(filters.SearchValue!)),
                    allowedSortColumns: AllowedSupplierSortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for suppliers");
            return Result.Failure<PaginatedList<SupplierResponse>>(SupplierErrors.InvalidSortColumn);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Update Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<SupplierResponse>> UpdateSupplierAsync(
        string id, UpdateSupplierRequest request, string? userId, CancellationToken ct = default)
    {
        try
        {
            var updated = await _dbContext.Suppliers
                .Where(s => s.Id == id && !s.IsDeleted)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(s => s.Name, request.Name)
                    .SetProperty(s => s.Type, request.Type)
                    .SetProperty(s => s.Phone, request.Phone)
                    .SetProperty(s => s.Address, request.Address)
                    .SetProperty(s => s.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(s => s.UpdatedByUserId, userId), ct);

            if (updated == 0)
                return Result.Failure<SupplierResponse>(SupplierErrors.SupplierNotFound);

            var response = await _dbContext.Suppliers
                .Where(s => s.Id == id)
                .ProjectToResponse()
                .FirstAsync(ct);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating supplier {SupplierId}", id);
            return Result.Failure<SupplierResponse>(SupplierErrors.UpdateFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Soft Delete Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<bool>> DeleteSupplierAsync(string id, CancellationToken ct = default)
    {
        try
        {
            var deleted = await _dbContext.Suppliers
                .Where(s => s.Id == id && !s.IsDeleted && s.DebtBalance == 0)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(s => s.IsDeleted, true)
                    .SetProperty(s => s.DeletedAt, DateTime.UtcNow), ct);

            if (deleted > 0)
                return Result.Success(true);

            var exists = await _dbContext.Suppliers.AnyAsync(s => s.Id == id && !s.IsDeleted, ct);
            return Result.Failure<bool>(exists ? SupplierErrors.HasOutstandingDebt : SupplierErrors.SupplierNotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting supplier {SupplierId}", id);
            return Result.Failure<bool>(SupplierErrors.DeleteFailed);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Supplier Statement (already reasonably lean - kept structurally
    //  the same: only an existence check, then flat per-source projections)
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<List<SupplierStatementItemResponse>>> GetSupplierStatementAsync(
        string id, RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var supplierExists = await _dbContext.Suppliers.AnyAsync(s => s.Id == id && !s.IsDeleted, ct);
            if (!supplierExists)
                return Result.Failure<List<SupplierStatementItemResponse>>(SupplierErrors.SupplierNotFound);

            var rawInvoices = await _dbContext.PurchaseInvoices
                .AsNoTracking()
                .Where(i => i.SupplierId == id && !i.IsDeleted)
                .Select(i => new { i.InvoiceDate, i.Id, i.TotalAmount, i.PaidAmount, i.Notes })
                .ToListAsync(ct);

            var invoices = rawInvoices
                .Select(i => new { Date = i.InvoiceDate, Type = "PurchaseInvoice", i.Id, Debit = 0m, Credit = i.TotalAmount, i.Notes })
                .ToList();

            var invoicePayments = rawInvoices
                .Where(i => i.PaidAmount > 0)
                .Select(i => new { Date = i.InvoiceDate, Type = "InvoicePayment", i.Id, Debit = i.PaidAmount, Credit = 0m, Notes = "سداد نقدي للفاتورة" })
                .ToList();

            var payments = await _dbContext.SupplierPayments
                .AsNoTracking()
                .Where(p => p.SupplierId == id && !p.IsDeleted)
                .Select(p => new
                {
                    Date = p.PaymentDate,
                    Type = p.Amount >= 0 ? "Payment" : "Receipt",
                    p.Id,
                    Debit = p.Amount >= 0 ? p.Amount : 0m,
                    Credit = p.Amount < 0 ? Math.Abs(p.Amount) : 0m,
                    Notes = (string?)p.Notes
                })
                .ToListAsync(ct);

            var returns = await _dbContext.SupplierReturns
                .AsNoTracking()
                .Where(r => r.SupplierId == id && !r.IsDeleted)
                .Select(r => new { Date = r.ReturnDate, Type = "Return", r.Id, Debit = r.TotalReturnedAmount, Credit = 0m, Notes = (string?)r.Notes })
                .ToListAsync(ct);

            var allTransactions = invoices.Concat(invoicePayments).Concat(payments).Concat(returns).AsEnumerable();

            if (filters.StartDate.HasValue)
                allTransactions = allTransactions.Where(t => t.Date >= filters.StartDate.Value);

            if (filters.EndDate.HasValue)
                allTransactions = allTransactions.Where(t => t.Date <= filters.EndDate.Value);

            var runningBalance = 0m;
            var result = new List<SupplierStatementItemResponse>();

            foreach (var t in allTransactions.OrderBy(t => t.Date))
            {
                runningBalance += t.Credit - t.Debit;
                result.Add(new SupplierStatementItemResponse(t.Date, t.Type, t.Id, t.Debit, t.Credit, runningBalance, t.Notes));
            }

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting statement for supplier {SupplierId}", id);
            return Result.Failure<List<SupplierStatementItemResponse>>(SupplierErrors.SupplierNotFound);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    //  Available Batches for a Supplier
    // ─────────────────────────────────────────────────────────────────

    public async Task<Result<IReadOnlyList<SupplierBatchResponse>>> GetSupplierAvailableBatchesAsync(
        string supplierId, CancellationToken ct = default)
    {
        var supplierExists = await _dbContext.Suppliers.AnyAsync(s => s.Id == supplierId && !s.IsDeleted, ct);
        if (!supplierExists)
            return Result.Failure<IReadOnlyList<SupplierBatchResponse>>(SupplierErrors.SupplierNotFound);

        var batches = await _dbContext.ProductBatches
            .Where(b => b.SupplierId == supplierId)
            .ProjectToResponse()
            .ToListAsync(ct);

        return Result.Success<IReadOnlyList<SupplierBatchResponse>>(batches);
    }


}
```

## File: Services/Implementation/SupplierTransactionService.cs
```csharp
using Centraly.Api.Mappings;

namespace Centraly.Api.Services.Implementation;

public class SupplierTransactionService(
    ApplicationDbContext dbContext,
    ILogger<SupplierTransactionService> logger,
    ITransactionRouterService transactionRouter) : ISupplierTransactionService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ILogger<SupplierTransactionService> _logger = logger;
    private readonly ITransactionRouterService _transactionRouter = transactionRouter;

    private static readonly string[] AllowedPaymentSortColumns = ["PaymentDate", "Amount"];
    private static readonly string[] AllowedReturnSortColumns = ["ReturnDate", "TotalReturnedAmount"];

    // ══════════════════════════════════════════════════════════════
    //  PAYMENTS
    // ══════════════════════════════════════════════════════════════

    public async Task<Result<SupplierPaymentResponse>> AddPaymentAsync(
        CreateSupplierPaymentRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var supplier = await _dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.SupplierId && !s.IsDeleted, ct);

            if (supplier is null)
                return Result.Failure<SupplierPaymentResponse>(SupplierTransactionErrors.SupplierNotFound);

            var payment = new SupplierPayment
            {
                SupplierId = supplier.Id,
                Amount = request.Amount,
                Notes = request.Notes,
                CreatedByUserId = userId
            };

            // Reduce the supplier's debt by the payment amount
            supplier.DebtBalance -= request.Amount;
            supplier.UpdatedAt = DateTime.UtcNow;
            supplier.UpdatedByUserId = userId;

            var category = request.Amount >= 0 ? GlobalTransactionCategory.SupplierPayment : GlobalTransactionCategory.SupplierReceipt;
            var routeResult = await _transactionRouter.RouteTransactionAsync(category, Math.Abs(request.Amount), 0, request.PaymentSource, request.Notes, null, userId ?? "", ct);

            if (routeResult.IsFailure)
            {
                await transaction.RollbackAsync(ct);
                return Result.Failure<SupplierPaymentResponse>(routeResult.Error);
            }

            _dbContext.SupplierPayments.Add(payment);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            var response = new SupplierPaymentResponse(
                payment.Id,
                new SupplierSummary(supplier.Id, supplier.Name, supplier.Phone),
                payment.Amount,
                payment.PaymentDate,
                payment.Notes);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating supplier payment");
            return Result.Failure<SupplierPaymentResponse>(SupplierTransactionErrors.PaymentCreationFailed);
        }
    }

    public async Task<Result<SupplierPaymentResponse>> GetPaymentAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.SupplierPayments
            .Where(p => p.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SupplierPaymentResponse>(SupplierTransactionErrors.PaymentNotFound)
            : Result.Success(response);
    }

    public async Task<Result<PaginatedList<SupplierPaymentResponse>>> GetAllPaymentsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.SupplierPayments
                .Where(p => !p.IsDeleted)
                .Where(p => filters.SupplierId == null || p.SupplierId == filters.SupplierId)
                .Where(p => filters.StartDate == null || p.PaymentDate >= filters.StartDate)
                .Where(p => filters.EndDate == null || p.PaymentDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Supplier!.Name.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedPaymentSortColumns);

            var result = await query.ProjectToResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for supplier payments");
            return Result.Failure<PaginatedList<SupplierPaymentResponse>>(SupplierTransactionErrors.InvalidSortColumn);
        }
    }

    // ══════════════════════════════════════════════════════════════
    //  RETURNS
    // ══════════════════════════════════════════════════════════════

    public async Task<Result<SupplierReturnResponse>> AddReturnAsync(
        CreateSupplierReturnRequest request, string? userId, CancellationToken ct = default)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);
        try
        {
            var supplier = await _dbContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.SupplierId && !s.IsDeleted, ct);

            if (supplier is null)
                return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.SupplierNotFound);

            var productIds = request.Items.Select(i => i.ProductId).ToList();

            var products = await _dbContext.Products
                .Where(p => productIds.Contains(p.Id) && !p.IsDeleted)
                .ToDictionaryAsync(p => p.Id, ct);

            if (products.Count != request.Items.Count)
                return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.ProductNotFound);

            var supplierReturn = new SupplierReturn
            {
                SupplierId = supplier.Id,
                Reason = (ReturnReason)request.Reason,
                Notes = request.Notes,
                ReturnDate = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            decimal totalReturnedAmount = 0;
            var responseItems = new List<SupplierReturnItemResponse>();

            foreach (var itemReq in request.Items)
            {
                var product = products[itemReq.ProductId];

                var batch = await _dbContext.ProductBatches
                    .FirstOrDefaultAsync(b => b.Id == itemReq.BatchId && b.ProductId == product.Id && !b.IsDeleted, ct);

                if (batch is null)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.BatchNotFound);
                }

                // Ensure we don't return more than what is currently in this specific batch
                if (itemReq.Quantity > batch.AvailableQuantity)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.InsufficientQuantity);
                }

                var unitCost = batch.PurchasePrice;
                if (itemReq.ReturnPrice != batch.PurchasePrice)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(new Error("SupplierReturn.InvalidPrice", $"Return price must match the original purchase price ({batch.PurchasePrice}) for this batch.", 400));
                }
                var lineTotal = itemReq.Quantity * unitCost;
                totalReturnedAmount += lineTotal;

                // Decrease stock from batch and total product
                batch.AvailableQuantity -= itemReq.Quantity;
                batch.UpdatedAt = DateTime.UtcNow;

                product.Quantity -= itemReq.Quantity;
                product.UpdatedAt = DateTime.UtcNow;

                var returnItem = new SupplierReturnItem
                {
                    SupplierReturnId = supplierReturn.Id,
                    ProductId = product.Id,
                    Quantity = itemReq.Quantity,
                    UnitCost = unitCost,
                    CreatedByUserId = userId
                };

                supplierReturn.Items.Add(returnItem);

                responseItems.Add(new SupplierReturnItemResponse(
                    returnItem.Id,
                    new ProductSummary(product.Id, product.Name, product.Barcode, product.ImageUrl, 0, 0, product.Quantity),
                    returnItem.Quantity,
                    returnItem.UnitCost,
                    lineTotal));
            }

            supplierReturn.TotalReturnedAmount = totalReturnedAmount;

            // Returning items means the supplier owes us, which decreases our debt to them
            if (request.IsCashRefund)
            {
                var routeResult = await _transactionRouter.RouteTransactionAsync(GlobalTransactionCategory.PurchaseReturn, totalReturnedAmount, 0, request.PaymentSource,
                    request.Notes, supplierReturn.Id, userId ?? "", ct);

                if (routeResult.IsFailure)
                {
                    await transaction.RollbackAsync(ct);
                    return Result.Failure<SupplierReturnResponse>(routeResult.Error);
                }
            }
            else
            {
                supplier.DebtBalance -= totalReturnedAmount;
            }

            supplier.UpdatedAt = DateTime.UtcNow;
            supplier.UpdatedByUserId = userId;

            _dbContext.SupplierReturns.Add(supplierReturn);
            await _dbContext.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            var response = new SupplierReturnResponse(
                supplierReturn.Id,
                new SupplierSummary(supplier.Id, supplier.Name, supplier.Phone),
                (ReturnReasonDto)supplierReturn.Reason,
                supplierReturn.Notes,
                supplierReturn.TotalReturnedAmount,
                supplierReturn.ReturnDate,
                responseItems);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(ct);
            _logger.LogError(ex, "Error creating supplier return");
            return Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.ReturnCreationFailed);
        }
    }

    public async Task<Result<SupplierReturnResponse>> GetReturnAsync(string id, CancellationToken ct = default)
    {
        var response = await _dbContext.SupplierReturns
            .Where(r => r.Id == id)
            .ProjectToResponse()
            .FirstOrDefaultAsync(ct);

        return response is null
            ? Result.Failure<SupplierReturnResponse>(SupplierTransactionErrors.ReturnNotFound)
            : Result.Success(response);
    }

    public async Task<Result<PaginatedList<SupplierReturnResponse>>> GetAllReturnsAsync(
        RequestFilters filters, CancellationToken ct = default)
    {
        try
        {
            var query = _dbContext.SupplierReturns
                .Where(r => !r.IsDeleted)
                .Where(r => filters.SupplierId == null || r.SupplierId == filters.SupplierId)
                .Where(r => filters.StartDate == null || r.ReturnDate >= filters.StartDate)
                .Where(r => filters.EndDate == null || r.ReturnDate <= filters.EndDate)
                .ApplyFilters(filters,
                    searchPredicate: x => x.Supplier!.Name.Contains(filters.SearchValue!),
                    allowedSortColumns: AllowedReturnSortColumns);

            var result = await query.ProjectToSummaryResponse().ToPaginatedListAsync(filters, ct);
            return Result.Success(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid sort column requested for supplier returns");
            return Result.Failure<PaginatedList<SupplierReturnResponse>>(SupplierTransactionErrors.InvalidSortColumn);
        }
    }

    // ══════════════════════════════════════════════════════════════
}
```

## File: Services/Implementation/TransactionRouterService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public class TransactionRouterService(
    IFinancePolicyService policyService,
    IDrawerService drawerService,
    ISafeService safeService) : ITransactionRouterService
{
    private readonly IFinancePolicyService _policyService = policyService;
    private readonly IDrawerService _drawerService = drawerService;
    private readonly ISafeService _safeService = safeService;

    public async Task<Result<(string Id, PaymentSource Source)>> RouteTransactionAsync(
        GlobalTransactionCategory category, decimal amount, decimal profit, PaymentSource? requestedSource,
        string? notes, string? referenceId, string userId, CancellationToken ct = default)
    {
        var policyResult = await _policyService.GetPolicyForCategoryAsync(category, ct);
        if (policyResult.IsFailure)
            return Result.Failure<(string Id, PaymentSource Source)>(policyResult.Error);

        var policy = policyResult.Value;
        PaymentSource effectiveSource;

        switch (policy)
        {
            case PaymentSourcePolicy.DrawerOnly:
                if (requestedSource == PaymentSource.Safe)
                    return Result.Failure<(string Id, PaymentSource Source)>(TransactionRouterErrors.PolicyViolation);
                effectiveSource = PaymentSource.Drawer;
                break;

            case PaymentSourcePolicy.SafeOnly:
                if (requestedSource == PaymentSource.Drawer)
                    return Result.Failure<(string Id, PaymentSource Source)>(TransactionRouterErrors.PolicyViolation);
                effectiveSource = PaymentSource.Safe;
                break;

            default: // Either
                if (requestedSource is null)
                    return Result.Failure<(string Id, PaymentSource Source)>(TransactionRouterErrors.PolicyViolation);
                effectiveSource = requestedSource.Value;
                break;
        }

        var drawerType = MapToTransactionType(category);

        if (effectiveSource == PaymentSource.Drawer)
        {
            var drawerCategory = MapToDrawerCategory(category);
            var result = await _drawerService.RecordTransactionAsync(drawerCategory, drawerType, amount, profit, notes, referenceId, userId, ct);
            return result.IsSuccess ? Result.Success((result.Value.Id, PaymentSource.Drawer)) : Result.Failure<(string Id, PaymentSource Source)>(result.Error);
        }

        var safeCategory = MapToSafeCategory(category);
        var mainSafeResult = await _safeService.GetMainSafeAsync(ct);
        if (mainSafeResult.IsFailure)
            return Result.Failure<(string Id, PaymentSource Source)>(mainSafeResult.Error);

        var safeResult = await _safeService.AddManualTransactionAsync(mainSafeResult.Value.Id, drawerType, safeCategory, amount, profit, notes, userId, ct);
        return safeResult.IsSuccess ? Result.Success((safeResult.Value.Id, PaymentSource.Safe)) : Result.Failure<(string Id, PaymentSource Source)>(safeResult.Error);
    }

    private static DrawerTransactionCategory MapToDrawerCategory(GlobalTransactionCategory cat) => cat switch
    {
        GlobalTransactionCategory.CashSale => DrawerTransactionCategory.Sales,
        GlobalTransactionCategory.SalesReturn => DrawerTransactionCategory.Returns,
        GlobalTransactionCategory.CashPurchase => DrawerTransactionCategory.Purchases,
        GlobalTransactionCategory.PurchaseReturn => DrawerTransactionCategory.SupplierReturn,
        GlobalTransactionCategory.SupplierPayment => DrawerTransactionCategory.Suppliers,
        GlobalTransactionCategory.SupplierReceipt => DrawerTransactionCategory.Suppliers,
        GlobalTransactionCategory.CustomerPayment => DrawerTransactionCategory.CustomerDebt,
        GlobalTransactionCategory.CustomerRefund => DrawerTransactionCategory.Returns,
        GlobalTransactionCategory.Expense => DrawerTransactionCategory.Expense,
        GlobalTransactionCategory.ManualExpense => DrawerTransactionCategory.Expense,
        _ => DrawerTransactionCategory.Operational
    };

    private static SafeTransactionCategory MapToSafeCategory(GlobalTransactionCategory cat) => cat switch
    {
        GlobalTransactionCategory.Expense => SafeTransactionCategory.ExpensePayment,
        GlobalTransactionCategory.OwnerDeposit => SafeTransactionCategory.OwnerDeposit,
        GlobalTransactionCategory.OwnerWithdrawal => SafeTransactionCategory.OwnerWithdrawal,
        GlobalTransactionCategory.ManualIncome => SafeTransactionCategory.ManualDeposit,
        GlobalTransactionCategory.ManualExpense => SafeTransactionCategory.ManualWithdrawal,
        GlobalTransactionCategory.CashSale => SafeTransactionCategory.Sales,
        GlobalTransactionCategory.SalesReturn => SafeTransactionCategory.Returns,
        GlobalTransactionCategory.CashPurchase => SafeTransactionCategory.Purchases,
        GlobalTransactionCategory.PurchaseReturn => SafeTransactionCategory.SupplierReturn,
        GlobalTransactionCategory.SupplierPayment => SafeTransactionCategory.SupplierPayment,
        GlobalTransactionCategory.CustomerPayment => SafeTransactionCategory.CustomerPayment,
        _ => SafeTransactionCategory.General
    };

    private static DrawerTransactionType MapToTransactionType(GlobalTransactionCategory cat) => cat switch
    {
        GlobalTransactionCategory.CashSale => DrawerTransactionType.Income,
        GlobalTransactionCategory.CustomerPayment => DrawerTransactionType.Income,
        GlobalTransactionCategory.SupplierReceipt => DrawerTransactionType.Income,
        GlobalTransactionCategory.PurchaseReturn => DrawerTransactionType.Income,
        GlobalTransactionCategory.OwnerDeposit => DrawerTransactionType.Income,
        GlobalTransactionCategory.ManualIncome => DrawerTransactionType.Income,
        _ => DrawerTransactionType.Expense
    };
}
```

## File: Services/Implementation/UserService.cs
```csharp
using Centraly.Api.Contracts.Users;

namespace Centraly.Api.Services;

public class UserService(UserManager<ApplicationUser> userManager,
    IRoleService roleService,
    ApplicationDbContext context) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IRoleService _roleService = roleService;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await (from u in _context.Users
               join ur in _context.UserRoles
               on u.Id equals ur.UserId
               join r in _context.Roles
               on ur.RoleId equals r.Id into roles
               where !roles.Any(x => x.Name == "")
               select new
               {
                   u.Id,
                   u.UserName,
                   Roles = roles.Select(x => x.Name!).ToList()
               }
                )
                .GroupBy(u => new { u.Id, u.UserName })
                .Select(u => new UserResponse
                (
                    u.Key.Id,
                    u.Key.UserName!,
                    u.SelectMany(x => x.Roles)
                ))
               .ToListAsync(cancellationToken);

    public async Task<Result<UserResponse>> GetAsync(string id)
    {
        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure<UserResponse>(UserErrors.UserNotFound);

        var userRoles = await _userManager.GetRolesAsync(user);

        var response = new UserResponse(user.Id, user.UserName!, userRoles);

        return Result.Success(response);
    }

    public async Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var usernameIsExists = await _userManager.Users.AnyAsync(x => x.UserName == request.Username, cancellationToken);

        if (usernameIsExists)
            return Result.Failure<UserResponse>(UserErrors.DuplicateEmail);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any())
            return Result.Failure<UserResponse>(new Error("User.InvalidRoles", "One or more roles are invalid", StatusCodes.Status400BadRequest));

        var user = new ApplicationUser
        {
            UserName = request.Username,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, request.Roles);

            var response = new UserResponse(user.Id, user.UserName!, request.Roles);

            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success(response);
        }

        var error = result.Errors.First();

        return Result.Failure<UserResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        var usernameIsExists = await _userManager.Users.AnyAsync(x => x.UserName == request.Username && x.Id != id, cancellationToken);

        if (usernameIsExists)
            return Result.Failure(UserErrors.DuplicateEmail);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any())
            return Result.Failure(new Error("User.InvalidRoles", "One or more roles are invalid", StatusCodes.Status400BadRequest));

        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure(UserErrors.UserNotFound);

        user.UserName = request.Username;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            await _context.UserRoles
                .Where(x => x.UserId == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _userManager.AddToRolesAsync(user, request.Roles);

            return Result.Success();
        }

        var error = result.Errors.First();

        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
}
```

## File: Services/Implementation/WalletService.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public partial class WalletService(
    ApplicationDbContext dbContext,
    IDrawerService drawerService,
    IWebHostEnvironment _env,
    IHttpContextAccessor _accessor) : IWalletService
{
    public async Task<Result<WalletResponse>> CreateWalletAsync(CreateWalletRequest request, string userId, CancellationToken ct = default)
    {
        var wallet = new Wallet
        {
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            OwnerName = request.OwnerName,
            Balance = request.InitialBalance,
            IsActive = true,
            CreatedByUserId = userId
        };

        // نفس المنطق: تحقق من الصورة الأول، وارفعها بعدين
        if (request.Image is not null)
            wallet.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/wallets", _env, _accessor);

        dbContext.Wallets.Add(wallet);

        if (request.InitialBalance > 0)
        {
            var transaction = new WalletTransaction
            {
                Wallet = wallet,
                Type = WalletTransactionType.Income,
                Amount = request.InitialBalance,
                BalanceAfter = request.InitialBalance,
                Notes = "Initial Balance",
                CreatedByUserId = userId
            };
            dbContext.WalletTransactions.Add(transaction);
        }

        await dbContext.SaveChangesAsync(ct);

        return Result.Success(new WalletResponse(
            wallet.Id,
            wallet.Name,
            wallet.PhoneNumber,
            wallet.OwnerName,
            wallet.Balance,
            wallet.ImageUrl,
            wallet.IsActive,
            wallet.CreatedAt));
    }

    public async Task<Result<WalletOperationResponse>> ProcessOperationAsync(ProcessOperationRequest request, string userId, CancellationToken ct = default)
    {
        var ownsTransaction = dbContext.Database.CurrentTransaction == null;
        var transaction = ownsTransaction ? await dbContext.Database.BeginTransactionAsync(ct) : null;
        try
        {
            var wallet = await dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == request.WalletId, ct);
            if (wallet == null)
                return Result.Failure<WalletOperationResponse>(new Error("Wallet.NotFound", "Wallet not found", 404));

            if (!wallet.IsActive)
                return Result.Failure<WalletOperationResponse>(new Error("Wallet.Inactive", "Wallet is not active", 400));

            decimal profit = 0;
            WalletTransactionType walletTxType;
            DrawerTransactionType drawerTxType;

            if (request.OperationType == WalletOperationType.CashOut)
            {
                // CashOut (Ø³Ø­Ø¨ Ù…Ù† Ø¹Ù…ÙŠÙ„): Wallet Income, Drawer Expense
                walletTxType = WalletTransactionType.Income;
                drawerTxType = DrawerTransactionType.Expense;
                profit = request.TransferredAmount - request.PhysicalCashAmount;

                wallet.Balance += request.TransferredAmount;
            }
            else if (request.OperationType == WalletOperationType.CashIn)
            {
                // CashIn (Ø¥ÙŠØ¯Ø§Ø¹ Ù„Ø¹Ù…ÙŠÙ„): Wallet Expense, Drawer Income
                if (wallet.Balance < request.TransferredAmount)
                    return Result.Failure<WalletOperationResponse>(new Error("Wallet.InsufficientBalance", "Insufficient balance in wallet", 400));

                walletTxType = WalletTransactionType.Expense;
                drawerTxType = DrawerTransactionType.Income;
                profit = request.PhysicalCashAmount - request.TransferredAmount;

                wallet.Balance -= request.TransferredAmount;
            }
            else
            {
                return Result.Failure<WalletOperationResponse>(new Error("Wallet.InvalidOperation", "Invalid operation type", 400));
            }

            // 1. Drawer Transaction
            var drawerResult = await drawerService.RecordTransactionAsync(
                (DrawerTransactionCategory)10, // WalletOperation
                drawerTxType,
                request.PhysicalCashAmount,
                profit,
                request.Notes ?? $"Wallet operation: {request.OperationType}",
                $"Wallet:{wallet.Name}",
                userId,
                ct);
            if (!drawerResult.IsSuccess)
                return Result.Failure<WalletOperationResponse>(drawerResult.Error);

            var drawerTxId = drawerResult.Value.Id;

            // 2. Wallet Transaction
            var walletTx = new WalletTransaction
            {
                WalletId = wallet.Id,
                Type = walletTxType,
                Amount = request.TransferredAmount,
                BalanceAfter = wallet.Balance,
                Notes = request.Notes,
                CreatedByUserId = userId
            };
            dbContext.WalletTransactions.Add(walletTx);

            // 3. Wallet Operation
            var operation = new WalletOperation
            {
                WalletId = wallet.Id,
                OperationType = request.OperationType,
                TransferredAmount = request.TransferredAmount,
                PhysicalCashAmount = request.PhysicalCashAmount,
                Profit = profit,
                DrawerTransactionId = drawerTxId,
                CreatedByUserId = userId
            };
            dbContext.WalletOperations.Add(operation);

            await dbContext.SaveChangesAsync(ct);
            if (ownsTransaction) await transaction.CommitAsync(ct);

            return Result.Success(new WalletOperationResponse(
                operation.Id,
                wallet.Id,
                operation.OperationType,
                operation.TransferredAmount,
                operation.PhysicalCashAmount,
                operation.Profit,
                operation.DrawerTransactionId,
                operation.CreatedAt));
        }
        catch
        {
            if (ownsTransaction) await transaction.RollbackAsync(ct);
            throw;
        }
        finally
        {
            if (ownsTransaction) await transaction.DisposeAsync();
        }
    }
}
```

## File: Services/Implementation/WalletService.Part2.cs
```csharp
namespace Centraly.Api.Services.Implementation;

public partial class WalletService
{
    public async Task<Result<WalletResponse>> UpdateWalletAsync(string walletId, UpdateWalletRequest request, string userId, CancellationToken ct = default)
    {
        var wallet = await dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == walletId, ct);
        if (wallet == null)
            return Result.Failure<WalletResponse>(new Error("Wallet.NotFound", "Wallet not found", 404));
        if (request.Image is not null)
        {
            if (!string.IsNullOrEmpty(wallet.ImageUrl))
            {
                FileHelper.DeleteFile(wallet.ImageUrl, "uploads/wallets", _env);
            }
            wallet.ImageUrl = await FileHelper.UploadeFileAsync(request.Image, "uploads/wallets", _env, _accessor);
        }
        wallet.Name = request.Name;
        wallet.PhoneNumber = request.PhoneNumber;
        wallet.OwnerName = request.OwnerName;
        wallet.IsActive = request.IsActive;

        await dbContext.SaveChangesAsync(ct);
        return Result.Success(new WalletResponse(wallet.Id, wallet.Name, wallet.PhoneNumber, wallet.OwnerName, wallet.Balance, wallet.ImageUrl, wallet.IsActive, wallet.CreatedAt));
    }

    public async Task<Result<PaginatedList<WalletResponse>>> GetAllWalletsAsync(PaginationFilter filter, CancellationToken ct = default)
    {
        var query = dbContext.Wallets.AsQueryable();
        var total = await query.CountAsync(ct);
        var items = await query.OrderByDescending(w => w.CreatedAt)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(w => new WalletResponse(w.Id, w.Name, w.PhoneNumber, w.OwnerName, w.Balance, w.ImageUrl, w.IsActive, w.CreatedAt))
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<WalletResponse>(items, filter.PageNumber, filter.PageSize, total));
    }

    public async Task<Result<WalletDetailsResponse>> GetWalletByIdAsync(string walletId, CancellationToken ct = default)
    {
        var w = await dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == walletId, ct);
        if (w == null) return Result.Failure<WalletDetailsResponse>(new Error("Wallet.NotFound", "Wallet not found", 404));

        var netProfit = await dbContext.WalletOperations.Where(o => o.WalletId == walletId).SumAsync(o => o.Profit, ct);

        var res = new WalletDetailsResponse(w.Id, w.Name, w.PhoneNumber, w.OwnerName, w.Balance, w.ImageUrl, w.IsActive, w.CreatedAt, netProfit);
        return Result.Success(res);
    }

    public async Task<Result<PaginatedList<WalletOperationResponse>>> GetWalletOperationsAsync(WalletOperationFilter filter, CancellationToken ct = default)
    {
        var query = dbContext.WalletOperations.Where(o => o.WalletId == filter.WalletId);
        var total = await query.CountAsync(ct);
        var items = await query.OrderByDescending(o => o.CreatedAt)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(o => new WalletOperationResponse(o.Id, o.WalletId, o.OperationType, o.TransferredAmount, o.PhysicalCashAmount, o.Profit, o.DrawerTransactionId, o.CreatedAt))
            .ToListAsync(ct);

        return Result.Success(new PaginatedList<WalletOperationResponse>(items, filter.PageNumber, filter.PageSize, total));
    }

    public async Task<Result<WalletOperationsSummaryResponse>> GetWalletOperationsSummaryAsync(WalletOperationFilter filter, CancellationToken ct = default)
    {
        var query = dbContext.WalletOperations.Where(o => o.WalletId == filter.WalletId);
        var totalProfit = await query.SumAsync(o => o.Profit, ct);
        return Result.Success(new WalletOperationsSummaryResponse(totalProfit));
    }
}
```

## File: update_maintenance.csx
```
using System;
using System.IO;
using System.Text.RegularExpressions;

var batchFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Entities\Inventory\ProductBatch.cs";
var batchContent = File.ReadAllText(batchFile);
batchContent = batchContent.Replace("public decimal RetailPrice { get; set; }", "public decimal RetailPrice { get; set; }\n    public decimal MaintenancePrice { get; set; }");
File.WriteAllText(batchFile, batchContent);

var reqFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Contracts\Suppliers\CreatePurchaseInvoiceItemRequest.cs";
var reqContent = File.ReadAllText(reqFile);
reqContent = reqContent.Replace("decimal RetailPrice     // New Batch Retail Price", "decimal RetailPrice,     // New Batch Retail Price\n    decimal? MaintenancePrice // Maintenance Price");
File.WriteAllText(reqFile, reqContent);

var batchResFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Contracts\Inventory\Products\ProductResponse.cs";
var batchResContent = File.ReadAllText(batchResFile);
batchResContent = batchResContent.Replace("decimal RetailPrice,", "decimal RetailPrice,\n    decimal MaintenancePrice,");
File.WriteAllText(batchResFile, batchResContent);

var invoiceSvcFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\PurchaseInvoiceService.cs";
var invoiceSvcContent = File.ReadAllText(invoiceSvcFile);
invoiceSvcContent = invoiceSvcContent.Replace("RetailPrice = itemReq.RetailPrice,", "RetailPrice = itemReq.RetailPrice,\n                    MaintenancePrice = itemReq.MaintenancePrice ?? 0,");
File.WriteAllText(invoiceSvcFile, invoiceSvcContent);

var prodSvcFile = @"C:\Users\AIO\source\repos\Centraly.Api\Centraly.Api\Services\Implementation\ProductService.cs";
var prodSvcContent = File.ReadAllText(prodSvcFile);
prodSvcContent = prodSvcContent.Replace("b.RetailPrice,", "b.RetailPrice,\n                  b.MaintenancePrice,");
prodSvcContent = prodSvcContent.Replace("b.RetailPrice,\n                  b.DateReceived", "b.RetailPrice,\n                  b.MaintenancePrice,\n                  b.DateReceived");
File.WriteAllText(prodSvcFile, prodSvcContent);
```

## File: WeatherForecast.cs
```csharp
namespace Centraly.Api
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
```
