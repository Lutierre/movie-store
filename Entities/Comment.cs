using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Comment : BaseEntity
    {
        [MaxLength(50)]
        public string Author { get; set; } = string.Empty;
    
        [MaxLength(1000)]
        public string Body { get; set; } = string.Empty;

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        
        public Guid MovieId { get; set; }

        [ForeignKey("ParentCommentId")]
        public Comment? ParentComment { get; set; }
        
        public Guid? ParentCommentId { get; set; }
    }
}
