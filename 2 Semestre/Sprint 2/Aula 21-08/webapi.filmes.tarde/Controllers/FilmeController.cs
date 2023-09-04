using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _FilmeRepository { get; set; }

        public FilmeController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        [HttpGet]
        [Authorize]

        public IActionResult ListarTodos()
        {
            try
            {
                // Chama o método ListarTodos() do repositório de filmes para obter a lista de filmes.
                List<FilmeDomain> ListaFilmes = _FilmeRepository.ListarTodos();

                // Retorna uma resposta HTTP 200 (OK) com a lista de filmes como corpo da resposta.
                return Ok(ListaFilmes);
            }
            catch (Exception error)
            {
                // Caso ocorra uma exceção durante a execução do bloco try, retorna uma resposta HTTP 400 (BadRequest)
                // com a mensagem de erro da exceção como corpo da resposta.
                return BadRequest(error.Message);
            }
        }

        [HttpGet("GetById")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _FilmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("O filme buscado não foi encontrado!");
                }

                return StatusCode(226, filmeBuscado);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPost]

        public IActionResult Cadastrar(FilmeDomain filme)
        {
            try
            {
                _FilmeRepository.Cadastrar(filme);

                return Created("Objeto Criado", filme);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPut("AtualizarIdCorpo")]

        public IActionResult AtualizarIdCorpo(FilmeDomain filme)
        {
            try
            {
                _FilmeRepository.AtualizarIdCorpo(filme);

                return Ok(filme);
            }
            catch (Exception error)
            {

                return BadRequest($"Ocorreu um erro ao atualizar o filme: {error.Message}"); 
            }
        }

        [HttpPut("AtualizarIdURL/{id}")]

        public IActionResult AtualizarIdURL(int id, FilmeDomain filme)
        {
            try
            {
                _FilmeRepository.AtualizarIdURL(id, filme);
                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao atualizar o filme: {ex.Message}");
            }
        }

        [HttpDelete]

        public IActionResult Deletar(int id)
        {
            try
            {
                _FilmeRepository.Deletar(id);
                return Ok();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
