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
