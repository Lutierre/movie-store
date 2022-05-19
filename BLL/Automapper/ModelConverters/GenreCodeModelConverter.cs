using AutoMapper;
using Core.Models.Enums;
using DAL;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class GenreCodeModelConverter : ITypeConverter<GenreCode, Genre>
{
    private readonly UnitOfWork _unitOfWork;

    public GenreCodeModelConverter(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Genre? Convert(GenreCode source, Genre destination, ResolutionContext context)
        => _unitOfWork.GenreRepository.GetByCodeAsync(source).Result;
}