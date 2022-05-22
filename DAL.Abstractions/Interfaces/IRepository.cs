using System.Linq.Expressions;
using Entities;

namespace DAL.Abstractions.Interfaces;

public interface IRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAsync();
    
    Task<T?> GetAsync(Guid id);

    Task<T> CreateAsync(T entity);

    Task<T?> UpdateAsync(Guid id, T? entity);
    
    Task DeleteAsync(Guid id);

    Task<T?> GetSingleAsync(Expression<Func<T,bool>> predicate);
    
    Task <List<T>> GetFilteredAsync(Expression<Func<T,bool>> predicate);
}
