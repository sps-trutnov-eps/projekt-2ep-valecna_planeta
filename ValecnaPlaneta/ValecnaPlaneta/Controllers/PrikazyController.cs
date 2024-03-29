﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValecnaPlaneta.Data;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta.Controllers
{
    public class PrikazyController : Controller
    {
        private Engine _engine;

        public PrikazyController(NasDbContext dbContext)
        {
            _engine = new Engine(dbContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            int poziceHrace = _engine.KdeJsem(HttpContext.Session.GetString("uzivatel"));
            return View(poziceHrace);
        }

        [HttpPost]
        public IActionResult Index(string zadanyPrikaz, string poznamkyVelitele)
        {
            ViewData["notepad"] = poznamkyVelitele;
            string? uzivatel = HttpContext.Session.GetString("uzivatel");
            string? hra = HttpContext.Session.GetString("hra");

            if (!_engine.Zije(uzivatel))
            {
                _engine.SmazatHrace(uzivatel);
                return Redirect("/Prikazy/Konec/");
            }

            zadanyPrikaz = zadanyPrikaz.Trim().ToLower();

            if (zadanyPrikaz == "income")
            {
                int hodnota = _engine.Prijem(uzivatel);
                ViewData["message"] = hodnota.ToString();
                return View();
            }

            else if (zadanyPrikaz == "capital")
            {
                int hodnota = _engine.Kapital(uzivatel);
                ViewData["message"] = hodnota.ToString();
                return View();
            }

            else if (zadanyPrikaz == "help")
            {
                ViewData["message"] = $"Available commands: HELP, INCOME, CAPITAL, SEND [soldier|scout|miner|infiltrator] <sector number> (Pricing: Soldier {_engine.cenaVojaka}, Scout {_engine.cenaScouta}, Miner {_engine.cenaTezebniJednotky}, Infiltrator {_engine.cenaInfiltratora})";
                return View();
            }
            else if (!zadanyPrikaz.Contains(" "))
            { 
                ViewData["message"] = "Wrong syntax. Write Help for more information.";
                return View();
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string[] slovaVPrikazu = zadanyPrikaz.Split(' ');
            zadanyPrikaz = (slovaVPrikazu[0] + " " + slovaVPrikazu[1]);

            int cislo;
            if (slovaVPrikazu.Length < 3 || !int.TryParse(slovaVPrikazu[2], out cislo))
            {
                ViewData["message"] = "Wrong syntax. Write Help for more information.";
                return View();
            }

            if (zadanyPrikaz == "send scout")
            {
                Stav? policko = _engine.PoslatScouta(cislo, uzivatel, hra);

                string zprava = "";
                if (policko == Stav.Zabrano)
                    zprava = "This field is taken!";
                else if (policko == Stav.Prazdno)
                    zprava = "This field is empty!";
                else if (policko == Stav.Bunkr)
                    zprava = "There is a bunker on this field!";
                ViewData["message"] = zprava;

                return View();
            }

            else if (zadanyPrikaz == "send soldier")
            {
                bool uspech = _engine.PoslatVojaka(cislo, uzivatel, hra);

                if (uspech)
                    return View();
                else
                {
                    ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                    return View();
                }
            }

            else if (zadanyPrikaz == "send infiltrator")
            {
                bool uspech = _engine.PoslatInfiltratora(cislo, uzivatel, hra);

                if (uspech)
                    return View();
                else
                {
                    ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                    return View();
                }

            }
            else if (zadanyPrikaz == "send miner") 
            {
                bool uspech = _engine.PoslatTezebniJednotku(cislo, uzivatel, hra);

                if (uspech)
                    return View();
                else
                {
                    ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                    return View();
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            else
            {
                ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                return View();
            }
        }

        public IActionResult Konec()
        { 
            return View(); 
        }
    }
}
