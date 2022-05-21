using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using Entities;

namespace BLL.Services;

public class DirectorService : IService<DirectorModel>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DirectorService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DirectorModel> CreateAsync(DirectorModel entity)
    {
        var director = _mapper.Map<Director>(entity);
        director = await _unitOfWork.DirectorRepository.CreateAsync(director);
        await _unitOfWork.SaveAsync();

        var directorModel = _mapper.Map<DirectorModel>(director);
        
        return directorModel;
    }

    public async Task<List<DirectorModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<DirectorModel?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<DirectorModel?> UpdateAsync(Guid id, DirectorModel entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
