using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]

        public IActionResult Login( string Email, string Senha)
        {
            try
            {
               UsuarioDomain UsuarioAchado = _UsuarioRepository.Login(Email, Senha);

                if (UsuarioAchado == null)
                {
                    return NotFound("Email ou senha incorretos");
                }

                return Ok(UsuarioAchado);

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
