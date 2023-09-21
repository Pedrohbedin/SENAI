using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : Controller
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

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(Guid Id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository.BuscarPorId(Id));
            }
            catch (Exception)
            {

                throw;
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

        [HttpPut]
        public IActionResult Atualizar(Guid Id, string titulo)
        {
            TipoUsuario tipoUsuario = new TipoUsuario();

            tipoUsuario.Titulo = titulo;

            try
            {
                _tiposUsuarioRepository.Atualizar(Id, tipoUsuario);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
