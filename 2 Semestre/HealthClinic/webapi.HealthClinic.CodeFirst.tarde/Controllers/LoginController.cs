using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações de autenticação e geração de tokens JWT.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Endpoint para autenticação de usuário e geração de token JWT.
        /// </summary>
        /// <param name="email">O email do usuário.</param>
        /// <param name="senha">A senha do usuário.</param>
        /// <returns>Um token JWT válido por um período limitado.</returns>
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            try
            {

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, email!.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(ClaimTypes.Role, _usuarioRepository.BuscarPorEmailESenha(email, senha).TipoUsuario.Titulo.Trim())
                };

                var chaveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HealthClinic-chave-autenticacao-webapi-dev"));

                var credenciais = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "webapi.HealthClinic.CodeFirst.tarde",
                    audience: "webapi.HealthClinic.CodeFirst.tarde",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: credenciais
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}