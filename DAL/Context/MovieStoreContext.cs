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
    
    public DbSet<GenreDto> Genres => Set<GenreDto>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GenreDto>()
            .HasData(Enum.GetValues(typeof(GenreCode))
                .Cast<GenreCode>()
                .Select(genreCode => new GenreDto
                {
                    Id = Guid.NewGuid(),
                    Code = Convert.ToInt32(genreCode),
                    Name = genreCode.ToString()
                })
            );
    }
}
