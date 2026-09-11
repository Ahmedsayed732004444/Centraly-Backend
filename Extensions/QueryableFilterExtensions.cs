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