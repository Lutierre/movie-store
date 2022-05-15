using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using DTO.Entities;

namespace BLL.Services;

public class DirectorService : IService<Director>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DirectorService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Director> CreateAsync(Director entity)
    {
        var directorDto = _mapper.Map<DirectorDto>(entity);
        directorDto = await _unitOfWork.DirectorRepository.CreateAsync(directorDto);
        await _unitOfWork.Save();

        var director = _mapper.Map<Director>(directorDto);
        
        return director;
    }

    public async Task<List<Director>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Director?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Director?> UpdateAsync(Guid id, Director entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
