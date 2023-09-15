using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repository;
using webapi.inlock.codefirst.ViewModels;

namespace webapi.inlock.codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _contextAccessor;
        private ITiposUsuarioRepository _tiposUsuario;

        public LoginController()
        {
            _contextAccessor = new UsuarioRepository();
            _tiposUsuario = new TiposUsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioAchado = _contextAccessor.BuscarUsuario(usuario.Email, usuario.Senha);

                var claims = new[]
                {
                    //formato da Claim(tipo, valor)
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, usuario.Email.ToString()),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, _tiposUsuario.BuscarPorId(usuarioAchado.IdTipoUsuario).Titulo.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlocker-codeFirst-chave-autenticacao-webapi-dev"));

                //Definir as credenciais do token(Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.inlock.codefirst",

                    audience: "webapi.inlock.codefirst",

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
