using MovieStore.Models.Enums;

namespace MovieStore.Models;

public class Movie
{
    public Guid Id { get; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public Genre[] Genres { get; set; }

    public DateTime ReleaseDate { get; set; }
}
