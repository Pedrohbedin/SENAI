using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : Controller
    {
        private IPresencasEventoRepository _presencasEventoRepository { get; set; }

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                  return Ok(_presencasEventoRepository.Listar());
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(PresencasEvento presencasEvento)
        {
            try
            {
                _presencasEventoRepository.Inscrever(presencasEvento);

                return StatusCode(201);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ListarMinhas/{id}")]
        public IActionResult GetMyList(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMinhas(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
