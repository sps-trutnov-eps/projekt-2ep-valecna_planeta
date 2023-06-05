using System.ComponentModel.DataAnnotations;

namespace ValecnaPlaneta.Models
{
    public enum Stav { Prazdno, Zabrano, Bunkr }

    public class Policko
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        virtual public Hra? HraKamPatri { get; set; }
        public Stav Stav { get; set; }
        public string? Vlastnik { get; set; }
    }
}
