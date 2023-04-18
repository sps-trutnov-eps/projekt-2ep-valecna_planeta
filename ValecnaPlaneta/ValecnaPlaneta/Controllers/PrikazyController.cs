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
            throw new NotImplementedException();
        }
    }
}
