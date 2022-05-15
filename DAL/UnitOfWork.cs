using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using DAL.Repositories;
using DTO.Entities;

namespace DAL;

public class UnitOfWork
{
    private readonly MovieStoreContext _context;
    private IGenericRepository<CommentDto>? _commentRepository;
    private IGenericRepository<DirectorDto>? _directorRepository;
    private IGenericRepository<MovieDto>? _movieRepository;

    public UnitOfWork(MovieStoreContext context)
    {
        _context = context;
    }

    public IGenericRepository<CommentDto> CommentRepository => 
        _commentRepository ??= new GenericRepository<CommentDto>(_context);

    public IGenericRepository<DirectorDto> DirectorRepository => 
        _directorRepository ??= new GenericRepository<DirectorDto>(_context);

    public IGenericRepository<MovieDto> MovieRepository 
        => _movieRepository ??= new GenericRepository<MovieDto>(_context);

    public async Task Save() => await _context.SaveChangesAsync();
}
