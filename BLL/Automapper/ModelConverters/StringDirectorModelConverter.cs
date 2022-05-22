using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;

namespace BLL.Automapper.ModelConverters;

internal class StringDirectorModelConverter : ITypeConverter<string, DirectorModel>
{
    private readonly IDirectorService _directorService;
    private readonly IMapper _mapper;

    public StringDirectorModelConverter(IMapper mapper, IDirectorService directorService)
    {
        _mapper = mapper;
        _directorService = directorService;
    }

    public DirectorModel Convert(string source, DirectorModel destination, ResolutionContext context) 
        => _mapper.Map<DirectorModel>(
                _directorService.GetFilteredAsync(directorModel => directorModel.FullName == source).Result
            );
}
