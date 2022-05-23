namespace Core.Models;

public class CommentModel : BaseModel
{
    public string Author { get; set; } = string.Empty;
    
    public string Body { get; set; } = string.Empty;
    
    public Guid MovieId { get; set; }

    public Guid? ParentCommentId { get; set; }
}
