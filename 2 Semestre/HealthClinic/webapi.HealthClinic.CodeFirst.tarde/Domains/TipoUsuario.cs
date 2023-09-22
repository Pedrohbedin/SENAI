using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    [Table(nameof(TipoUsuario))]
    [Microsoft.EntityFrameworkCore.Index(nameof(Titulo), IsUnique = true)]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();
        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "O titulo é um campo obrigatório")]
        public string? Titulo { get; set; }
    }
}
