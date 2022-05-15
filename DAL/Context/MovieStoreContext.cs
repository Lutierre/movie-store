using Core.Models.Enums;
using DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class MovieStoreContext : DbContext
{
    public MovieStoreContext(DbContextOptions<MovieStoreContext> options) : base(options)
    {
    }

    public DbSet<MovieDto> Movies => Set<MovieDto>();
    
    public DbSet<DirectorDto> Directors => Set<DirectorDto>();
    
    public DbSet<CommentDto> Comments => Set<CommentDto>();
    
    public DbSet<GenreDto?> Genres => Set<GenreDto>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<GenreDto>()
            .HasData(
                new GenreDto { Id = Guid.NewGuid(), Code = (int)GenreCode.Action, Name = nameof(GenreCode.Action) },
                new GenreDto { Id = Guid.NewGuid(), Code = (int)GenreCode.Comedy, Name = nameof(GenreCode.Comedy) },
                new GenreDto { Id = Guid.NewGuid(), Code = (int)GenreCode.Drama, Name = nameof(GenreCode.Drama) },
                new GenreDto { Id = Guid.NewGuid(), Code = (int)GenreCode.Misc, Name = nameof(GenreCode.Misc) }
            );
    }
}
