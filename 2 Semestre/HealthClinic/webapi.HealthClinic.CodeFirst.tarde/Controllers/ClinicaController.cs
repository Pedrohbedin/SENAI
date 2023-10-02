using Microsoft.AspNetCore.Mvc;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas à entidade Clinica.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Cadastra uma nova clínica.
        /// </summary>
        /// <param name="clinica">Os dados da clínica a serem cadastrados.</param>
        /// <returns>Os dados da clínica cadastrada.</returns>
        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            _clinicaRepository.Cadastrar(clinica);
            return Ok(clinica);
        }

        /// <summary>
        /// Deleta uma clínica pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da clínica a ser deletada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(Guid Id)
        {
            _clinicaRepository.Deletar(Id);
            return Ok();
        }

        /// <summary>
        /// Lista todas as clínicas cadastradas.
        /// </summary>
        /// <returns>Uma lista de clínicas.</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_clinicaRepository.Listar());
        }

        /// <summary>
        /// Busca uma clínica pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da clínica a ser buscada.</param>
        /// <returns>Os dados da clínica encontrada.</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(Guid Id)
        {
            return Ok(_clinicaRepository.BuscarPorId(Id));
        }

        /// <summary>
        /// Atualiza os dados de uma clínica pelo seu Id.
        /// </summary>
        /// <param name="clinica">Os novos dados da clínica.</param>
        /// <param name="Id">O Id da clínica a ser atualizada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(Clinica clinica, Guid Id)
        {
            _clinicaRepository.Atualizar(clinica, Id);
            return Ok();
        }
    }
}