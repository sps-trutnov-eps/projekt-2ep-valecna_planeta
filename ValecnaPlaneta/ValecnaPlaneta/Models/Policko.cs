using System.ComponentModel.DataAnnotations;

namespace ValecnaPlaneta.Models
{
    public class Policko
    {
        [Key]
        public int Id { get; set; }
        [Required]
        virtual public Hra HraKamPatri { get; set; }
        public enum Stav { Prazdno, Zabrano, Bunkr } 
        public string Vlastnik { get; set; }
    }
}
