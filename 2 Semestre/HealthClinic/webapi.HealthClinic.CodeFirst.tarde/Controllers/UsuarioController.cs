using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;
using webapi.HealthClinic.CodeFirst.tarde.Repository;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas a usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UsuarioController"/>.
        /// </summary>
        /// <param name="">O repositório de usuários.</param>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuario">Os dados do usuário a ser cadastrado.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca um usuário pelo seu email e senha.
        /// </summary>
        /// <param name="email">O email do usuário.</param>
        /// <param name="senha">A senha do usuário.</param>
        /// <returns>Os dados do usuário encontrado, excluindo a senha.</returns>
        [HttpGet]
        public IActionResult BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);

                if (usuarioBuscado != null)
                {
                    var usuarioDTO = new Usuario
                    {
                        Email = usuarioBuscado.Email,
                        IdTipoUsuario = usuarioBuscado.IdTipoUsuario,
                        IdUsuario = usuarioBuscado.IdUsuario,
                        TipoUsuario = usuarioBuscado.TipoUsuario
                        // Atribua outros campos ao objeto DTO, exceto a senha
                    };
                    return Ok(usuarioDTO);
                }
                return null!;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um usuário pelo seu Id.
        /// </summary>
        /// <param name="usuario">Os novos dados do usuário.</param>
        /// <param name="id">O Id do usuário a ser atualizado.</param>
        /// <returns>Uma resposta de sucesso.</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Usuario usuario, Guid id)
        {
            try
            {
                _usuarioRepository.Atualizar(usuario, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
