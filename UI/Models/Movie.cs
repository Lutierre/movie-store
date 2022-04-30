using System.Text.Json.Serialization;
using UI.Models.Enums;

namespace UI.Models;

public class Movie
{
    public Guid Id { get; } = Guid.NewGuid();

    public string? Title { get; set; }

    public string? Description { get; set; }

    public Genre[]? Genres { get; set; }

    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }
}
