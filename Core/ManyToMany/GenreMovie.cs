using Core.Models;

namespace Core.ManyToMany;

public class GenreMovie
{
    public Movie Movie { get; set; }
    
    public Guid MovieId { get; set; }
    
    public Genre Genre { get; set; }
    
    public Guid GenreId { get; set; }

}
