using AutoMapper;
using BLL.Abstractions.Interfaces;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class GuidMovieModelConverter : ITypeConverter<Guid, Movie>
{
    private readonly IMovieService _service;
    
    public GuidMovieModelConverter(IMovieService service)
    {
        _service = service;
    }

    // todo: to ask about .result
    public Movie Convert(Guid source, Movie destination, ResolutionContext context) 
        => _service.GetEntityAsync(source).Result;
}
