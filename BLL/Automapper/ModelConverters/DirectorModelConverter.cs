using AutoMapper;
using DAL;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class DirectorModelConverter : ITypeConverter<string, Director>
{
    private readonly UnitOfWork _unitOfWork;

    public DirectorModelConverter(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Director Convert(string source, Director destination, ResolutionContext context)
        => _unitOfWork.DirectorRepository.GetFilteredAsync(dto => dto.FullName == source).Result ??
           _unitOfWork.DirectorRepository.CreateAsync(new Director { FullName = source }).Result;
}
