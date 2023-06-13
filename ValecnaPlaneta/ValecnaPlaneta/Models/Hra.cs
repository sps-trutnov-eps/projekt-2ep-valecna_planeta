using System.ComponentModel.DataAnnotations;

namespace ValecnaPlaneta.Models
{
    public class Hra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Soukroma { get; set; }
        [Required]
        public string? Token { get; set; }
        virtual public List<Policko>? Policka { get; set; }
        virtual public List<Hrac>? Hraci { get; set; }
    }
}
