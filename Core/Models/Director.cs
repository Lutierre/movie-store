using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Models;

public class Director : BaseEntity
{
    [Required]
    public string FullName { get; set; }
    
    [JsonIgnore]
    public List<Movie> Movies { get; set; }
}
