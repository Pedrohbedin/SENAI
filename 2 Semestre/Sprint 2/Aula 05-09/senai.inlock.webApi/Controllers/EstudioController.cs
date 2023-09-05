using Microsoft.AspNetCore.Mvc;

namespace senai.inlock.webApi_.Controllers
{
    public class EstudioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
