using AutoMapper.QueryableExtensions;
using BlogDemo.Application.Extensions;
using BlogDemo.Application.Interfaces;
using BlogDemo.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogDemo.Infrastructure.Data.Repositories
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity, new()
    {
        protected DbContext Context { get; }

        protected IQueryable<T> Source => Context.Set<T>();

        protected AutoMapper.IConfigurationProvider MapperConfiguration { get; }

        public EfCoreRepository(DbContext context, AutoMapper.IConfigurationProvider mapperConfiguration)
        {
            Context = context;
            MapperConfiguration = mapperConfiguration;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Source.AsNoTracking()
                               .SingleOrDefaultAsync(predicate);
        }

        public async Task<TDestination?> GetAsync<TDestination>(Expression<Func<T, bool>> predicate) 
        {
            return await Source.AsNoTracking()
                               .Where(predicate)
                               .ProjectTo<TDestination>(MapperConfiguration)
                               .SingleOrDefaultAsync();
        }

        public async Task<T?> GetAsync(ICriteria<T> criteria)
        {
            return await criteria.Build(Source)
                                 .AsNoTracking()
                                 .SingleOrDefaultAsync();
        }

        public async Task<TDestination?> GetAsync<TDestination>(ICriteria<T> criteria)
        {
            return await criteria.Build(Source)
                                 .AsNoTracking()
                                 .ProjectTo<TDestination>(MapperConfiguration)
                                 .SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            return await Source.AsNoTracking()
                               .WhereNullable(predicate)
                               .ToListAsync();
        }

        public async Task<List<TDestination>> GetListAsync<TDestination>(Expression<Func<T, bool>>? predicate = null)
        {
            return await Source.AsNoTracking()
                               .WhereNullable(predicate)
                               .ProjectTo<TDestination>(MapperConfiguration)
                               .ToListAsync();
        }

        public async Task<List<T>> GetListAsync(ICriteria<T> criteria)
        {
            return await criteria.Build(Source)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<List<TDestination>> GetListAsync<TDestination>(ICriteria<T> criteria)
        {
            return await criteria.Build(Source)
                                 .AsNoTracking()
                                 .ProjectTo<TDestination>(MapperConfiguration)
                                 .ToListAsync();
        }

        public async Task<T> CreateAsync(T item)
        {
            Context.Entry(item).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return item;
        }

        public async Task<int> DeleteAsync(T item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return item.Id;
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
        {
            return predicate == null ? Source.AnyAsync() : Source.AnyAsync(predicate);
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }        
    }
}
