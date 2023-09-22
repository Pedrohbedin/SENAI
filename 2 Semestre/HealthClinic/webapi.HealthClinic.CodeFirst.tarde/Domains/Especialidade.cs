using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O titulo é um campo obrigatório")]
        public string? Titulo { get; set; }
    }
}
