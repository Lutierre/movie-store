using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using DAL.Repositories;

namespace DAL;

public class UnitOfWork
{
    private readonly MovieStoreContext _context;
    private IGenericRepository<Comment>? _commentRepository;
    private IGenericRepository<Director>? _directorRepository;
    private IGenericRepository<Genre>? _genreRepository;
    private IGenericRepository<Movie>? _movieRepository;

    public UnitOfWork(MovieStoreContext context)
    {
        _context = context;
    }

    public IGenericRepository<Comment> CommentRepository => 
        _commentRepository ??= new GenericRepository<Comment>(_context);

    public IGenericRepository<Director> DirectorRepository => 
        _directorRepository ??= new GenericRepository<Director>(_context);

    public IGenericRepository<Genre> GenreRepository 
        => _genreRepository ??= new GenericRepository<Genre>(_context);

    public IGenericRepository<Movie> MovieRepository 
        => _movieRepository ??= new GenericRepository<Movie>(_context);

    public async Task Save() => await _context.SaveChangesAsync();
}
