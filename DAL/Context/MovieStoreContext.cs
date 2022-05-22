using Core.Models.Enums;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

internal class MovieStoreContext : DbContext
{
    public MovieStoreContext(DbContextOptions<MovieStoreContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();
    
    public DbSet<Director> Directors => Set<Director>();
    
    public DbSet<Comment> Comments => Set<Comment>();
    
    public DbSet<Genre> Genres => Set<Genre>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>()
            .HasData(Enum.GetValues(typeof(GenreCode))
                .Cast<GenreCode>()
                .Select(genreCode => new Genre
                {
                    Id = Guid.NewGuid(),
                    Code = Convert.ToInt32(genreCode),
                    Name = genreCode.ToString()
                })
            );
    }
}
