using Microsoft.AspNetCore.Mvc;
using System;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a pacientes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="paciente">Os dados do paciente a ser cadastrado.</param>
        /// <returns>Os dados do paciente cadastrado.</returns>
        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar paciente: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um paciente pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do paciente a ser deletado.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar paciente: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista todos os pacientes.
        /// </summary>
        /// <returns>Uma lista de pacientes.</returns>
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar pacientes: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza os dados de um paciente pelo seu Id.
        /// </summary>
        /// <param name="paciente">Os novos dados do paciente.</param>
        /// <param name="id">O Id do paciente a ser atualizado.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Paciente paciente, Guid id)
        {
            try
            {
                _pacienteRepository.Atualizar(paciente, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar paciente: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca um paciente pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do paciente a ser buscado.</param>
        /// <returns>Os dados do paciente encontrado.</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                var pacienteAchado = _pacienteRepository.BuscarPorId(id);
                return Ok(pacienteAchado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar paciente: {ex.Message}");
            }
        }
    }
}
