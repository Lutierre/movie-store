using Core.Models;

namespace BLL.Abstractions.Interfaces;

public interface IService<T> where T : BaseEntity
{
    Task<T?> CreateAsync(T entity);
    
    Task<List<T>> GetAsync();

    Task<T?> GetAsync(Guid id);

    Task<T?> UpdateAsync(Guid id, T entity);

    Task DeleteAsync(Guid id);
}
