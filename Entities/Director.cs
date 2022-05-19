namespace Entities
{
    public class Director : BaseEntity
    {
        public string? FullName { get; set; }
        
        public List<Movie>? Movies { get; set; }
    }
}
