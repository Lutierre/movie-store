using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using Core.Models.Enums;
using DAL.Abstractions.Interfaces;
using Entities;

namespace BLL.Services;

internal class MovieService : CommonService<MovieModel, Movie>, IMovieService
{
    private readonly IDirectorService _directorService;
    private readonly IGenreService _genreService;
    
    public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IDirectorService directorService, IGenreService genreService) 
        : base(unitOfWork, mapper)
    {
        _directorService = directorService;
        _genreService = genreService;
    }

    protected override MovieModel ConvertToModel(Movie entity)
    {
        var model = _mapper.Map<MovieModel>(entity);

        foreach (var director in entity.Directors)
        {
            model.DirectorsFullNames.Add(director.FullName);
        }
        
        foreach (var genre in entity.Genres)
        {
            model.GenreCodes.Add((GenreCode)genre.Code);
        }

        return model;
    }
    
    protected override Movie ConvertToEntity(MovieModel model)
    {
        var entity = _mapper.Map<Movie>(model);

        foreach (var fullName in model.DirectorsFullNames)
        {
            entity.Directors.Add(_directorService.GetByFullName(fullName));
        }

        foreach (var genre in model.GenreCodes)
        {
            entity.Genres.Add(_genreService.GetByCode(genre));
        }

        return entity;
    }

    public async Task<Movie?> GetEntityAsync(Guid movieId) => await _unitOfWork.MovieRepository.GetAsync(movieId);
}
