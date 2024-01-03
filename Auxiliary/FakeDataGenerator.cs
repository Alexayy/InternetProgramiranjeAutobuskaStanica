using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using Bogus;

namespace AutobuskaStanicaInternetProgramiranje.Auxiliary
{
    public class FakeDataGenerator
    {
        public List<Autobus> GenerateFakeAutobusi(int count)
        {
            var autobusFaker = new Faker<Autobus>()
                .RuleFor(a => a.ID, f => f.IndexFaker + 1)
                .RuleFor(a => a.Marka, f => f.Vehicle.Manufacturer())
                .RuleFor(a => a.Model, f => f.Vehicle.Model())
                .RuleFor(a => a.BrojSedista, f => f.Random.Number(20, 50))
                .RuleFor(a => a.SedisteKompanije, f => f.Address.City())
                .RuleFor(a => a.BrojTelefonaKompanije, f => f.Phone.PhoneNumber())
                .RuleFor(a => a.EmailKompanije, f => f.Internet.Email())
                .RuleFor(a => a.SajtKompanije, f => f.Internet.Url());

            return autobusFaker.Generate(count);
        }

        public List<Korisnik> GenerateFakeKorisnici(int count)
        {
            var korisnikFaker = new Faker<Korisnik>()
                .RuleFor(k => k.ID, f => f.IndexFaker + 1)
                .RuleFor(k => k.Ime, f => f.Name.FirstName())
                .RuleFor(k => k.Prezime, f => f.Name.LastName())
                .RuleFor(k => k.Email, f => f.Internet.Email());

            return korisnikFaker.Generate(count);
        }

        public List<Karta> GenerateFakeKarte(int count)
        {
            var kartaFaker = new Faker<Karta>()
                .RuleFor(k => k.ID, f => f.IndexFaker + 1)
                .RuleFor(k => k.RezervacijaID, f => f.Random.Number(1, count))
                .RuleFor(k => k.DatumKupovine, f => f.Date.Past(1).ToUniversalTime());

            return kartaFaker.Generate(count);
        }

        public List<KorisnikKarta> GenerateFakeKorisnikKarte(int count, List<Korisnik> korisnici, List<Karta> karte)
        {
            var korisnikKartaFaker = new Faker<KorisnikKarta>()
                .RuleFor(kk => kk.ID, f => f.IndexFaker + 1)
                .RuleFor(kk => kk.KorisnikID, f => f.PickRandom(korisnici).ID)
                .RuleFor(kk => kk.KartaID, f => f.PickRandom(karte).ID);

            return korisnikKartaFaker.Generate(count);
        }

        public List<Linija> GenerateFakeLinije(int count)
        {
            var linijaFaker = new Faker<Linija>()
                .RuleFor(l => l.ID, f => f.IndexFaker + 1)
                .RuleFor(l => l.PolaznaStanica, f => f.Address.City())
                .RuleFor(l => l.DolaznaStanica, f => f.Address.City())
                .RuleFor(l => l.VremePolaska, f => f.Date.Future().ToUniversalTime());

            return linijaFaker.Generate(count);
        }

        public List<Rezervacija> GenerateFakeRezervacije(int count, List<Linija> linije, List<Korisnik> korisnici)
        {
            var rezervacijaFaker = new Faker<Rezervacija>()
                .RuleFor(r => r.ID, f => f.IndexFaker + 1)
                .RuleFor(r => r.LinijaID, f => f.PickRandom(linije).ID)
                .RuleFor(r => r.SedisteID, f => f.Random.Number(1, 50))
                .RuleFor(r => r.KorisnikID, f => f.PickRandom(korisnici).ID);

            return rezervacijaFaker.Generate(count);
        }

        public List<Stajaliste> GenerateFakeStajalista(int count, List<Linija> linije, List<Stanica> stanice)
        {
            var stajalisteFaker = new Faker<Stajaliste>()
                .RuleFor(s => s.ID, f => f.IndexFaker + 1)
                .RuleFor(s => s.LinijaID, f => f.PickRandom(linije).ID)
                .RuleFor(s => s.StanicaID, f => f.PickRandom(stanice).ID);

            return stajalisteFaker.Generate(count);
        }

        public List<Stanica> GenerateFakeStanice(int count)
        {
            var stanicaFaker = new Faker<Stanica>()
                .RuleFor(s => s.ID, f => f.IndexFaker + 1)
                .RuleFor(s => s.Naziv, f => f.Company.CompanyName())
                .RuleFor(s => s.Adresa, f => f.Address.StreetAddress());

            return stanicaFaker.Generate(count);
        }
    }
}
