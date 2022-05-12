using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.ManyToMany;

namespace Core.Models;

public class Movie : BaseEntity
{
    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }
    
    public List<Director> Directors { get; set; }
    
    public List<GenreMovie> GenreMovies { get; set; }
}
