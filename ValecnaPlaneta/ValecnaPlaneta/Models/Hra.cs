using System.ComponentModel.DataAnnotations;

namespace ValecnaPlaneta.Models
{
    public class Hra
    {
        [Key]
        int Id { get; set; }
        [Required]
        public bool Soukroma { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        virtual public List<Policko> Policka { get; set; }
        [Required]
        virtual public List<Hrac> Hraci { get; set; }
    }
}
