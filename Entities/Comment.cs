using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Comment : BaseEntity
    {
        public string? Author { get; set; }
    
        public string? Body { get; set; }
    
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }

        [ForeignKey("ParentCommentId")]
        public Comment? ParentComment { get; set; }
    }
}
