using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Domains
{
    [Table(nameof(Products))]
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        public string? Nome { get; set; }
        [Column(TypeName = "DECIMAL")]
        [Required(ErrorMessage = "O preço é um valor obrigátório")]
        public decimal Price { get; set; }
    }
}
