using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface IKartaService
    {
        Task<IEnumerable<Karta>> GetKarteAsync();
        Task<Karta> GetKartaAsync(int id);
        Task CreateKartaAsync(Karta karta);
        Task UpdateKartaAsync(Karta karta);
        Task DeleteKartaAsync(int id);
    }
}
