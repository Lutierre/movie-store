using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Genre : BaseEntity
{
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;
    
    public int Code { get; set; }
    
    public List<Movie> Movies { get; set; } = new();
}
