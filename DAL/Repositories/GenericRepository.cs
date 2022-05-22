using System.Linq.Expressions;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

internal class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly MovieStoreContext Context;
    
    public GenericRepository(MovieStoreContext context)
    {
        Context = context;
    }

    public async Task<List<T>> GetAsync() => await Context.Set<T>().ToListAsync();

    public async Task<T?> GetAsync(Guid id) => await Context.Set<T>().FindAsync(id);

    public async Task<T> CreateAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<T?> UpdateAsync(Guid id, T? entity)
    {
        if (entity == null)
        {
            return null;
        }
        
        var existing = await Context.Set<T>().FindAsync(id);

        if (existing == null)
        {
            return existing;
        }

        entity.Id = id;
        Context.Entry(existing).CurrentValues.SetValues(entity);

        return existing;
    }

    public async Task DeleteAsync(Guid id)
    {
        var baseEntity = await GetAsync(id);

        if (baseEntity == null)
        {
            return;
        }
            
        Context.Set<T>().Remove(baseEntity);
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate)
        => await Context.Set<T>().SingleOrDefaultAsync(predicate);

    public virtual async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate)
        => await Context.Set<T>().Where(predicate).ToListAsync();
}
