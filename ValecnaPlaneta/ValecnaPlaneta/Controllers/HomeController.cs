using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("uzivatel", "pomelo");
            HttpContext.Session.SetInt32("hra", 6);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Moje() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}