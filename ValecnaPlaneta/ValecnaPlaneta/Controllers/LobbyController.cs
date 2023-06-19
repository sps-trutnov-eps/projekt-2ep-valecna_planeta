using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ValecnaPlaneta.Data;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta.Controllers
{
    public class LobbyController : Controller
    {
        private Engine _engine;
        private NasDbContext _context;

        public LobbyController(NasDbContext dbContext) 
        {
            _context = dbContext;
            _engine = new Engine(_context);
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
            List<Hra> hry = _context.Hry.ToList();

            return View(hry);
        }

        [HttpGet]
        public IActionResult Heslo()
        {
            return View();
        }
    }
}
