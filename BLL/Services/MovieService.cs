using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using Entities;

namespace BLL.Services;

public class MovieService : IService<MovieModel>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovieService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<MovieModel>> GetAsync()
    {
        var moviesDtos = await _unitOfWork.MovieRepository.GetAsync();
        var movies = moviesDtos.Select(dto => _mapper.Map<MovieModel>(dto)).ToList();

        return movies;
    }

    public async Task<MovieModel?> GetAsync(Guid id) 
    {
        var movieDto = await _unitOfWork.MovieRepository.GetAsync(id);
        var movie = _mapper.Map<MovieModel>(movieDto);

        return movie;
    }

    public async Task<MovieModel> CreateAsync(MovieModel entity)
    {
        var movieDto = _mapper.Map<Movie>(entity);
        movieDto = await _unitOfWork.MovieRepository.CreateAsync(movieDto);
        await _unitOfWork.SaveAsync();

        var movie = _mapper.Map<MovieModel>(movieDto);
        
        return movie;
    }

    public async Task<MovieModel?> UpdateAsync(Guid id, MovieModel? entity)
    {
        var movieDto = _mapper.Map<Movie>(entity);
        movieDto = await _unitOfWork.MovieRepository.UpdateAsync(id, movieDto);
        await _unitOfWork.SaveAsync();
        
        var movie = _mapper.Map<MovieModel>(movieDto);
        
        return movie;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.MovieRepository.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}
