using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.ExtensionMethods;

public static class MovieDbSetExtensions
{
    public static IQueryable<Movie> AddIncludes(this DbSet<Movie> dbSet) => dbSet
        .Include(movie => movie.Comments)
        .Include(movie => movie.Directors)
        .Include(movie => movie.Genres);
}
