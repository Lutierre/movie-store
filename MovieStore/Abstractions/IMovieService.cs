using MovieStore.Models;
using MovieStore.Models.Enums;

namespace MovieStore.Abstractions;

public interface IMovieService<T>
{
    T Create(string title, string? description, Genre[] genres, DateTime releaseDate);
    
    IEnumerable<T> Get();

    T? Get(Guid id);

    T? Update(Guid id, string title, string? description, Genre[] genres, DateTime releaseDate);

    void Delete(Guid id);
}
