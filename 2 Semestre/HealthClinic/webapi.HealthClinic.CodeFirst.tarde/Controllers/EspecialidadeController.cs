using Microsoft.AspNetCore.Mvc;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : Controller
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }
        [HttpPost]
        public IActionResult Cadastrar(Especialidade especialidade)
        {
            _especialidadeRepository.Cadastrar(especialidade);
            return Ok(especialidade);
        }
        [HttpDelete]
        public IActionResult Deletar(Guid Id)
        {
            _especialidadeRepository.Deletar(Id);
            return Ok();
        }
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_especialidadeRepository.Listar());
        }
    }
}
