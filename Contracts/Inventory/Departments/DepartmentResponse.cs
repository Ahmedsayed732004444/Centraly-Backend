namespace Centraly.Api.Contracts.Inventory.Departments;

public record DepartmentResponse(//Get //Add
    string DepartmentId,
    string Name,
    int CategoriesCount,
    int ProductsCount,
    DateTime CreatedAt
);
