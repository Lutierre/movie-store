namespace DTO.Entities;

public class GenreDto : BaseEntityDto
{
    public string Name { get; set; }
    
    public int Code { get; set; }
    
    public List<MovieDto> Movies { get; set; }
}
