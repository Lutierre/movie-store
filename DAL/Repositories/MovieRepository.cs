using System.Linq.Expressions;
using DAL.Abstractions.Interfaces;
using DAL.Context;
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

    public async Task<List<Movie>> GetAsync() => await _context.Set<Movie>()
        .Include(dto => dto.Comments)
        .Include(dto => dto.Directors)
        .Include(dto => dto.Genres)
        .ToListAsync();

    public async Task<Movie?> GetAsync(Guid id) => await _context.Set<Movie>()
        .Include(dto => dto.Comments)
        .Include(dto => dto.Directors)
        .Include(dto => dto.Genres)
        .SingleOrDefaultAsync(dto => dto.Id == id);

    public async Task<Movie> CreateAsync(Movie entity) => await _wrappeeMovieRepository.CreateAsync(entity);

    public async Task DeleteAsync(Guid id) => await _wrappeeMovieRepository.DeleteAsync(id);
    
    public async Task<Movie?> UpdateAsync(Guid id, Movie? entity)
    {
        if (entity == null)
        {
            return null;
        }
        
        var existing = await _context.Set<Movie>()
            .Include(dto => dto.Comments)
            .Include(dto => dto.Directors)
            .Include(dto => dto.Genres)
            .SingleOrDefaultAsync(dto => dto.Id == id);

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

    private void UpdateRelated<T>(List<T>? existingDtos, List<T>? newDtos) where T : BaseEntity
    {
        foreach (var entityDto in existingDtos.ToList())
        {
            if (!newDtos.Any(dto => dto.Id == entityDto.Id))
            {
                existingDtos.Remove(entityDto);
            }
        }

        foreach (var item in newDtos)
        {
            var dto = existingDtos.SingleOrDefault(d => d.Id == item.Id);

            if (dto is null)
            {
                existingDtos.Add(item);
            }
        }
    }

    public Task<Movie?> GetFilteredAsync(Expression<Func<Movie, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
