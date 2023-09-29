using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a especialidades médicas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="especialidadeRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Cadastra uma nova especialidade médica.
        /// </summary>
        /// <param name="especialidade">Os dados da especialidade a ser cadastrada.</param>
        /// <returns>Os dados da especialidade cadastrada.</returns>
        [HttpPost]
        public IActionResult Cadastrar(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar especialidade: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta uma especialidade médica pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da especialidade a ser deletada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(Guid Id)
        {
            try
            {
                _especialidadeRepository.Deletar(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar especialidade: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista todas as especialidades médicas.
        /// </summary>
        /// <returns>Uma lista de especialidades médicas.</returns>
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Especialidade> especialidades = _especialidadeRepository.Listar();
                return Ok(especialidades);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar especialidades: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca uma especialidade médica pelo seu Id.
        /// </summary>
        /// <param name="id">O Id da especialidade a ser buscada.</param>
        /// <returns>Os dados da especialidade encontrada.</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_especialidadeRepository.BuscarPorId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza os dados de uma especialidade médica pelo seu Id.
        /// </summary>
        /// <param name="especialidade">Os novos dados da especialidade.</param>
        /// <param name="id">O Id da especialidade a ser atualizada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPut]
        public IActionResult Atualizar(Especialidade especialidade, Guid id)
        {
            try
            {
                _especialidadeRepository.Atualizar(especialidade, id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
