namespace DTO.Entities
{
    public class DirectorDto : BaseEntityDto
    {
        public string FullName { get; set; }
        
        public List<MovieDto> Movies { get; set; }
    }
}
