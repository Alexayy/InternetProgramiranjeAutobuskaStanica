using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface ILinijaService
    {
        Task<IEnumerable<Linija>> GetLinijeAsync();
        Task<Linija> GetLinijaAsync(int id);
        Task CreateLinijaAsync(Linija linija);
        Task UpdateLinijaAsync(Linija linija);
        Task DeleteLinijaAsync(int id);
    }
}
