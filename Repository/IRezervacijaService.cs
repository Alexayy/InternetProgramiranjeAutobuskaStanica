using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface IRezervacijaService
    {
        Task<IEnumerable<Rezervacija>> GetRezervacijeAsync();
        Task<Rezervacija> GetRezervacijaAsync(int id);
        Task CreateRezervacijaAsync(Rezervacija rezervacija);
        Task UpdateRezervacijaAsync(Rezervacija rezervacija);
        Task DeleteRezervacijaAsync(int id);
    }
}
