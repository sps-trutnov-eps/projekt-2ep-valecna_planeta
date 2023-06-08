using System.ComponentModel.DataAnnotations;

namespace ValecnaPlaneta.Models
{
    public class Hrac
    {
        [Key]
        public string Id { get; set; }
        [Required]
        virtual public Hra? HraKamPatri { get; set; }
        [Required]
        public bool Zije { get; set; }
        [Required]
        public int? Kapital { get; set; }
        public string? Token { get; set; }
        public DateTime CasPosledniAkce { get; set; }
    }
}
