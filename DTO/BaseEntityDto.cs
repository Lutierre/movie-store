using System.ComponentModel.DataAnnotations.Schema;

namespace DTO;

public abstract class BaseEntityDto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
