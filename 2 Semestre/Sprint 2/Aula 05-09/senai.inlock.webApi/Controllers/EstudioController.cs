using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : Controller
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Administrador , Comum")]

        public IActionResult ListarTodos()
        {
            try
            {
                List<EstudioDomain> ListaF = _estudioRepository.ListarTodos();

                return Ok(ListaF);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
