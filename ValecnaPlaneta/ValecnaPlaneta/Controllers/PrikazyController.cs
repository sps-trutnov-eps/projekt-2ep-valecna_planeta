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

            else if (zadanyPrikaz == "send scout")
                return Redirect("/Engine/Posli");

            else if (zadanyPrikaz == "send soldier")
                return Redirect("/Engine/Posli");

            else if (zadanyPrikaz == "send infiltrator")
                return Redirect("/Engine/Posli");

            else if (zadanyPrikaz == "capital")
                return Redirect("/Engine/Kapital");

            else if (zadanyPrikaz == "help")
            {
                ViewData["help"] = "Available commands: Help, Income, Capital, Send + soldier/scout/infiltrator/";
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
