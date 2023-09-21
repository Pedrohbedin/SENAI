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
    public class TipoEventoController : Controller
    {
        private ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);

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
                return Ok(_tipoEventoRepository.Listar());
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
                return Ok(_tipoEventoRepository.BuscarPorId(Id));
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
                _tipoEventoRepository.Deletar(Id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Guid Id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(Id, tipoEvento);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
