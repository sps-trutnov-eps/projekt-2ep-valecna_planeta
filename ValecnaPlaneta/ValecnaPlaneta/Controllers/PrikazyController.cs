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

            //string[] slovaVPrikazu = zadanyPrikaz.Split(' ');   
            //zadanyPrikaz = (slovaVPrikazu[0] + " " + slovaVPrikazu[1]);


            if (zadanyPrikaz == "income")
                return Redirect("/Engine/Prijem");

            else if (zadanyPrikaz == "capital")
                return Redirect("/Engine/Kapital");

            else if (zadanyPrikaz == "send scout")
                return Redirect("/Engine/PoslatScouta");

            else if (zadanyPrikaz == "send soldier")
                return Redirect("/Engine/PoslatVojaka");

            else if (zadanyPrikaz == "send infiltrator")
                return Redirect("/Engine/PoslatInfiltratora");

            else if (zadanyPrikaz == "send miner")
                return Redirect("/Engine/PoslatTezebniJednotku");

            else if (zadanyPrikaz == "help")
            {
                ViewData["help"] = "Available commands: Help, Income, Capital, Send + soldier/scout/miner/infiltrator + písmeno políčka a číslo políčka";
                return View();
            }
            else
            {
                ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                return View();
            }
        }

    }
}
