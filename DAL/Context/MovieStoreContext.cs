using Core.Models;
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
}
