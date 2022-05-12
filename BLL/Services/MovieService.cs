using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;

namespace BLL.Services;

public class MovieService : IService<Movie>
{
    private readonly UnitOfWork _unitOfWork;

    public MovieService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Movie>> GetAsync() => await _unitOfWork.MovieRepository.GetAsync();

    public async Task<Movie?> GetAsync(Guid id) => await _unitOfWork.MovieRepository.GetAsync(id);

    public async Task<Movie> CreateAsync(Movie entity)
    {
        var movie = await _unitOfWork.MovieRepository.CreateAsync(entity);
        _unitOfWork.Save();
        
        return movie;
    }

    public async Task<Movie?> UpdateAsync(Guid id, Movie? entity)
    {
        var movie = await _unitOfWork.MovieRepository.UpdateAsync(id, entity);
        _unitOfWork.Save();
        
        return movie;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.MovieRepository.DeleteAsync(id);
        _unitOfWork.Save();
    }
}
