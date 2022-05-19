using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Movie : BaseEntity
{
    public string? Title { get; set; }

    public string? Description { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    public List<Director>? Directors { get; set; }
    
    public List<Genre>? Genres { get; set; }
    
    public List<Comment>? Comments { get; set; }
}
