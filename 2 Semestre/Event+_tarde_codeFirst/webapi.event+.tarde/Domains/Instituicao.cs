using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Instituicao))]
    [Microsoft.EntityFrameworkCore.Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório!!!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(110)")]
        [Required(ErrorMessage = "O Endenreço é um campo obrigatório!!!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O nome fantasia é um campo obrigatório")]
        public string? NomeFantasia { get; set; }
    }
}
