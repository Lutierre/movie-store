using Core.Models;
using UI.Abstractions;

namespace UI.Services;

public class Service : IService<Movie>
{
    private static readonly List<Movie> Movies = new List<Movie>();
    
    public IEnumerable<Movie> Get() => Movies;

    public Movie? Get(Guid id) => Movies.Find(movie => movie.Id == id);

    public Movie Create(Movie entity)
    {
        Movies.Add(entity);

        return entity;
    }

    public Movie? Update(Guid id, Movie entity)
    {
        var movie = Get(id);

        if (movie is null)
        {
            throw new ArgumentNullException();
        }

        movie.Title = entity.Title;
        movie.Description = entity.Description;
        movie.Genres = entity.Genres;
        movie.ReleaseDate = entity.ReleaseDate;

        return movie;
    }

    public void Delete(Guid id)
    {
        var movie = Get(id);

        if (movie is null)
        {
            throw new ArgumentNullException();
        }

        Movies.Remove(movie);
    }
}
