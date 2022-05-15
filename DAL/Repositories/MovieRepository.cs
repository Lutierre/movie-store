using System.Linq.Expressions;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class MovieRepository : IRepository<MovieDto>
{
    private readonly MovieStoreContext _context;
    private readonly IRepository<MovieDto> _wrappeeMovieRepository;

    public MovieRepository(MovieStoreContext context)
    {
        _context = context;
        _wrappeeMovieRepository = new GenericRepository<MovieDto>(context);
    }

    public async Task<List<MovieDto>> GetAsync() => await _context.Set<MovieDto>()
        .Include(dto => dto.Comments)
        .Include(dto => dto.Directors)
        .Include(dto => dto.Genres)
        .ToListAsync();

    public async Task<MovieDto?> GetAsync(Guid id) => await _context.Set<MovieDto>()
        .Include(dto => dto.Comments)
        .Include(dto => dto.Directors)
        .Include(dto => dto.Genres)
        .SingleOrDefaultAsync(dto => dto.Id == id);

    public async Task<MovieDto> CreateAsync(MovieDto entity) => await _wrappeeMovieRepository.CreateAsync(entity);

    public async Task DeleteAsync(Guid id) => await _wrappeeMovieRepository.DeleteAsync(id);
    
    public async Task<MovieDto?> UpdateAsync(Guid id, MovieDto? entity)
    {
        if (entity == null)
        {
            return null;
        }
        
        var existing = await _context.Set<MovieDto>()
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

        await UpdateRelated(existing.Genres, entity.Genres);
        await UpdateRelated(existing.Directors, entity.Directors);

        return existing;
    }

    private async Task UpdateRelated<T>(List<T> existingDtos, List<T> newDtos) where T : BaseEntityDto
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

    public Task<MovieDto?> GetFilteredAsync(Expression<Func<MovieDto, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
