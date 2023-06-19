using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Menu()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Vytvor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Vytvor(string jmeno, string? heslo)
        {
            Tuple<string, string> dataDoSessionu = _engine.PridatHru(jmeno, heslo);

            HttpContext.Session.SetString("uzivatel", dataDoSessionu.Item1);
            HttpContext.Session.SetString("hra", dataDoSessionu.Item2);

            return Redirect("/Prikazy/Index/");
        }

        [HttpGet]
        public IActionResult Vyber()
        {
            List<Hra> hry = _context.Hry.ToList();

            return View(hry);
        }

        [HttpGet]
        public IActionResult Heslo(string tokenHry)
        {
            Hra? hraKamSePripojuji = NacistHruSTokenem(tokenHry);

            return View(hraKamSePripojuji);
        }

        [HttpPost]
        public IActionResult Heslo(string tokenHry, string hesloDoHry)
        {
            Hra? hraKamSePripojuji = NacistHruSTokenem(tokenHry);

            if (hraKamSePripojuji.Heslo != hesloDoHry)
                return Redirect("/Lobby/Heslo?tokenHry=" + tokenHry);

            return PripojitSeDoHry(hraKamSePripojuji);
        }

        public IActionResult Pripojit(string tokenHry)
        {
            Hra? hraKamSePripojuji = NacistHruSTokenem(tokenHry);

            return PripojitSeDoHry(hraKamSePripojuji);
        }

        private IActionResult PripojitSeDoHry(Hra hraKamSePripojuji)
        {
            // pripojeni se do probihajici hry
            Hrac novyHrac = _engine.PridatHrace(hraKamSePripojuji);
            _engine.BunkrAZvetseniMapy(hraKamSePripojuji, novyHrac);

            HttpContext.Session.SetString("uzivatel", novyHrac.Token);
            HttpContext.Session.SetString("hra", hraKamSePripojuji.Token);

            return Redirect("/Prikazy/Index/");
        }

        private Hra NacistHruSTokenem(string tokenHry)
        {
            Hra? nacitanaHra = _context.Hry
                .Where(h => h.Token == tokenHry)
                .FirstOrDefault();

            if (nacitanaHra == null)
                throw new Exception($"Hra s tokenem {tokenHry} neexistuje!");

            return nacitanaHra;
        }
    }
}
