using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade ou a tabela genero 
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "O nome do gênero é obrigatório!!")]
        public string?  Nome { get; set; }
        
    }
}
