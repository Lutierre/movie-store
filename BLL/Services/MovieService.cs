using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using DTO;

namespace BLL.Services;

public class MovieService : IService<Movie>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovieService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<Movie>> GetAsync()
    {
        var moviesDtos = await _unitOfWork.MovieRepository.GetAsync();
        var movies = moviesDtos.Select(dto => _mapper.Map<Movie>(dto)).ToList();

        return movies;
    }

    public async Task<Movie?> GetAsync(Guid id) 
    {
        var movieDto = await _unitOfWork.MovieRepository.GetAsync(id);
        var movie = _mapper.Map<Movie>(movieDto);

        return movie;
    }

    public async Task<Movie> CreateAsync(Movie entity)
    {
        var movieDto = _mapper.Map<MovieDto>(entity);
        movieDto = await _unitOfWork.MovieRepository.CreateAsync(movieDto);
        await _unitOfWork.Save();

        var movie = _mapper.Map<Movie>(movieDto);
        
        return movie;
    }

    public async Task<Movie?> UpdateAsync(Guid id, Movie? entity)
    {
        var movieDto = _mapper.Map<MovieDto>(entity);
        movieDto = await _unitOfWork.MovieRepository.UpdateAsync(id, movieDto);
        await _unitOfWork.Save();
        
        var movie = _mapper.Map<Movie>(movieDto);
        
        return movie;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.MovieRepository.DeleteAsync(id);
        await _unitOfWork.Save();
    }
}
