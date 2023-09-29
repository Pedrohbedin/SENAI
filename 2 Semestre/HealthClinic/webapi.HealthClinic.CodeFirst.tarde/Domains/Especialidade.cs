using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa uma especialidade médica.
    /// </summary>
    public class Especialidade
    {
        /// <summary>
        /// Obtém ou define o Id da especialidade.
        /// </summary>
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define o título da especialidade.
        /// </summary>
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O título é um campo obrigatório")]
        public string? Titulo { get; set; }
    }
}
