using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve conter no minimo 3 e no máximo 20 caractéries")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}
