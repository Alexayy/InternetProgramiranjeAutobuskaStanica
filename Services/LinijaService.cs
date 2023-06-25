using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class LinijaService : ILinijaService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public LinijaService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Linija>> GetLinijeAsync()
        {
            return await _context.Linije.ToListAsync();
        }

        public async Task<Linija> GetLinijaAsync(int id)
        {
            return await _context.Linije.FindAsync(id);
        }

        public async Task CreateLinijaAsync(Linija linija)
        {
            _context.Linije.Add(linija);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLinijaAsync(Linija linija)
        {
            _context.Entry(linija).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLinijaAsync(int id)
        {
            var linija = await _context.Linije.FindAsync(id);
            if (linija != null)
            {
                _context.Linije.Remove(linija);
                await _context.SaveChangesAsync();
            }
        }
    }
}
