using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a situações.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SituacaoController : Controller
    {
        private readonly ISituacaoRepository _situacaoRepository;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="SituacaoController"/>.
        /// </summary>
        /// <param name="">O repositório de situações.</param>
        public SituacaoController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        /// <summary>
        /// Cadastra uma nova situação.
        /// </summary>
        /// <param name="situacao">Os dados da situação a ser cadastrada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPost]
        public IActionResult Cadastrar(Situacao situacao)
        {
            try
            {
                _situacaoRepository.Cadastrar(situacao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar situação: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta uma situação pelo seu Id.
        /// </summary>
        /// <param name="id">O Id da situação a ser deletada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _situacaoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar situação: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista todas as situações.
        /// </summary>
        /// <returns>Uma lista de situações.</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Situacao> situacoes = _situacaoRepository.Listar();
                return Ok(situacoes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar situações: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca uma situação pelo seu Id.
        /// </summary>
        /// <param name="id">O Id da situação a ser buscada.</param>
        /// <returns>Os dados da situação encontrada.</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                var situacaoAchada = _situacaoRepository.BuscarPorId(id);
                return Ok(situacaoAchada);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar situação: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza os dados de uma situação pelo seu Id.
        /// </summary>
        /// <param name="situacao">Os novos dados da situação.</param>
        /// <param name="id">O Id da situação a ser atualizada.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Situacao situacao, Guid id)
        {
            try
            {
                _situacaoRepository.Atualizar(situacao, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar situação: {ex.Message}");
            }
        }
    }
}
