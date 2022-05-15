using Core.Models.Enums;

namespace Core.Models;

public class Movie : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public List<string> Directors { get; set; }
    
    public List<GenreCode> Genres { get; set; }
    
    public List<Comment> Comments { get; set; }
}
