using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Genre : BaseEntity
{
    [Required]
    public Core.Models.Enums.Genre Code { get; set; }
    
    public List<Movie> Movies { get; set; }
}
