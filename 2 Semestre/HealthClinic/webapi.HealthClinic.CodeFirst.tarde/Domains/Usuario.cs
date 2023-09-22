using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    [Table(nameof(Usuario))]
    [Microsoft.EntityFrameworkCore.Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "O id do tipo de usuario é um campo obrigatório")]
        public Guid IdTipoUsuario { get; set; }
        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario;
        [Column(TypeName = "VARHCAR(110)")]
        [Required(ErrorMessage = "O email é um campo obrigatório")]
        public string? Email { get; set; }
        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha é obrigatória!!!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public int MyProperty { get; set; }
    }
}
