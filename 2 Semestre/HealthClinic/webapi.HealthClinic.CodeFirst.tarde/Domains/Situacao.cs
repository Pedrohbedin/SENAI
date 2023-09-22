using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    public class Situacao
    {
        [Key]
        public Guid idSituacao { get; set; } = Guid.NewGuid();
        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação é um campo obrigatório")]
        public bool situacao { get; set; }
    }
}
