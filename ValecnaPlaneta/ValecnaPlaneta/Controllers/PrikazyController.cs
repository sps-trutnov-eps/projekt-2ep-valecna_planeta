using Microsoft.AspNetCore.Mvc;

namespace ValecnaPlaneta.Controllers
{
    public class PrikazyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string zadanyPrikaz)
        {
            if (zadanyPrikaz == null || zadanyPrikaz.Trim() == "")
                return View();

            zadanyPrikaz = zadanyPrikaz.Trim().ToLower();

            if (zadanyPrikaz == "income")
                return Redirect("/Engine/Prijem");

            else if (zadanyPrikaz == "capital")
                return Redirect("/Engine/Kapital");

            else if (zadanyPrikaz == "help")
            {
                ViewData["help"] = "Available commands: Help, Income, Capital, Send + soldier/scout/miner/infiltrator + number of position";
                return View();
            }

            string[] slovaVPrikazu = zadanyPrikaz.Split(' ');
            zadanyPrikaz = (slovaVPrikazu[0] + " " + slovaVPrikazu[1]);

            int cislo;
            if (slovaVPrikazu.Length < 3 || !int.TryParse(slovaVPrikazu[2],out cislo))
            { 
                ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                return View();
            }

            if (zadanyPrikaz == "send scout")
                return Redirect("/Engine/PoslatScouta/" + slovaVPrikazu[2]);

            else if (zadanyPrikaz == "send soldier")
                return Redirect("/Engine/PoslatVojaka/" + slovaVPrikazu[2]);

            else if (zadanyPrikaz == "send infiltrator")
                return Redirect("/Engine/PoslatInfiltratora/" + slovaVPrikazu[2]);

            else if (zadanyPrikaz == "send miner")
                return Redirect("/Engine/PoslatTezebniJednotku/" + slovaVPrikazu[2]);

            else
            {
                ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                return View();
            }
        }

    }
}
