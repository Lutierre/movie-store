using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Director : BaseEntity
{
    [Required]
    public string FullName { get; set; }
    
    public List<Movie> Movies { get; set; }
}
