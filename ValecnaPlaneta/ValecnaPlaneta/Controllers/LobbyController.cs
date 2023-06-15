using Microsoft.AspNetCore.Mvc;
using ValecnaPlaneta.Data;

namespace ValecnaPlaneta.Controllers
{
    public class LobbyController : Controller
    {
        private Engine _engine;
        public LobbyController(NasDbContext dbContext) 
        {
            _engine = new Engine(dbContext);
        }

        [HttpGet]
        public IActionResult Vytvor()
        {          
            return View();
        }

        [HttpPost]
        public IActionResult Vytvor(string jmeno, string? heslo)
        {
            Tuple<string,string> dataDoSessionu = _engine.PridatHru(jmeno, heslo);
            HttpContext.Session.SetString("uzivatel", dataDoSessionu.Item1);
            HttpContext.Session.SetString("hra", dataDoSessionu.Item2);
            return Redirect("/Prikazy/Index/");
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

        [HttpGet]
        public IActionResult Heslo()
        {
            return View();
        }
    }
}
