using AutoMapper;
using Core.Models.Enums;
using DAL;
using DTO.Entities;

namespace BLL.Automapper.ModelConverters;

public class GenreCodeModelConverter : ITypeConverter<GenreCode, GenreDto>
{
    private readonly UnitOfWork _unitOfWork;

    public GenreCodeModelConverter(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public GenreDto? Convert(GenreCode source, GenreDto destination, ResolutionContext context)
        => _unitOfWork.GenreRepository.GetByCodeAsync(source).Result;
}