using GenericFilterCase.Interfaces;

namespace GenericFilterCase;

public static class Filters
{
    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, int[] values) where T: class, IFilterable
    {
        if (!(values != null && values.Any()))
        {
            return query;
        }
        if (query is IQueryable<IFilterableByParent> filterableByParent)
        {
            return (IQueryable<T>)filterableByParent.ApplyFilterByParent(values); // tu jest problem, bo ten cast nie bêdzie dzia³aæ
        }
        if (query is IQueryable<IFilterableByChild> filterableByChildId)
        {
            return (IQueryable<T>)filterableByChildId.ApplyFilterByChild(values); // tu jest problem, bo ten cast nie bêdzie dzia³aæ
        }
        return query;
    }
    public static IQueryable<T> ApplyFilterByChild<T>(this IQueryable<T> query, int[] values) where T: class, IFilterableByChild
    {
        return query.Where(entity => entity.Child.Filters.All(f => values.Contains(f.Value)));
    }
    public static IQueryable<T> ApplyFilterByParent<T>(this IQueryable<T> query, int[] values) where T : class, IFilterableByParent
    {
        return query.Where(entity => entity.Parent.Parts.SelectMany(part => part.Child.Filters).All(f => values.Contains(f.Value)));
    }
}