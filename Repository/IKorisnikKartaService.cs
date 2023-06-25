using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface IKorisnikKartaService
    {
        Task<IEnumerable<KorisnikKarta>> GetKorisnikKarteAsync();
        Task<KorisnikKarta> GetKorisnikKartaAsync(int id);
        Task CreateKorisnikKartaAsync(KorisnikKarta korisnikKarta);
        Task UpdateKorisnikKartaAsync(KorisnikKarta korisnikKarta);
        Task DeleteKorisnikKartaAsync(int id);
    }
}
