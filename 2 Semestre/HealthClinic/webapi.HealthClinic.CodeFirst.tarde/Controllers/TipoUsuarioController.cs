using Microsoft.AspNetCore.Mvc;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável por operações relacionadas a TipoUsuario.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tiposUsuarioRepository;

        public TipoUsuarioController()
        {
            _tiposUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Método HTTP POST para cadastrar um novo TipoUsuario.
        /// </summary>
        /// <param name="titulo">O título do TipoUsuario a ser cadastrado.</param>
        /// <returns>Um status de sucesso (201 - Created) após o cadastro bem-sucedido.</returns>
        [HttpPost]
        public IActionResult Cadastrar(string titulo)
        {
            try
            {
                var tipoUsuario = new TipoUsuario { Titulo = titulo };
                _tiposUsuarioRepository.Cadastrar(tipoUsuario);

                // Retorna um status de sucesso (201 - Created) após o cadastro bem-sucedido.
                return StatusCode(201);
            }
            catch (Exception e)
            {
                // Retorna uma resposta de erro BadRequest com a mensagem de exceção em caso de erro.
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Método HTTP GET para listar todos os tipos de usuário.
        /// </summary>
        /// <returns>Uma resposta OK com a lista de tipos de usuário do repositório.</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                // Retorna uma resposta OK com a lista de tipos de usuário do repositório.
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                // Retorna uma resposta de erro BadRequest com a mensagem de exceção em caso de erro.
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Método HTTP DELETE para deletar um TipoUsuario pelo seu Id.
        /// </summary>
        /// <param name="Id">O Id do TipoUsuario a ser deletado.</param>
        /// <returns>Um status OK após a exclusão bem-sucedida.</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(Guid Id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(Id);

                // Retorna um status OK após a exclusão bem-sucedida.
                return Ok();
            }
            catch (Exception)
            {
                // Em caso de erro, lança a exceção para a camada superior.
                throw;
            }
        }

        /// <summary>
        /// Método HTTP PUT para atualizar um TipoUsuario pelo seu Id.
        /// </summary>
        /// <param name="tipoUsuario">Os dados do TipoUsuario a serem atualizados.</param>
        /// <param name="id">O Id do TipoUsuario a ser atualizado.</param>
        /// <returns>Um status OK após a atualização bem-sucedida.</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(TipoUsuario tipoUsuario, Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(tipoUsuario, id);

                // Retorna um status OK após a atualização bem-sucedida.
                return Ok();
            }
            catch (Exception)
            {
                // Em caso de erro, lança a exceção para a camada superior.
                throw;
            }
        }
    }
}