using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using Entities;

namespace BLL.Services;

internal class DirectorService : CommonService<DirectorModel, Director>, IDirectorService
{
    public DirectorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public Director GetByFullName(string fullName) 
        => _unitOfWork.DirectorRepository.GetSingle(director => director.FullName == fullName)
           ?? _unitOfWork.DirectorRepository.Create(new Director { FullName = fullName });
}
