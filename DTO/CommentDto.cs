using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class CommentDto : BaseEntityDto
    {
        public string Author { get; set; }
    
        public string Body { get; set; }
    
        [ForeignKey("MovieId")]
        public MovieDto Movie { get; set; }

        [ForeignKey("ParentCommentId")]
        public CommentDto? ParentComment { get; set; } = null;
    }
}
