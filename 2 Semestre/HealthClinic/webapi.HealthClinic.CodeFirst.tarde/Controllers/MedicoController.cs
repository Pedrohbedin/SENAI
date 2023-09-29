using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a médicos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;

        /// <summary>
        /// Construtor que recebe uma instância do repositório de médicos por injeção de dependência.
        /// </summary>
        /// <param name="medicoRepository">Instância do repositório de médicos.</param>
        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Cadastra um novo médico.
        /// </summary>
        /// <param name="medico">Os dados do médico a ser cadastrado.</param>
        /// <returns>Os dados do médico cadastrado.</returns>
        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar médico: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um médico pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do médico a ser deletado.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar médico: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista todos os médicos.
        /// </summary>
        /// <returns>Uma lista de médicos.</returns>
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar médicos: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza os dados de um médico pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do médico a ser atualizado.</param>
        /// <param name="medico">Os novos dados do médico.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(medico, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar médico: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca um médico pelo seu Id.
        /// </summary>
        /// <param name="id">O Id do médico a ser buscado.</param>
        /// <returns>Os dados do médico encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                var medicoAchado = _medicoRepository.BuscarPorId(id);
                return Ok(medicoAchado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar médico por ID: {ex.Message}");
            }
        }
    }
}
