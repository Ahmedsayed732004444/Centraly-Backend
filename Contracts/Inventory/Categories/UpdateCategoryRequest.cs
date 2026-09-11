namespace Centraly.Api.Contracts.Inventory.Categories;

public record UpdateCategoryRequest(
    string Name,
    string DepartmentId
);
