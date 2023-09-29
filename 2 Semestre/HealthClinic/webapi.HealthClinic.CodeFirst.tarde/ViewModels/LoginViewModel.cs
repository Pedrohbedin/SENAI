using System.ComponentModel.DataAnnotations;

namespace webapi.HealthClinic.CodeFirst.tarde.ViewModels
{
    /// <summary>
    /// ViewModel para dados de login.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Obtém ou define o endereço de email do usuário.
        /// </summary>
        [Required(ErrorMessage = "Email obrigatório!!!")]
        public string? Email { get; set; }

        /// <summary>
        /// Obtém ou define a senha do usuário.
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória!!!")]
        public string? Senha { get; set; }
    }
}
