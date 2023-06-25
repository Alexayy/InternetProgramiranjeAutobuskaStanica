using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface IStanicaService
    {
        Task<IEnumerable<Stanica>> GetStaniceAsync();
        Task<Stanica> GetStanicaAsync(int id);
        Task CreateStanicaAsync(Stanica stanica);
        Task UpdateStanicaAsync(Stanica stanica);
        Task DeleteStanicaAsync(int id);
    }
}
