using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : Controller
    {
        private IPresencaEventoRepository _PresencaEventoRepository;

        public PresencaEventoController()
        {
            _PresencaEventoRepository = new PresencaEventoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(PresencaEvento presencaEvento)
        {
            try
            {
                _PresencaEventoRepository.Cadastrar(presencaEvento);

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
                return Ok(_PresencaEventoRepository.Listar());
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
                return Ok(_PresencaEventoRepository.BuscarPorId(Id));
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
                _PresencaEventoRepository.Deletar(Id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Guid Id, PresencaEvento presencaEvento)
        {
            try
            {
                _PresencaEventoRepository.Atualizar(Id, presencaEvento);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
