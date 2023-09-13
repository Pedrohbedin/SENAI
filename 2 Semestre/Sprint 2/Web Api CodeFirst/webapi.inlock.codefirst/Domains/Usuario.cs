using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key()]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email é obrigatório!!!")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Senha obrigatória!!!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Senha de 6 a 20 caracteres!")]

        public string? Senha { get; set; }


    }
}
