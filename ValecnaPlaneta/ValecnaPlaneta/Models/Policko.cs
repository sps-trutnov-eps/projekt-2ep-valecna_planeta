namespace ValecnaPlaneta.Models
{
    public class Policko
    {
        int ID { get; set; }
        public Hra HraKamPatri { get; set; }
        public enum Stav { Prazdno, Zabrano, Bunkr } 
        public string Vlastnik { get; set; }
    }
}
