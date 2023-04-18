using Microsoft.AspNetCore.Mvc;

namespace ValecnaPlaneta.Controllers
{
    public class PrikazyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
