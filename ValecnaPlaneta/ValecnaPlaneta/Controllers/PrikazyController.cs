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

            zadanyPrikaz = zadanyPrikaz.Trim();

            if (zadanyPrikaz == "help" || zadanyPrikaz == "Help")
                return Redirect("/Engine/Help");

            else if (zadanyPrikaz == "kapitál" || zadanyPrikaz == "Kapitál")
                return Redirect("/Engine/Kapital");

            else
                throw new NotImplementedException();

        }
    }
}
