namespace Core.Models;

public class Comment : BaseEntity
{
    public string Author { get; set; }
    
    public string Body { get; set; }
    
    public Movie Movie { get; set; }

    public Comment? ParentComment { get; set; } = null;
}
