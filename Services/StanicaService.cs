using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class StanicaService : IStanicaService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public StanicaService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stanica>> GetStaniceAsync()
        {
            return await _context.Stanice.ToListAsync();
        }

        public async Task<Stanica> GetStanicaAsync(int id)
        {
            return await _context.Stanice.FindAsync(id);
        }

        public async Task CreateStanicaAsync(Stanica stanica)
        {
            _context.Stanice.Add(stanica);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStanicaAsync(Stanica stanica)
        {
            _context.Entry(stanica).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStanicaAsync(int id)
        {
            var stanica = await _context.Stanice.FindAsync(id);
            if (stanica != null)
            {
                _context.Stanice.Remove(stanica);
                await _context.SaveChangesAsync();
            }
        }
    }
}
