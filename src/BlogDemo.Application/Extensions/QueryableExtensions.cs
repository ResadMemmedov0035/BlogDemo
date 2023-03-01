using System.Linq.Expressions;

namespace BlogDemo.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereNullable<T>(this IQueryable<T> query, Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? query : query.Where(predicate);
        }

        //public static IQueryable<T> AggregateInclude<T>(this IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes)
        //    where T : class
        //{
        //    return includes.Aggregate(seed: query, (current, include) => current.Include(include));
        //}

        //public static IQueryable<T> AggregateOrderBy<T>(this IQueryable<T> query, IEnumerable<OrderInfo<T>> orders)
        //    where T : class
        //{
        //    int i = 0;
        //    IOrderedQueryable<T>? orderedQuery = null;
        //    return orders.Aggregate(seed: query, (current, order) =>
        //    {
        //        // if first order
        //        if (i++ == 0)
        //        {
        //            orderedQuery = order.Type == OrderType.Asc
        //            ? current.OrderBy(order.OrderBy) 
        //            : current.OrderByDescending(order.OrderBy);
        //        }
        //        else
        //        {
        //            orderedQuery = order.Type == OrderType.Asc
        //            ? orderedQuery!.ThenBy(order.OrderBy) 
        //            : orderedQuery!.ThenByDescending(order.OrderBy);
        //        }
        //        return orderedQuery;
        //    });
        //}
    }
}
