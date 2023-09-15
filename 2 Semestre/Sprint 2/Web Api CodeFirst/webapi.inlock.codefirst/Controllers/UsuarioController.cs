using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repository;

namespace webapi.inlock.codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        private ITiposUsuarioRepository _tiposUsuario;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
            _tiposUsuario = new TiposUsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                usuario.TipoUsuario = _tiposUsuario.BuscarPorId(usuario.IdTipoUsuario);
                if (usuario.TipoUsuario != null)
                {
                    _usuarioRepository.Cadastrar(usuario);
                    return Ok(usuario);
                }
                else
                {
                    return StatusCode(401, "Tipo de usuario não encontrado");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]

        public IActionResult GetByEmailAndPassword(string Email, string senha) 
        {
            try
            {
                Usuario usuarioAchado = _usuarioRepository.BuscarUsuario(Email, senha);
                if (usuarioAchado != null)
                {
                    return Ok(usuarioAchado);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
