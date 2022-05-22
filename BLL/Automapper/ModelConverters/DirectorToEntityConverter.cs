using AutoMapper;
using DAL;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class DirectorToEntityConverter : ITypeConverter<string, Director>
{
    private readonly UnitOfWork _unitOfWork;

    public DirectorToEntityConverter(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Director Convert(string source, Director destination, ResolutionContext context)
        => _unitOfWork.DirectorRepository.GetSingleAsync(director => director.FullName == source).Result ??
           _unitOfWork.DirectorRepository.CreateAsync(new Director { FullName = source }).Result;
}
