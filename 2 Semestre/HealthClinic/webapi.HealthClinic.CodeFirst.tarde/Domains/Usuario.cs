using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa um usuário do sistema.
    /// </summary>
    [Table(nameof(Usuario))]
    [Microsoft.EntityFrameworkCore.Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        /// <summary>
        /// Obtém ou define o Id do usuário.
        /// </summary>
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define o Id do tipo de usuário associado.
        /// </summary>
        [Required(ErrorMessage = "O Id do tipo de usuário é um campo obrigatório")]
        public Guid IdTipoUsuario { get; set; }

        /// <summary>
        /// Obtém ou define a referência ao tipo de usuário associado.
        /// </summary>
        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }

        /// <summary>
        /// Obtém ou define o email do usuário.
        /// </summary>
        [Column(TypeName = "VARCHAR(110)")]
        [Required(ErrorMessage = "O email é um campo obrigatório")]
        public string? Email { get; set; }

        /// <summary>
        /// Obtém ou define a senha do usuário.
        /// </summary>
        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }
    }
}
