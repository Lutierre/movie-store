using System.Linq.Expressions;
using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using Entities;

namespace BLL.Services;

internal class CommonService<TModel, TEntity> : ICommonService<TModel>
    where TModel : BaseModel where TEntity : BaseEntity
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public CommonService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected virtual TModel ConvertToModel(TEntity entity) => _mapper.Map<TModel>(entity);
    
    protected virtual TEntity ConvertToEntity(TModel model) => _mapper.Map<TEntity>(model);
    
    public async Task<TModel> CreateAsync(TModel model)
    {
        var entity = ConvertToEntity(model);
        entity = await _unitOfWork.GetRepository<TEntity>().CreateAsync(entity);
        await _unitOfWork.SaveAsync();
        
        model = ConvertToModel(entity);
        
        return model;
    }

    public async Task<List<TModel>> GetAsync()
    {
        var entities = await _unitOfWork.GetRepository<TEntity>().GetAsync();
        var models = entities.Select(ConvertToModel).ToList();

        return models;
    }

    public async Task<TModel?> GetAsync(Guid id) 
    {
        var entity = await _unitOfWork.GetRepository<TEntity>().GetAsync(id);
        var model = ConvertToModel(entity);

        return model;
    }

    public async Task<TModel> GetFilteredAsync(Expression<Func<TModel, bool>> predicate)
    {
        var entity = await _unitOfWork.GetRepository<TEntity>()
            .GetSingleAsync(entity => predicate.Compile()(ConvertToModel(entity)));
        var model = ConvertToModel(entity);
        
        return model;
    }

    public async Task<TModel?> UpdateAsync(Guid id, TModel model)
    {
        var entity = ConvertToEntity(model);
        entity = await _unitOfWork.GetRepository<TEntity>().UpdateAsync(id, entity);
        await _unitOfWork.SaveAsync();
        
        model = ConvertToModel(entity);
        
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.GetRepository<TEntity>().DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}
