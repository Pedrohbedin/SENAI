using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    /// <summary>
    /// Representa a situação de alguma entidade.
    /// </summary>
    public class Situacao
    {
        /// <summary>
        /// Obtém ou define o Id da situação.
        /// </summary>
        [Key]
        public Guid IdSituacao { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Obtém ou define a situação.
        /// </summary>
        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação é um campo obrigatório")]
        public bool SituacaoValor { get; set; }
    }
}
