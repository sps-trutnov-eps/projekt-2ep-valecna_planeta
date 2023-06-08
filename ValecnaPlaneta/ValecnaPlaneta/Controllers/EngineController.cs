using Microsoft.AspNetCore.Mvc;
using ValecnaPlaneta.Data;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta.Controllers
{
    public class EngineController : Controller
    {
        private NasDbContext naseData;
        int StartovniPocetPolicek = 50;
        int PridavekPolicek = 20;
        int prijemZaPolicko = 50;

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
            Policko? pracovni = naseData.Policka.Where(p => p.Id == id).FirstOrDefault();
            if (pracovni != null)
            {
                if (pracovni.Stav == Stav.Prazdno)
                    pracovni.Stav = Stav.Zabrano;
            }
            naseData.SaveChanges();
        }
        public void PoslatVojaka(int id) 
        {
            Policko? pracovni = naseData.Policka.Where(p => p.Id == id).FirstOrDefault();
            if (pracovni != null)
            {
                if (pracovni.Stav != Stav.Bunkr)
                {
                    pracovni.Stav = Stav.Prazdno;
                    pracovni.Vlastnik = null;
                }
            }
            naseData.SaveChanges();
        }
        public bool PoslatInfiltratora(int id)
        {
            Policko? pracovni = naseData.Policka.Where(p => p.Id == id).FirstOrDefault();
            if (pracovni != null)
            {
                if (pracovni.Stav == Stav.Bunkr)
                {
                    pracovni.Stav = Stav.Prazdno;
                    Hrac hracSkomirajici = pracovni.Vlastnik;
                    pracovni.Vlastnik = null;
                }
                naseData.SaveChanges();
                return true;   
            }
            else
            {
                return false;
            }
        }
        public int? Kapital(string TokenHrace)
        {
            Hrac? pracovniHrac = naseData.Hraci.Where(h => h.Token == TokenHrace).FirstOrDefault();
            if (pracovniHrac != null)
                return pracovniHrac.Kapital;
            else
                return null;
        }
        public int? Prijem(string TokenHrace)
        {
            Hrac? pracovniHrac = naseData.Hraci.Where(h => h.Token == TokenHrace).FirstOrDefault();
            if (pracovniHrac == null)
            {
                List<Policko> vlastnenaPolicka = naseData.Policka.Where(p => p.Vlastnik == pracovniHrac).ToList();
                return vlastnenaPolicka.Count * prijemZaPolicko;
            }
            else
                return null;
        }

        public Policko PridatPole(int index, Hra kamPatri)
        {
            Policko novePole = new Policko();
            novePole.HraKamPatri = kamPatri;
            novePole.Index = index;

            return novePole;
        }
        public void PridatHru()
        {
            Hra novaHra = new Hra();
            novaHra.Soukroma = false;

            novaHra.Token = VytvorToken();
            novaHra.Policka = new List<Policko>();
            while(naseData.Hry.Where(h => h.Token == novaHra.Token).FirstOrDefault() != null)
            {
                novaHra.Token = VytvorToken();
            }
            for(int i = 0; i < StartovniPocetPolicek; i++)
            {
                novaHra.Policka.Add(PridatPole(i + 1, novaHra));
            }
            naseData.Hry.Add(novaHra); 
            naseData.SaveChanges();
        }
        public string VytvorToken()
        {
            Random nahoda = new Random();
            string token = "";
            for (int i = 0; i < 3; i++)
            {
                token += nahoda.Next('A', 'Z' + 1);
            }
            return token;
        }
    }
}
