using Microsoft.AspNetCore.Mvc;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
