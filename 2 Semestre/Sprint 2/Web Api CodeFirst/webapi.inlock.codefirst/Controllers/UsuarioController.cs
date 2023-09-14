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

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok(usuario);
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

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
