using DTO;
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
    
    public DbSet<GenreDto> Genres => Set<GenreDto>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<GenreDto>()
            .HasData(
                new GenreDto { Id = Guid.NewGuid(), Code = 0, Name = "Action" },
                new GenreDto { Id = Guid.NewGuid(), Code = 1, Name = "Comedy" },
                new GenreDto { Id = Guid.NewGuid(), Code = 2, Name = "Drama" },
                new GenreDto { Id = Guid.NewGuid(), Code = 3, Name = "Misc" }
            );
    }
}
