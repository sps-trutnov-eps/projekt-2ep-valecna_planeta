using Microsoft.AspNetCore.Mvc;
using ValecnaPlaneta.Data;
using ValecnaPlaneta.Data;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta.Controllers
{
    public class EngineController : Controller
    {
        private NasDbContext naseData;

        public EngineController(NasDbContext databaze)
        {
            naseData = databaze;
        }
        public string PoslatScouta(int id)
        {
            throw new NotImplementedException();
        }
        public void PoslatTezebniJednotku(int id) 
        {
            throw new NotImplementedException();
        }
        public void PoslatVojaka(int id) 
        {
            throw new NotImplementedException();
        }
        public void PoslatInfiltratora(int id)
        {
            throw new NotImplementedException();
        }
        public int Kapital(string tokenHrace)
        {
            throw new NotImplementedException();
        }
        public int Prijem()
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
