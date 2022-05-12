using System.ComponentModel.DataAnnotations;
using Core.ManyToMany;
using Core.Models.Enums;

namespace Core.Models;

public class Genre : BaseEntity
{
    [Required]
    public GenreCode Code { get; set; }
    
    public List<GenreMovie> GenreMovies { get; set; }
}
