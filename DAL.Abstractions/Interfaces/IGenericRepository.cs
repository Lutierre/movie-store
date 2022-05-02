using Core.Models;

namespace DAL.Abstractions.Interfaces;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAsync();
    
    Task<T?> GetAsync(Guid id);

    Task<T> CreateAsync(T entity);

    Task<T?> UpdateAsync(Guid id, T? entity);
    
    Task DeleteAsync(Guid id);
}
