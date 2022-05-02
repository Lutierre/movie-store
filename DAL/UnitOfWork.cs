using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using DAL.Repositories;

namespace DAL;

public class UnitOfWork : IDisposable
{
    private readonly MovieStoreContext _context;
    private IGenericRepository<Movie>? _movieRepository;
    private IGenericRepository<Director>? _directorRepository;
    private IGenericRepository<Comment>? _commentRepository;
    private IGenericRepository<Genre>? _genreRepository;
    
    private bool _disposed = false;

    public IGenericRepository<Movie> MovieRepository => 
        _movieRepository ??= new GenericRepository<Movie>(_context);

    public IGenericRepository<Director> DirectorRepository => 
        _directorRepository ??= new GenericRepository<Director>(_context);

    public IGenericRepository<Comment> CommentRepository =>
        _commentRepository ??= new GenericRepository<Comment>(_context);

    public IGenericRepository<Genre> GenreRepository => 
        _genreRepository ??= new GenericRepository<Genre>(_context);
    
    public UnitOfWork(MovieStoreContext context)
    {
        _context = context;
    }
    
    ~UnitOfWork() => Dispose(false);
    
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }
        
        if (disposing)
        {
            _context.Dispose();
        }
            
        _disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // todo
    public void Save()
    {
        
    }
}
