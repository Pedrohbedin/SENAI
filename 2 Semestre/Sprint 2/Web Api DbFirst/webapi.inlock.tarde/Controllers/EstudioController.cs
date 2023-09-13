using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interface;
using webapi.inlock.tarde.Repositorys;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository = new EstudioRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
        [HttpGet("BuscarPorId")]

        public IActionResult BuscarPorId(Guid Id) 
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(Id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("Cadastrar")]

        public IActionResult Cadastrar(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPut("Atualizar")]
        
        public IActionResult Atualizar(Guid Id, Estudio estudio)
        {
            try
            {
                _estudioRepository.Atualizar(Id, estudio);
                return Ok("Objeto atualizado com sucesso");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("Deletar")]

        public IActionResult Deletar(Guid Id)
        {
            try
            {
                _estudioRepository.Deletar(Id);

                return Ok();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarComJogos")]

        public IActionResult ListarComJogos()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
