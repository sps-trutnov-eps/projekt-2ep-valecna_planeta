using ValecnaPlaneta.Data;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta
{
    public class Engine
    {
        private NasDbContext naseData;
        int StartovniPocetPolicek = 50;
        int PridavekPolicek = 20;
        int prijemZaPolicko = 1;
        int cenaInfiltratora = 1000;
        int cenaTezebniJednotky = 200;
        int cenaVojaka = 500;
        int cenaScouta = 100;
        int vychoziKapital = 1000;

        public Engine(NasDbContext databaze)
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
                pracovniHrac.Kapital += PridatPrachy(pracovniHrac);

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
                pracovniHrac.Kapital += PridatPrachy(pracovniHrac);

                if (pracovni.Stav == Stav.Prazdno && pracovniHrac.Kapital > cenaTezebniJednotky)
                {
                    pracovni.Stav = Stav.Zabrano;
                    pracovni.Vlastnik = pracovniHrac.Token;
                    pracovniHrac.Kapital -= cenaTezebniJednotky;
                }
                else if (pracovni.Stav != Stav.Prazdno && pracovniHrac.Kapital > cenaTezebniJednotky)
                {
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
                pracovniHrac.Kapital += PridatPrachy(pracovniHrac);

                if (pracovni.Stav == Stav.Zabrano && pracovniHrac.Kapital > cenaVojaka)
                {
                    pracovni.Stav = Stav.Prazdno;
                    pracovni.Vlastnik = null;
                    pracovniHrac.Kapital -= cenaVojaka;
                }
                else if (pracovni.Stav != Stav.Zabrano && pracovniHrac.Kapital > cenaVojaka)
                {
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
                pracovniHrac.Kapital += PridatPrachy(pracovniHrac);

                if (pracovni.Stav == Stav.Bunkr && pracovniHrac.Kapital > cenaInfiltratora)
                {
                    pracovni.Stav = Stav.Prazdno;
                    string adresaSmrti = pracovni.Vlastnik;
                    pracovni.Vlastnik = null;
                    Hrac hracUmirajici = naseData.Hraci.Where(h => h.Token == adresaSmrti).First();
                    hracUmirajici.Zije = false;
                    pracovniHrac.Kapital -= cenaInfiltratora;
                }
                else if (pracovni.Stav != Stav.Bunkr && pracovniHrac.Kapital > cenaInfiltratora)
                {
                    pracovniHrac.Kapital -= cenaInfiltratora;
                }

                naseData.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public int Kapital(string TokenHrace)
        {
            Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == TokenHrace).First();
            pracovniHrac.Kapital += PridatPrachy(pracovniHrac);

            return pracovniHrac.Kapital;
        }
        public int Prijem(string TokenHrace)
        {
            Hrac pracovniHrac = naseData.Hraci.Where(h => h.Token == TokenHrace).First();
            pracovniHrac.Kapital += PridatPrachy(pracovniHrac);
            List<Policko> vlastnenaPolicka = naseData.Policka.Where(p => p.Vlastnik == pracovniHrac.Token).ToList();
            return vlastnenaPolicka.Count * prijemZaPolicko;

        }

        public int PridatPrachy(Hrac hrac)
        {
            int prijem = 0;

            List<Policko> poleHrace = naseData.Policka.Where(p => p.Vlastnik ==  hrac.Token).ToList();
            prijem = (int)(DateTime.Now - hrac.CasPosledniAkce).TotalSeconds * prijemZaPolicko * poleHrace.Count;
            hrac.CasPosledniAkce = DateTime.Now;

            return prijem;
        }

        public Policko PridatPole(int index, Hra kamPatri)
        {
            Policko novePole = new Policko();
            novePole.HraKamPatri = kamPatri;
            novePole.Index = index;

            return novePole;
        }
        public Tuple<string,string> PridatHru(string jmeno, string? heslo)
        {
            Hra novaHra = new Hra();
            if (heslo == null)
                novaHra.Soukroma = false;
            else
            {
                novaHra.Soukroma = true;
                novaHra.Heslo = heslo;
            }

            novaHra.Jmeno = jmeno;

            novaHra.Token = VytvorToken();
            novaHra.Policka = new List<Policko>();
            while (naseData.Hry.Where(h => h.Token == novaHra.Token).FirstOrDefault() != null)
            {
                novaHra.Token = VytvorToken();
            }
            for (int i = 0; i < StartovniPocetPolicek; i++)
            {
                novaHra.Policka.Add(PridatPole(i + 1, novaHra));
            }
            naseData.Hry.Add(novaHra);

            naseData.SaveChanges();

            Hrac novyHrac = PridatHrace(novaHra);

            naseData.SaveChanges();

            return new Tuple<string, string>(novyHrac.Token, novaHra.Token);
        }

        public Hrac PridatHrace(Hra hraDoKterePatri)
        {
            Hrac novyHrac = new Hrac();
            novyHrac.HraKamPatri = hraDoKterePatri;
            novyHrac.Zije = true;
            novyHrac.Kapital = vychoziKapital;
            novyHrac.Token = VytvorToken();
            while (naseData.Hraci.Where(h => h.Token == novyHrac.Token).FirstOrDefault() != null)
            {
                novyHrac.Token = VytvorToken();
            }
            novyHrac.CasPosledniAkce = DateTime.Now;

            naseData.Hraci.Add(novyHrac);

            List<Policko> poleHry = naseData.Policka.Where(p => p.Stav == Stav.Prazdno).ToList();
            Random nahoda = new Random();
            Policko poleProBunkr = poleHry[nahoda.Next(0, poleHry.Count)];
            poleProBunkr.Stav = Stav.Bunkr;
            poleProBunkr.Vlastnik = novyHrac.Token;

            naseData.SaveChanges();
            return novyHrac;
        }

        public string VytvorToken()
        {
            Random nahoda = new Random();
            string token = "";
            for (int i = 0; i < 3; i++)
            {
                token += (char) (nahoda.Next('A', 'Z' + 1));
            }
            return token;
        }
    }
}
