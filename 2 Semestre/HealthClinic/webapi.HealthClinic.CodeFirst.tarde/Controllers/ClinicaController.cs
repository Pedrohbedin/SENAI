using Microsoft.AspNetCore.Mvc;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : Controller
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }
        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            _clinicaRepository.Cadastrar(clinica);
            return Ok(clinica);
        }
        [HttpDelete]
        public IActionResult Deletar(Guid Id)
        {
            _clinicaRepository.Deletar(Id);
            return Ok();
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_clinicaRepository.Listar());
        }
    }
}
