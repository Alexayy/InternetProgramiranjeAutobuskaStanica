using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Data
{
    public class AutobuskaStanicaDbContext : DbContext
    {
        public AutobuskaStanicaDbContext(DbContextOptions<AutobuskaStanicaDbContext> options)
        : base(options)
        {
        }

        public DbSet<Autobus> Autobusi { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Karta> Karte { get; set; }
        public DbSet<Stanica> Stanice { get; set; }
        public DbSet<Stajaliste> Stajalista { get; set; }
        public DbSet<Linija> Linije { get; set; }
        public DbSet<KorisnikKarta> KorisnikKarta { get; set; }
    }
}
