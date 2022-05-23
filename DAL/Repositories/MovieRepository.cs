using System.Linq.Expressions;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using DAL.ExtensionMethods;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

internal class MovieRepository : IRepository<Movie>
{
    private readonly MovieStoreContext _context;
    private readonly IRepository<Movie> _wrappeeMovieRepository;

    public MovieRepository(MovieStoreContext context)
    {
        _context = context;
        _wrappeeMovieRepository = new GenericRepository<Movie>(context);
    }
    
    public async Task<List<Movie>> GetAsync() => await _context.Set<Movie>().AddIncludes().ToListAsync();

    public async Task<Movie?> GetAsync(Guid id)
        => await _context.Set<Movie>().AddIncludes().SingleOrDefaultAsync(movie => movie.Id == id);

    public async Task<Movie> CreateAsync(Movie entity) => await _wrappeeMovieRepository.CreateAsync(entity);

    public async Task DeleteAsync(Guid id) => await _wrappeeMovieRepository.DeleteAsync(id);
    
    public async Task<Movie?> GetSingleAsync(Expression<Func<Movie, bool>> predicate)
        => await _context.Set<Movie>().AddIncludes().SingleOrDefaultAsync(predicate);

    public async Task<List<Movie>> GetFilteredAsync(Expression<Func<Movie, bool>> predicate)
        => await _context.Set<Movie>().AddIncludes().Where(predicate).ToListAsync();
    
    public async Task<Movie?> UpdateAsync(Guid id, Movie? entity)
    {
        if (entity == null)
        {
            return null;
        }
        
        var existing = await _context.Set<Movie>().AddIncludes().SingleOrDefaultAsync(movie => movie.Id == id);

        if (existing == null)
        {
            return existing;
        }

        entity.Id = id;
        _context.Entry(existing).CurrentValues.SetValues(entity);

        UpdateRelated(existing.Genres, entity.Genres);
        UpdateRelated(existing.Directors, entity.Directors);

        return existing;
    }

    private void UpdateRelated<T>(List<T>? existingEntities, List<T>? newEntities) where T : BaseEntity
    {
        foreach (var item in existingEntities.ToList())
        {
            if (!newEntities.Any(entity => entity.Id == item.Id))
            {
                existingEntities.Remove(item);
            }
        }

        foreach (var item in newEntities)
        {
            var entity = existingEntities.SingleOrDefault(entity => entity.Id == item.Id);

            if (entity is null)
            {
                existingEntities.Add(item);
            }
        }
    }
}
