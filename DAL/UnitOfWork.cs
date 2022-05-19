using DAL.Abstractions.Interfaces;
using DAL.Context;
using DAL.Repositories;
using Entities;

namespace DAL;

public class UnitOfWork
{
    private readonly MovieStoreContext _context;
    private IRepository<Comment>? _commentRepository;
    private IRepository<Director>? _directorRepository;
    private MovieRepository? _movieRepository;
    private GenreRepository? _genreRepository;
    
    public UnitOfWork(MovieStoreContext context)
    {
        _context = context;
    }

    public IRepository<Comment> CommentRepository => 
        _commentRepository ??= new GenericRepository<Comment>(_context);

    public IRepository<Director> DirectorRepository => 
        _directorRepository ??= new GenericRepository<Director>(_context);

    public IRepository<Movie> MovieRepository 
        => _movieRepository ??= new MovieRepository(_context);

    public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_context);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
