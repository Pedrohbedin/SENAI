using Microsoft.AspNetCore.Mvc;

namespace senai.inlock.webApi_.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
