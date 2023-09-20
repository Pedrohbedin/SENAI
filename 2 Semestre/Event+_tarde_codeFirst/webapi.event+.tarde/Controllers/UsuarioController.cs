using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository ctx { get; set; }
        
        public UsuarioController()
        {
            ctx = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                ctx.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Aluno, Administrador")]
        public IActionResult BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.BuscarPorEmailESenha(email, senha);

                if (usuarioBuscado != null)
                {
                    var usuarioDTO = new Usuario
                    {
                        Name = usuarioBuscado.Name,
                        Email = usuarioBuscado.Email,
                        IdTipoUsuario = usuarioBuscado.IdTipoUsuario,
                        idUsuario = usuarioBuscado.idUsuario,
                        TipoUsuario = usuarioBuscado.TipoUsuario
                        // Atribua outros campos ao objeto DTO, exceto a senha
                    };
                    return Ok(usuarioDTO);
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
