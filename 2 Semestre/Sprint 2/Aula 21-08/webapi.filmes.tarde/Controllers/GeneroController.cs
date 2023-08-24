using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    /// <summary>
    /// Define que é um controlador de API 
    /// </summary>
    [ApiController]
    /// <summary>
    /// Define que o tipo de resposta da API é json 
    /// </summary>
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Método construtor criado a partir do coma "ctor"
        /// Sempre que for chamado executará oque estiver dentro
        /// </summary>
        public GeneroController()
        {
            /// <summary>
            /// Instancia do objeto _generoRepository para que aja referência aos métodos no repositório 
            /// </summary>

            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método de listar os generos
        /// </summary>
        /// <returns>Lista de gêneros e um status code</returns>

        [HttpGet]
        public IActionResult Get() 
        {

            try
            {
                //Cria uma lista para receber os gêneros
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //Retorna o status code 200(Ok) e a lista de gêneros no formato JSON
                return Ok(ListaGeneros);

            }
            catch (Exception error)
            {

                //Retorna um status code 400(BadRequest) e a mensagem de erro 
                return BadRequest(error.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {

                _generoRepository.Cadastrar(novoGenero);

           
                return Created("Objeto criado", novoGenero);
            }
            catch (Exception error)
            { 
            
                //Retorna um status code 400(BadRequest) e a mensagem de erro 
                return BadRequest(error.Message);
            }
        }

        [HttpDelete]

        public IActionResult Delete(int id) 
        {
            try
            {

                _generoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
