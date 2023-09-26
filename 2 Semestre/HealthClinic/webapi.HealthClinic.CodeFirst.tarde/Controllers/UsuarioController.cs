using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
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
        public IActionResult BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.BuscarPorEmailESenha(email, senha);

                if (usuarioBuscado != null)
                {
                    var usuarioDTO = new Usuario
                    {
                        Email = usuarioBuscado.Email,
                        IdTipoUsuario = usuarioBuscado.IdTipoUsuario,
                        IdUsuario = usuarioBuscado.IdUsuario,
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
