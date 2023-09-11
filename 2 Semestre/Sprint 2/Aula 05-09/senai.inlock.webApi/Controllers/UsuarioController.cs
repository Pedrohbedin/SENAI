using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }
        public UsuarioController() => _UsuarioRepository = new UsuarioRepository();

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
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, UsuarioAchado.TipoUsuario.Titulo.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlocker-chave-autenticacao-webapi-dev"));

                //Definir as credenciais do token(Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "senai.inlock.webApi.",

                    audience: "senai.inlock.webApi.",

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
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}

