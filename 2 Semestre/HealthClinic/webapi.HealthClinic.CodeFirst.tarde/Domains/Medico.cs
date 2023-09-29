using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa um médico.
    /// </summary>
    [Table(nameof(Medico))]
    [Microsoft.EntityFrameworkCore.Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        /// <summary>
        /// Obtém ou define o Id do médico.
        /// </summary>
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define o Id do usuário associado ao médico.
        /// </summary>
        [Required(ErrorMessage = "O Id do usuário é um campo obrigatório")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Obtém ou define a referência ao usuário associado ao médico.
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        /// <summary>
        /// Obtém ou define o Id da especialidade do médico.
        /// </summary>
        [Required(ErrorMessage = "O Id da especialidade é um campo obrigatório")]
        public Guid IdEspecialidade { get; set; }

        /// <summary>
        /// Obtém ou define a referência à especialidade do médico.
        /// </summary>
        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        /// <summary>
        /// Obtém ou define o Id da clínica onde o médico atua.
        /// </summary>
        [Required(ErrorMessage = "O Id da clínica é um campo obrigatório")]
        public Guid IdClinica { get; set; }

        /// <summary>
        /// Obtém ou define a referência à clínica onde o médico atua.
        /// </summary>
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        /// <summary>
        /// Obtém ou define o nome do médico.
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        public string? Nome { get; set; }

        /// <summary>
        /// Obtém ou define o CRM (Conselho Regional de Medicina) do médico.
        /// </summary>
        [Column(TypeName = "CHAR(7)")]
        [Required(ErrorMessage = "O CRM é um campo obrigatório")]
        public string? CRM { get; set; }
    }
}
