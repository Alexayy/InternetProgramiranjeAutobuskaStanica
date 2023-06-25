using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class AutobusService : IAutobusService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public AutobusService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autobus>> GetAutobusiAsync()
        {
            return await _context.Autobusi.ToListAsync();
        }

        public async Task<Autobus> GetAutobusAsync(int id)
        {
            return await _context.Autobusi.FindAsync(id);
        }

        public async Task CreateAutobusAsync(Autobus autobus)
        {
            _context.Autobusi.Add(autobus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAutobusAsync(Autobus autobus)
        {
            _context.Entry(autobus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutobusAsync(int id)
        {
            var autobus = await _context.Autobusi.FindAsync(id);
            if (autobus != null)
            {
                _context.Autobusi.Remove(autobus);
                await _context.SaveChangesAsync();
            }
        }
    }
}
