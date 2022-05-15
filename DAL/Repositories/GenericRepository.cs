using DAL.Abstractions.Interfaces;
using DAL.Context;
using DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntityDto
{
    private readonly MovieStoreContext _context;
    
    public GenericRepository(MovieStoreContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetAsync(Guid id) => await _context.Set<T>().FindAsync(id);

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

        entity.Id = id;
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
