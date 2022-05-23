using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Movie : BaseEntity
{
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    public List<Director> Directors { get; set; } = new();
    
    public List<Genre> Genres { get; set; } = new();
    
    public List<Comment> Comments { get; set; } = new();
}
