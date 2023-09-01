using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController() 
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
               UsuarioDomain UsuarioAchado = _UsuarioRepository.Login(usuario.Email, usuario.Senha);

                if (UsuarioAchado == null)
                {
                    return NotFound("Email ou senha incorretos");
                }
                //Caso encontro o usuário buscado irá proseeguir para criação do token

                //1 Definição as informações que serão fornecidos no token

                var claims = new[]
                {
                    //formato da Claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioAchado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioAchado.Email),
                    new Claim(ClaimTypes.Role, UsuarioAchado.Permissao),
                    new Claim("Claim personalizada", "Valor personalizado")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //Definir as credenciais do token(Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.filmes.tarde",

                    audience: "webapi.filmes.tarde",

                    //Dados definidos nas claims 
                    claims : claims,

                    //tempo de expiração
                    expires : DateTime.Now.AddMinutes(5),

                    //credencias do token
                    signingCredentials : creds
                ) ;
                //retornar o token 

                return Ok(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
