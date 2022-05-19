namespace Entities;

public class Genre : BaseEntity
{
    public string? Name { get; set; }
    
    public int Code { get; set; }
    
    public List<Movie>? Movies { get; set; }
}
