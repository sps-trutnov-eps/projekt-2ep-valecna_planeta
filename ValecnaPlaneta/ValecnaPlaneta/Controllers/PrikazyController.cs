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
            {
                string? uzivatel = HttpContext.Session.GetString("uzivatel");

                bool uspech = EngineController.Prijem(uzivatel);

                if (uspech)
                    return View();
                else
                {
                    ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                    return View();
                }
            }

            else if (zadanyPrikaz == "capital")
            {
                int? hra = HttpContext.Session.GetInt32("hra");

                bool uspech = EngineController.Prijem(hra);

                if (uspech)
                    return View();
                else
                {
                    ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                    return View();
                }
            }

            else if (zadanyPrikaz == "help")
            {
                ViewData["help"] = "Available commands: Help, Income, Capital, Send + soldier/scout/miner/infiltrator + number of position";
                return View();
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            string[] slovaVPrikazu = zadanyPrikaz.Split(' ');
            zadanyPrikaz = (slovaVPrikazu[0] + " " + slovaVPrikazu[1]);

            int cislo;
            if (slovaVPrikazu.Length < 3 || !int.TryParse(slovaVPrikazu[2], out cislo))
            {
                ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                return View();
            }

            if (zadanyPrikaz == "send scout")
            {
                string? uzivatel = HttpContext.Session.GetString("uzivatel");
                int? hra = HttpContext.Session.GetInt32("hra");

                bool uspech = EngineController.PoslatScouta(slovaVPrikazu[2], uzivatel, hra);

                if (uspech)
                    return View();
                else
                {
                    ViewData["chyba"] = "Wrong syntax. Write Help for more information.";
                    return View();
                }
            }

            else if (zadanyPrikaz == "send soldier")
            {
                string? uzivatel = HttpContext.Session.GetString("uzivatel");
                int? hra = HttpContext.Session.GetInt32("hra");

                bool uspech = EngineController.PoslatVojaka(slovaVPrikazu[2], uzivatel, hra);

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
                string? uzivatel = HttpContext.Session.GetString("uzivatel");
                int? hra = HttpContext.Session.GetInt32("hra");

                bool uspech = EngineController.PoslatInfiltratora(slovaVPrikazu[2], uzivatel, hra);

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
                string? uzivatel = HttpContext.Session.GetString("uzivatel");
                int? hra = HttpContext.Session.GetInt32("hra");

                bool uspech = EngineController.PoslatTezebniJednotku(slovaVPrikazu[2], uzivatel, hra);

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

    }
}
