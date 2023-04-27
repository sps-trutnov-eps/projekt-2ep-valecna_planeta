namespace ValecnaPlaneta.Models
{
    public class Hra
    {
        int ID { get; set; }
        bool Soukroma { get; set; }
        string Token { get; set; }
        public List<Policko> Policka { get; set; }
        public List<Hrac> Hraci { get; set; }
    }
}
