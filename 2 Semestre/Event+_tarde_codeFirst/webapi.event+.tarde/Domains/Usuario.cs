using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Usuario))]
    [Microsoft.EntityFrameworkCore.Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid idUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é um campo obrigatório!!!")]
        public string? Name { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = " O email é um campo obrigatório!!!")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha é obrigatória!!!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório!!!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
