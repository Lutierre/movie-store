using System.Text.Json.Serialization;
using MovieStore.Models.Enums;

namespace MovieStore.Models;

public class Movie
{
    public Guid Id { get; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public Genre[] Genres { get; set; }

    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }

    public Movie(string title, string? description, Genre[] genres, DateTime releaseDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Genres = genres;
        ReleaseDate = releaseDate;
    }
}
