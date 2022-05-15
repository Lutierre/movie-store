using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Entities;

public abstract class BaseEntityDto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
