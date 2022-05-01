using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Models;

public class Movie : BaseEntity
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    [JsonPropertyName("release_date")]
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    [Required]
    public List<Director> Directors { get; set; }
    
    [Required]
    public List<Genre> Genres { get; set; }
}
