using DAL.Abstractions.Interfaces;
using DAL.Context;
using DAL.Repositories;
using DTO.Entities;

namespace DAL;

public class UnitOfWork
{
    private readonly MovieStoreContext _context;
    private IRepository<CommentDto>? _commentRepository;
    private IRepository<DirectorDto>? _directorRepository;
    private MovieRepository? _movieRepository;
    private GenreRepository? _genreRepository;
    
    public UnitOfWork(MovieStoreContext context)
    {
        _context = context;
    }

    public IRepository<CommentDto> CommentRepository => 
        _commentRepository ??= new GenericRepository<CommentDto>(_context);

    public IRepository<DirectorDto> DirectorRepository => 
        _directorRepository ??= new GenericRepository<DirectorDto>(_context);

    public IRepository<MovieDto> MovieRepository 
        => _movieRepository ??= new MovieRepository(_context);

    public GenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_context);

    public async Task Save() => await _context.SaveChangesAsync();
}
