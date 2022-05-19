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
        var directorDto = _mapper.Map<Director>(entity);
        directorDto = await _unitOfWork.DirectorRepository.CreateAsync(directorDto);
        await _unitOfWork.SaveAsync();

        var director = _mapper.Map<DirectorModel>(directorDto);
        
        return director;
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
