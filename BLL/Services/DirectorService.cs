using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using Entities;

namespace BLL.Services;

internal class DirectorService : CommonService<DirectorModel, Director>, IDirectorService
{
    public DirectorService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    // todo: to ask
    public Director GetByFullName(string fullName) 
        => _unitOfWork.DirectorRepository.GetSingleAsync(director => director.FullName == fullName).Result
           ?? _unitOfWork.DirectorRepository.CreateAsync(new Director { FullName = fullName }).Result;
}
