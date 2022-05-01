using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Genre : BaseEntity
{
    [Required]
    public string Name { get; set; }
    
    public List<Movie> Movies { get; set; }
}
