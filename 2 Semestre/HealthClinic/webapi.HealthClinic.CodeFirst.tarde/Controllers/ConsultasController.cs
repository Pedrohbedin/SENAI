using Microsoft.AspNetCore.Mvc;

namespace webapi.HealthClinic.CodeFirst.tarde.Controllers
{
    public class ConsultasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
