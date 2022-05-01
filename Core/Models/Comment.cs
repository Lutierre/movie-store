using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Comment : BaseEntity
{
    [Required]
    public string Author { get; set; }
    
    [Required]
    public string Body { get; set; }
    
    [Required]
    [ForeignKey("MovieId")]
    public Movie Movie { get; set; }

    public Guid? ParentId { get; set; } = null;
}
