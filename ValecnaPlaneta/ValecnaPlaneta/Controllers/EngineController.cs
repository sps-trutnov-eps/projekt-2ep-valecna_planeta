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
        int prijemZaPolicko = 1;
        int cenaInfiltratora = 1000;
        int cenaTezebniJednotky = 200;
        int cenaVojaka = 500;
        int cenaScouta = 100;

        public EngineController(NasDbContext databaze)
        {
            naseData = databaze;
        }
        public bool Zije(string tokenHrace)
        {
            Hrac kontrolni = naseData.Hraci.Where(h => h.Token == tokenHrace).First();
            if (kontrolni.Zije) return true;
            else return false;
        }
        public Stav? PoslatScouta(int cisloPolicka, string tokenHrace, string tokenHry)
        {
            List<Policko> polickaHry = naseData.Policka.Where(p => p.HraKamPatri.Token == tokenHry).ToList();
            Policko? pracovni = polickaHry.Where(p => p.Index == cisloPolicka).FirstOrDefault();
            if (pracovni != null)
            {
                Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == tokenHrace).First();
                int prijem = (int)((DateTime.Now - pracovniHrac.CasPosledniAkce).TotalSeconds) * prijemZaPolicko;
                pracovniHrac.CasPosledniAkce = DateTime.Now;
                pracovniHrac.Kapital += prijem;

                if (pracovniHrac.Kapital > cenaScouta)
                {
                    pracovniHrac.Kapital -= cenaScouta;
                    if (pracovni.Stav == Stav.Prazdno)
                        return Stav.Prazdno;
                    else if (pracovni.Stav == Stav.Zabrano)
                        return Stav.Zabrano;
                    else if (pracovni.Stav == Stav.Bunkr)
                        return Stav.Bunkr;
                }

                naseData.SaveChanges();
                return null;
            }
            else
                return null;
        }
        public bool PoslatTezebniJednotku(int cisloPolicka, string tokenHrace, string tokenHry) 
        {
            List<Policko> polickaHry = naseData.Policka.Where(p => p.HraKamPatri.Token == tokenHry).ToList();
            Policko? pracovni = polickaHry.Where(p => p.Index == cisloPolicka).FirstOrDefault();
            if (pracovni != null)
            {
                Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == tokenHrace).First();
                int prijem = (int)((DateTime.Now - pracovniHrac.CasPosledniAkce).TotalSeconds) * prijemZaPolicko;
                pracovniHrac.CasPosledniAkce = DateTime.Now;
                pracovniHrac.Kapital += prijem;

                if (pracovni.Stav == Stav.Prazdno && pracovniHrac.Kapital > cenaTezebniJednotky)
                {
                    pracovni.Stav = Stav.Zabrano;
                    pracovni.Vlastnik = pracovniHrac.Token;
                    pracovniHrac.Kapital -= cenaTezebniJednotky;
                }

                naseData.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool PoslatVojaka(int cisloPolicka, string tokenHrace, string tokenHry) 
        {
            List<Policko> polickaHry = naseData.Policka.Where(p => p.HraKamPatri.Token == tokenHry).ToList();
            Policko? pracovni = polickaHry.Where(p => p.Index == cisloPolicka).FirstOrDefault();
            if (pracovni != null)
            {
                Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == tokenHrace).First();
                int prijem = (int)((DateTime.Now - pracovniHrac.CasPosledniAkce).TotalSeconds) * prijemZaPolicko;
                pracovniHrac.CasPosledniAkce = DateTime.Now;
                pracovniHrac.Kapital += prijem;

                if (pracovni.Stav == Stav.Zabrano && pracovniHrac.Kapital > cenaVojaka)
                {
                    pracovni.Stav = Stav.Prazdno;
                    pracovni.Vlastnik = null;
                    pracovniHrac.Kapital -= cenaVojaka;
                }

                naseData.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool PoslatInfiltratora(int cisloPolicka, string tokenHrace, string tokenHry)
        {
            List<Policko> polickaHry = naseData.Policka.Where(p => p.HraKamPatri.Token == tokenHry).ToList();
            Policko? pracovni = polickaHry.Where(p => p.Index == cisloPolicka).FirstOrDefault();
            if (pracovni != null)
            {
                Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == tokenHrace).First();
                int prijem = (int)((DateTime.Now - pracovniHrac.CasPosledniAkce).TotalSeconds) * prijemZaPolicko;
                pracovniHrac.CasPosledniAkce = DateTime.Now;
                pracovniHrac.Kapital += prijem;

                if (pracovni.Stav == Stav.Bunkr && pracovniHrac.Kapital > cenaInfiltratora)
                {
                    pracovni.Stav = Stav.Prazdno;
                    string adresaSmrti = pracovni.Vlastnik;
                    pracovni.Vlastnik = null;
                    Hrac hracUmirajici = naseData.Hraci.Where(h => h.Token == adresaSmrti).First();
                    hracUmirajici.Zije = false;
                    pracovniHrac.Kapital -= cenaInfiltratora;
                }

                naseData.SaveChanges();
                return true;   
            }
            else
                return false;
        }
        public int? Kapital(string TokenHrace)
        {
            Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == TokenHrace).First();
            int prijem = (int)((DateTime.Now - pracovniHrac.CasPosledniAkce).TotalSeconds) * prijemZaPolicko;
            pracovniHrac.CasPosledniAkce = DateTime.Now;
            pracovniHrac.Kapital += prijem;
            if (pracovniHrac != null)
                return pracovniHrac.Kapital;
            else
                return null;
        }
        public int? Prijem(string TokenHrace)
        {
            Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == TokenHrace).First();
            int prijem = (int)((DateTime.Now - pracovniHrac.CasPosledniAkce).TotalSeconds) * prijemZaPolicko;
            pracovniHrac.CasPosledniAkce = DateTime.Now;
            pracovniHrac.Kapital += prijem;
            if (pracovniHrac != null)
            {
                List<Policko> vlastnenaPolicka = naseData.Policka.Where(p => p.Vlastnik == pracovniHrac.Token).ToList();
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
