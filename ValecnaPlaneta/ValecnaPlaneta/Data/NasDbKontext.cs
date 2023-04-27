using Microsoft.EntityFrameworkCore;
using ValecnaPlaneta.Models;

namespace ValecnaPlaneta.Data
{
    public class NasDbContext : DbContext
    {
        public DbSet<Hra> Hry { get; set; }
        public DbSet <Hrac> Hraci { get; set; }
        public DbSet<Policko> Policka { get; set; }

        public NasDbContext(DbContextOptions<NasDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hrac>().HasOne(h => h.HraKamPatri).WithMany(h => h.Hraci);
            builder.Entity<Policko>().HasOne(p => p.HraKamPatri).WithMany(h => h.Policka);
        }
    }
}
