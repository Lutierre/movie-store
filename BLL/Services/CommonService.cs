using System.Linq.Expressions;
using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using Entities;

namespace BLL.Services;

public class CommonService<TModel, TEntity> : ICommonService<TModel>
    where TModel : BaseModel where TEntity : BaseEntity
{
    protected readonly UnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public CommonService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<TModel> CreateAsync(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        entity = await _unitOfWork.GetRepository<TEntity>().CreateAsync(entity);
        await _unitOfWork.SaveAsync();

        model = _mapper.Map<TModel>(entity);
        
        return model;
    }

    public async Task<List<TModel>> GetAsync()
    {
        var entities = await _unitOfWork.GetRepository<TEntity>().GetAsync();
        var models = entities.Select(entity => _mapper.Map<TModel>(entity)).ToList();

        return models;
    }

    public async Task<TModel?> GetAsync(Guid id) 
    {
        var entity = await _unitOfWork.GetRepository<TEntity>().GetAsync(id);
        var model = _mapper.Map<TModel>(entity);

        return model;
    }

    public async Task<TModel> GetFilteredAsync(Expression<Func<TModel, bool>> predicate)
    {
        var entity = await _unitOfWork.GetRepository<TEntity>()
            .GetSingleAsync(model => predicate.Compile()(_mapper.Map<TModel>(model)));
        var model = _mapper.Map<TModel>(entity);
        
        return model;
    }

    public async Task<TModel?> UpdateAsync(Guid id, TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        entity = await _unitOfWork.GetRepository<TEntity>().UpdateAsync(id, entity);
        await _unitOfWork.SaveAsync();
        
        model = _mapper.Map<TModel>(entity);
        
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.GetRepository<TEntity>().DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}
