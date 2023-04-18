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

            if (zadanyPrikaz == "prijem" || zadanyPrikaz == "Prijem")
                return RedirectToAction("/Engine/Prijem");

            else if (zadanyPrikaz == "posli" || zadanyPrikaz == "Posli")
                return RedirectToAction("/Engine/Posli");

            if (zadanyPrikaz != "prijem" || zadanyPrikaz != "Prijem")
                return View("blbej");
            throw new NotImplementedException();
        }
    }
}
