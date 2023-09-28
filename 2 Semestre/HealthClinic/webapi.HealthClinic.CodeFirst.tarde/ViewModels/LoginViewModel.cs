using System.ComponentModel.DataAnnotations;

namespace webapi.HealthClinic.CodeFirst.tarde.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório!!!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!!!")]
        public string? Senha { get; set; }
    }
}
