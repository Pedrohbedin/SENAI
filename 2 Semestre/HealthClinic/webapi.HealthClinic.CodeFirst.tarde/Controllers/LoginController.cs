using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _contextAccessor;

        public LoginController() => _contextAccessor = new UsuarioRepository();

        [HttpPost]

        public IActionResult Login(string email, string senha)
        {
            try
            {
                Usuario usuarioAchado = _contextAccessor.BuscarPorEmailESenha(email!, senha!);

                var claims = new[]
                {
                //formato da Claim(tipo, valor)
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, email!.ToString()),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, usuarioAchado.TipoUsuario!.Titulo!)
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HealthClinic-chave-autenticacao-webapi-dev"));

                //Definir as credenciais do token(Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.HealthClinic.CodeFirst.tarde",

                    audience: "webapi.HealthClinic.CodeFirst.tarde",

                    //Dados definidos nas claims 
                    claims: claims,

                    //tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //credencias do token
                    signingCredentials: creds
                );
                //retornar o token 

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}