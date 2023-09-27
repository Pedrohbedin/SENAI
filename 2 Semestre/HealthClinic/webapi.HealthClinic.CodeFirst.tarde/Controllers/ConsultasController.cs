using Microsoft.AspNetCore.Mvc;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultasController : Controller
    {
        private IConsultaRepository _consultaRepository;

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Agendar(Consultas consulta)
        {
            try
            {
                _consultaRepository.Agendar(consulta);
                return Ok(consulta);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult Cancelar(Guid Id)
        {
            try
            {
                _consultaRepository.Cancelar(Id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult IncluirDescricao(string descricao, Guid Id)
        {
            try
            {
                _consultaRepository.IncluirDescricao(descricao, Id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult ListarPorUsuario(Guid IdUsuario)
        {
            try
            {
                _consultaRepository.ListarPorUsuario(IdUsuario);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
