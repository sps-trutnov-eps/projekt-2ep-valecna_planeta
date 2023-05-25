using Microsoft.AspNetCore.Mvc;
using ValecnaPlaneta.Data;
using ValecnaPlaneta.Data;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta.Controllers
{
    public class Engine : Controller
    {
        private NasDbContext naseData;

        public Engine(NasDbContext databaze)
        {
            naseData = databaze;
        }
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

        public IActionResult PridatPole(int id)
        {
            Policko novePole = new Policko();
            naseData.Policka.Add(novePole); 
            return RedirectToAction("Moje", "Home");
        }
    }
}
