using BlogDemo.Application.Extensions;
using BlogDemo.Application.Interfaces;
using System.Linq.Expressions;

namespace BlogDemo.Application.Criterias
{
    public class BlogOrderedListCriteria : ICriteria<Blog>
    {
        private readonly Expression<Func<Blog, bool>>? _predicate;

        public BlogOrderedListCriteria(Expression<Func<Blog, bool>>? predicate = null)
        {
            _predicate = predicate;
        }

        public IQueryable<Blog> Build(IQueryable<Blog> query)
        {
            return query.WhereNullable(_predicate)
                        .OrderByDescending(x => x.CreatedOnUtc)
                        .ThenBy(x => x.Title);
        }
    }
}
