using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa um tipo de usuário.
    /// </summary>
    [Table(nameof(TipoUsuario))]
    [Microsoft.EntityFrameworkCore.Index(nameof(Titulo), IsUnique = true)]
    public class TipoUsuario
    {
        /// <summary>
        /// Obtém ou define o Id do tipo de usuário.
        /// </summary>
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define o título do tipo de usuário.
        /// </summary>
        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "O título é um campo obrigatório")]
        public string? Titulo { get; set; }
    }
}
