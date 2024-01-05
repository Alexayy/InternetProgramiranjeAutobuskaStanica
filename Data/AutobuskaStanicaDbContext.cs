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

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Autobus> Autobusi { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Karta> Karte { get; set; }
        public DbSet<Stanica> Stanice { get; set; }
        public DbSet<Stajaliste> Stajalista { get; set; }
        public DbSet<Linija> Linije { get; set; }
        public DbSet<KorisnikKarta> KorisnikKarta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Ime).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Prezime).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Uloga).IsRequired().HasMaxLength(50);
                entity.Property(e => e.SlikaKorisnika).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Autobus>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Marka).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SedisteKompanije).IsRequired().HasMaxLength(200);
                entity.Property(e => e.BrojTelefonaKompanije).IsRequired().HasMaxLength(20);
                entity.Property(e => e.EmailKompanije).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SajtKompanije).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SlikaAutobusa).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.LinijaID).IsRequired();
                entity.Property(e => e.SedisteID).IsRequired();
                entity.Property(e => e.KorisnikID).IsRequired();
            });

            modelBuilder.Entity<Karta>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.RezervacijaID).IsRequired();
                entity.Property(e => e.DatumKupovine).IsRequired();
            });

            modelBuilder.Entity<Stanica>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Naziv).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Adresa).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Stajaliste>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.LinijaID).IsRequired();
                entity.Property(e => e.StanicaID).IsRequired();
            });

            modelBuilder.Entity<Linija>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.PolaznaStanica).IsRequired().HasMaxLength(200);
                entity.Property(e => e.DolaznaStanica).IsRequired().HasMaxLength(200);
                entity.Property(e => e.VremePolaska).IsRequired();
            });

            modelBuilder.Entity<KorisnikKarta>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.KorisnikID).IsRequired();
                entity.Property(e => e.KartaID).IsRequired();
            });

            modelBuilder.Entity<KorisnikKarta>()
                .HasOne<Korisnik>(kk => kk.Korisnik)
                .WithMany(k => k.KorisnikKarte)
                .HasForeignKey(kk => kk.KorisnikID);

            modelBuilder.Entity<KorisnikKarta>()
                .HasOne<Karta>(kk => kk.Karta)
                .WithMany(k => k.KorisnikKarte)
                .HasForeignKey(kk => kk.KartaID);
        }
    }
}
