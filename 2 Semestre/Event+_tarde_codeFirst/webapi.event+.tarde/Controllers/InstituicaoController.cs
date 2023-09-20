using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : Controller
    {
        private IInstituicaoRepository _InstituicaoRepository;

        public InstituicaoController()
        {
            _InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Instituicao instituicao)
        {
            try
            {
                _InstituicaoRepository.Cadastrar(instituicao);

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
                return Ok(_InstituicaoRepository.Listar());
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
                return Ok(_InstituicaoRepository.BuscarPorId(Id));
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
                _InstituicaoRepository.Deletar(Id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Guid Id, Instituicao instituicao)
        {
            try
            {
                _InstituicaoRepository.Atualizar(Id, instituicao);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
