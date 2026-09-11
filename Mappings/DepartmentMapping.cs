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
