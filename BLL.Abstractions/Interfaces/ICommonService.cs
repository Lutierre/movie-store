using System.Linq.Expressions;
using Core.Models;
using Entities;

namespace BLL.Abstractions.Interfaces;

public interface ICommonService<TModel> where TModel : BaseModel
{
    Task<TModel> CreateAsync(TModel model);
    
    Task<List<TModel>> GetAsync();

    Task<TModel?> GetAsync(Guid id);

    Task<TModel> GetFilteredAsync(Expression<Func<TModel,bool>> predicate);
    
    Task<TModel?> UpdateAsync(Guid id, TModel model);

    Task DeleteAsync(Guid id);
}
