using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models.Enums;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class GenreCodeModelConverter : ITypeConverter<GenreCode, Genre>
{
    private readonly IGenreService _genreService;

    public GenreCodeModelConverter(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public Genre? Convert(GenreCode source, Genre destination, ResolutionContext context)
        => _genreService.GetByCodeAsync(source).Result;
}