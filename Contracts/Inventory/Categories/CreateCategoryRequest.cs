namespace Centraly.Api.Contracts.Inventory.Categories;

public record CreateCategoryRequest(
    string Name,
    string DepartmentId
);
