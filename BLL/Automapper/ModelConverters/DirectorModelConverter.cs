using AutoMapper;
using DAL;
using DTO.Entities;

namespace BLL.Automapper.ModelConverters;

public class DirectorModelConverter : ITypeConverter<string, DirectorDto>
{
    private readonly UnitOfWork _unitOfWork;

    public DirectorModelConverter(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork; }

    public DirectorDto Convert(string source, DirectorDto destination, ResolutionContext context)
        => _unitOfWork.DirectorRepository.GetFilteredAsync(dto => dto.FullName == source).Result ??
           _unitOfWork.DirectorRepository.CreateAsync(new DirectorDto { FullName = source }).Result;
}
