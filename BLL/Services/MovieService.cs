using System.Linq.Expressions;
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
        var movies = await _unitOfWork.MovieRepository.GetAsync();
        var movieModels = movies.Select(dto => _mapper.Map<MovieModel>(dto)).ToList();

        return movieModels;
    }

    public async Task<MovieModel?> GetAsync(Guid id) 
    {
        var movie = await _unitOfWork.MovieRepository.GetAsync(id);
        var movieModel = _mapper.Map<MovieModel>(movie);

        return movieModel;
    }

    public async Task<MovieModel> GetFilteredAsync(Expression<Func<MovieModel, bool>> predicate)
    {
        var movie = await _unitOfWork.MovieRepository
            .GetFilteredAsync(movieModel => predicate.Compile()(_mapper.Map<MovieModel>(movieModel)));
        var movieModel = _mapper.Map<MovieModel>(movie);
        
        return movieModel;
    }

    public async Task<MovieModel> CreateAsync(MovieModel entity)
    {
        var movie = _mapper.Map<Movie>(entity);
        movie = await _unitOfWork.MovieRepository.CreateAsync(movie);
        await _unitOfWork.SaveAsync();

        var movieModel = _mapper.Map<MovieModel>(movie);
        
        return movieModel;
    }

    public async Task<MovieModel?> UpdateAsync(Guid id, MovieModel? entity)
    {
        var movie = _mapper.Map<Movie>(entity);
        movie = await _unitOfWork.MovieRepository.UpdateAsync(id, movie);
        await _unitOfWork.SaveAsync();
        
        var movieModel = _mapper.Map<MovieModel>(movie);
        
        return movieModel;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.MovieRepository.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
    }
}
