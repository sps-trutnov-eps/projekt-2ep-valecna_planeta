using Microsoft.AspNetCore.Mvc;

namespace ValecnaPlaneta.Controllers
{
    public class Engine : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PoslatScouta(int id)
        {
            throw new NotImplementedException();
        }
        public IActionResult PoslatTezebniJednotku(int id) 
        {
            throw new NotImplementedException();
        }
        public IActionResult PoslatVojaka(int id) 
        {
            throw new NotImplementedException();
        }
        public IActionResult PoslatInfiltratora(int id)
        {
            throw new NotImplementedException();
        }
        public IActionResult Kapital()
        {
            throw new NotImplementedException();
        }
        public IActionResult Prijem()
        {
            throw new NotImplementedException();
        }
    }
}
