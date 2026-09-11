using Centraly.Api.Contracts.Shared.Summaries;

namespace Centraly.Api.Contracts.Inventory.Categories;

public record CategoryResponse(
    string             CategoryId,
    string             Name,
    DepartmentSummary  Department,
    int                ProductsCount,
    DateTime           CreatedAt
);
