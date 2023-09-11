using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : Controller
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpGet("GetById")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                TiposUsuarioDomain tipoUsuarioBuscado = _tiposUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado == null)
                {
                    return NotFound("O tipo de usuario buscado não foi encontrado!");
                }

                return StatusCode(226, tipoUsuarioBuscado);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}
