using System.Linq.Expressions;

namespace BlogDemo.Application.Interfaces
{
    public interface IRepository<T> where T : Entity, new()
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<TDestination?> GetAsync<TDestination>(Expression<Func<T, bool>> predicate);
        Task<T?> GetAsync(ICriteria<T> criteria);
        Task<TDestination?> GetAsync<TDestination>(ICriteria<T> criteria);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
        Task<List<TDestination>> GetListAsync<TDestination>(Expression<Func<T, bool>>? predicate = null);
        Task<List<T>> GetListAsync(ICriteria<T> criteria);
        Task<List<TDestination>> GetListAsync<TDestination>(ICriteria<T> criteria);

        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<int> DeleteAsync(T item);

        Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);

        Task<int> SaveChangesAsync();
    }
}
