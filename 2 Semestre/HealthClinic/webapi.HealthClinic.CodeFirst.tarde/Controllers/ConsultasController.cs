using Microsoft.AspNetCore.Mvc;
using System;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a consultas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ConsultasController"/>.
        /// </summary>
        /// <param name="consultaRepository">O repositório de consultas.</param>
        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Agenda uma nova consulta.
        /// </summary>
        /// <param name="consulta">Os dados da consulta a ser agendada.</param>
        /// <returns>Os dados da consulta agendada.</returns>
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

        /// <summary>
        /// Cancela uma consulta pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id da consulta a ser cancelada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpDelete("{Id}")]
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

        /// <summary>
        /// Inclui uma descrição em uma consulta pelo seu Id.
        /// </summary>
        /// <param name="descricao">A descrição a ser incluída na consulta.</param>
        /// <param name="Id">O Id da consulta.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPut("{Id}")]
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

        /// <summary>
        /// Lista as consultas de um usuário pelo seu Id.
        /// </summary>
        /// <param name="IdUsuario">O Id do usuário.</param>
        /// <returns>Uma lista de consultas do usuário.</returns>
        [HttpGet("ListarPorUsuario")]
        public IActionResult ListarPorUsuario(Guid IdUsuario)
        {
            try
            {
                var consultas = _consultaRepository.ListarPorUsuario(IdUsuario);
                return Ok(consultas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca uma consulta pelo seu Id.
        /// </summary>
        /// <param name="id">O Id da consulta.</param>
        /// <returns>Os dados da consulta encontrada.</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                var consultaAchada = _consultaRepository.BuscarPorId(id);
                return Ok(consultaAchada);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
