using System.ComponentModel.DataAnnotations;

namespace DTO.Entities;

public class MovieDto : BaseEntityDto
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    public List<DirectorDto> Directors { get; set; }
    
    public List<GenreDto> Genres { get; set; }
    
    public List<CommentDto> Comments { get; set; }
}
