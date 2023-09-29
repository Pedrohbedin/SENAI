using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa um paciente.
    /// </summary>
    [Table(nameof(Paciente))]
    [Microsoft.EntityFrameworkCore.Index(nameof(CEP), IsUnique = true)]
    public class Paciente
    {
        /// <summary>
        /// Obtém ou define o Id do paciente.
        /// </summary>
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define o Id do usuário associado ao paciente.
        /// </summary>
        [Required(ErrorMessage = "O Id do Usuário é um campo obrigatório")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Obtém ou define a referência ao usuário associado ao paciente.
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        /// <summary>
        /// Obtém ou define o nome do paciente.
        /// </summary>
        [Column(TypeName = "VARCHAR(110)")]
        [Required(ErrorMessage = "O nome do usuário é um campo obrigatório")]
        public string? Nome { get; set; }

        /// <summary>
        /// Obtém ou define a data de nascimento do paciente.
        /// </summary>
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de nascimento do usuário é um campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Obtém ou define o telefone do paciente.
        /// </summary>
        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O telefone do usuário é um campo obrigatório")]
        public string? Telefone { get; set; }

        /// <summary>
        /// Obtém ou define o RG do paciente.
        /// </summary>
        [Column(TypeName = "CHAR(9)")]
        [Required(ErrorMessage = "O RG é um campo obrigatório")]
        public string? RG { get; set; }

        /// <summary>
        /// Obtém ou define o CPF do paciente.
        /// </summary>
        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O CPF do usuário é um campo obrigatório")]
        public string? CPF { get; set; }

        /// <summary>
        /// Obtém ou define o CEP do paciente.
        /// </summary>
        [Column(TypeName = "CHAR(8)")]
        [Required(ErrorMessage = "O CEP do usuário é um campo obrigatório")]
        public string? CEP { get; set; }

        /// <summary>
        /// Obtém ou define o endereço do paciente.
        /// </summary>
        [Column(TypeName = "VARCHAR(110)")]
        [Required(ErrorMessage = "O Endereço do usuário é um campo obrigatório")]
        public string? Endereco { get; set; }
    }
}
