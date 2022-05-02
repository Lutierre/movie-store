using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services;

public class MovieService : IService<Movie>
{
    private readonly IGenericRepository<Movie?> _genericRepository;

    public MovieService(IGenericRepository<Movie?> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<List<Movie?>> GetAsync() => await _genericRepository.GetAsync();

    public async Task<Movie?> GetAsync(Guid id) => await _genericRepository.GetAsync(id);

    public async Task<Movie?> CreateAsync(Movie entity) => await _genericRepository.CreateAsync(entity);

    public async Task<Movie?> UpdateAsync(Guid id, Movie? entity) => await _genericRepository.UpdateAsync(id, entity);

    public async Task DeleteAsync(Guid id) => await _genericRepository.DeleteAsync(id);
}
