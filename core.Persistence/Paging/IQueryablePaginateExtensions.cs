using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Paging;

public static class IQueryablePaginateExtensions
{
    public static async Task<Paginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size)
    {

        int count = await source.CountAsync();
        List<T> items = await source.Skip(index * size).Take(size).ToListAsync();
                                    
        Paginate<T> list = new()
        {
            Index = index,
            Size = size,
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size)
        };

        return list;
    }
}