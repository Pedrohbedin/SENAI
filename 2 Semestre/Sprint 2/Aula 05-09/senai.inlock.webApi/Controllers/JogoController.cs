using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.Data;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "Administrador , Comum")]
    public class JogoController : Controller
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            try
            {
                List<JogoDomain> ListaJogos = _jogoRepository.ListarTodos();

                return Ok(ListaJogos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
