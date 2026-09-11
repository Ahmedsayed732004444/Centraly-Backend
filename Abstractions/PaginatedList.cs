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