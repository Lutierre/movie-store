namespace Core.Models;

public class CommentModel : BaseModel
{
    public string? Author { get; set; }
    
    public string? Body { get; set; }
    
    public Guid MovieId { get; set; }

    public Guid? ParentCommentId { get; set; }
}
