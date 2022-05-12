using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly MovieStoreContext _context;
    
    public GenericRepository(MovieStoreContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetAsync(Guid id)
    {
        Console.WriteLine("Inside GetAsync(id) method");
        var res = await _context.Set<T>().FindAsync(id);
        Console.WriteLine("Before returning");
        return res;
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<T?> UpdateAsync(Guid id, T? entity)
    {
        if (entity == null)
        {
            return null;
        }
        
        var existing = await _context.Set<T>().FindAsync(id);

        if (existing == null)
        {
            return existing;
        }
        
        _context.Entry(existing).CurrentValues.SetValues(entity);

        return existing;
    }

    public async Task DeleteAsync(Guid id)
    {
        var baseEntity = await GetAsync(id);

        if (baseEntity == null)
        {
            return;
        }
            
        _context.Set<T>().Remove(baseEntity);
    }
}
