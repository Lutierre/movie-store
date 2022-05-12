using Core.ManyToMany;
using Core.Models;
using Core.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class MovieStoreContext : DbContext
{
    public MovieStoreContext(DbContextOptions<MovieStoreContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();
    
    public DbSet<Director> Directors => Set<Director>();
    
    public DbSet<Comment> Comments => Set<Comment>();
    
    public DbSet<Genre> Genres => Set<Genre>();
    
    public DbSet<GenreMovie> GenreMovies => Set<GenreMovie>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GenreMovie>()
            .HasKey(gm => new { gm.GenreId, gm.MovieId });
        
        // modelBuilder.Entity<GenreMovie>()
        //     .HasOne(gm => gm.Genre)
        //     .WithMany(g => g.GenreMovies)
        //     .HasForeignKey(gm => gm.Movie);
        //
        // modelBuilder.Entity<GenreMovie>()
        //     .HasOne(gm => gm.Movie)
        //     .WithMany(m => m.GenreMovies)
        //     .HasForeignKey(gm => gm.Genre);
        
        modelBuilder
            .Entity<Genre>()
            .HasData(
                new Genre { Id = Guid.NewGuid(), Code = GenreCode.Action },
                new Genre { Id = Guid.NewGuid(), Code = GenreCode.Comedy },
                new Genre { Id = Guid.NewGuid(), Code = GenreCode.Drama },
                new Genre { Id = Guid.NewGuid(), Code = GenreCode.Misc }
            );
    }
}
