using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.ExtensionMethods;

public static class MovieDbSetExtensions
{
    public static IQueryable<Movie> AddIncludes(this DbSet<Movie> dbSet) => dbSet
        .Include(dto => dto.Comments)
        .Include(dto => dto.Directors)
        .Include(dto => dto.Genres);
}
