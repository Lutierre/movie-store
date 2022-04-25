using MovieStore.Abstractions;
using MovieStore.Models;

namespace MovieStore.Services;

public class Service : IService<Movie>
{
    private static readonly List<Movie> _movies = new List<Movie>();
    
    public IEnumerable<Movie> Get() => _movies;

    public Movie? Get(Guid id) => _movies.Find(movie => movie.Id == id);

    public Movie Create(Movie entity)
    {
        _movies.Add(entity);

        return entity;
    }

    public Movie? Update(Guid id, Movie entity)
    {
        var movie = Get(id);

        if (movie is null)
        {
            return null;
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
            return;
        }

        _movies.Remove(movie);
    }
}
