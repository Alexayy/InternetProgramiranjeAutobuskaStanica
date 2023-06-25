using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface IAutobusService
    {
        Task<IEnumerable<Autobus>> GetAutobusiAsync();
        Task<Autobus> GetAutobusAsync(int id);
        Task CreateAutobusAsync(Autobus autobus);
        Task UpdateAutobusAsync(Autobus autobus);
        Task DeleteAutobusAsync(int id);
    }
}
