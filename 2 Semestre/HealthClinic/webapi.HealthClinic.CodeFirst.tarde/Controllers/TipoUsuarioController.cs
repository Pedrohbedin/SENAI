using Microsoft.AspNetCore.Mvc;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tiposUsuarioRepository;

        public TipoUsuarioController()
        {
            _tiposUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(string titulo)
        {
            TipoUsuario tipoUsuario = new TipoUsuario();

            tipoUsuario.Titulo = titulo;
            try
            {
                _tiposUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(Guid Id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(Id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
