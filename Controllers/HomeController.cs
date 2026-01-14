using Microsoft.AspNetCore.Mvc;

namespace FiringLineWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
    }
}
