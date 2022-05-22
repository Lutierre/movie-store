using AutoMapper;
using BLL.Abstractions.Interfaces;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class DirectorToEntityConverter : ITypeConverter<string, Director>
{
    private readonly IDirectorService _directorService;

    public DirectorToEntityConverter(IDirectorService directorService)
    {
        _directorService = directorService;
    }

    public Director Convert(string source, Director destination, ResolutionContext context)
        => _directorService.GetByFullName(source);
}
