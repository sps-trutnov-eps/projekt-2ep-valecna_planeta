using Microsoft.AspNetCore.Mvc;

namespace ValecnaPlaneta.Controllers
{
        public class LobbyController : Controller
    {
        [HttpGet]
        public IActionResult Vytvor()
        {          
            return View();
        }

        [HttpPost]
        public IActionResult Vytvor(string jmeno, string heslo)
        {

            return View();
        }
        [HttpGet]
        public IActionResult Menu()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Vyber()
        {
            return View();
        }
    }
}
