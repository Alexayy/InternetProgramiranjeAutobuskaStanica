using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface IStajalisteService
    {
        Task<IEnumerable<Stajaliste>> GetStajalistaAsync();
        Task<Stajaliste> GetStajalisteAsync(int id);
        Task CreateStajalisteAsync(Stajaliste stajaliste);
        Task UpdateStajalisteAsync(Stajaliste stajaliste);
        Task DeleteStajalisteAsync(int id);
    }
}
