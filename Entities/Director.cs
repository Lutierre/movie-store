using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Director : BaseEntity
    {
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;
        
        public List<Movie> Movies { get; set; } = new();
    }
}
