using MovieStore.Abstractions;
using MovieStore.Models;
using MovieStore.Models.Enums;

namespace MovieStore.Services;

public class MovieService : IMovieService<Movie>
{
    private List<Movie> _movies = new List<Movie>();

    public Movie Create(string title, string? description, Genre[] genres, DateTime releaseDate)
    {
        var movie = new Movie(title, description, genres, releaseDate);
        _movies.Add(movie);

        return movie;
    }

    public IEnumerable<Movie> Get() => _movies;

    public Movie? Get(Guid id) => _movies.Find(movie => movie.Id == id);

    public Movie? Update(Guid id, string title, string? description, Genre[] genres, DateTime releaseDate)
    {
        var movie = Get(id);

        if (movie is null)
        {
            return null;
        }

        movie.Title = title;
        movie.Description = description;
        movie.Genres = genres;
        movie.ReleaseDate = releaseDate;

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
