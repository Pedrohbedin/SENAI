using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : Controller
    {
        private IEventoRepository _EventoRepository;

        public EventoController()
        {
            _EventoRepository = new EventoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Evento evento)
        {
            try
            {
                _EventoRepository.Cadastrar(evento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("Listar")]
        [Authorize(Roles = "Aluno, Administrador")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_EventoRepository.Listar());
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
                return Ok(_EventoRepository.BuscarPorId(Id));
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
                _EventoRepository.Deletar(Id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]

        public IActionResult Atualizar(Guid Id, Evento evento)
        {
            try
            {
                _EventoRepository.Atualizar(Id, evento);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
