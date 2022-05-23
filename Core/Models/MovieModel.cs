using Core.Models.Enums;

namespace Core.Models;

public class MovieModel : BaseModel
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DateTime ReleaseDate { get; set; }

    public List<string> DirectorsFullNames { get; set; } = new();
    
    public List<GenreCode> GenreCodes { get; set; } = new();
    
    public List<CommentModel> Comments { get; set; } = new();
}
