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

    public IRepository<T> GetRepository<T>() where T : BaseEntity
    {
        var entityType = typeof(T);

        return entityType switch
        {
            Type when entityType == typeof(Movie) => MovieRepository as IRepository<T>,
            Type when entityType == typeof(Comment) => CommentRepository as IRepository<T>,
            Type when entityType == typeof(Director) => DirectorRepository as IRepository<T>,
            _ => throw new ArgumentException()
        };
    }
}
