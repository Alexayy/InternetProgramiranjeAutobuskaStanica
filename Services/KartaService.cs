using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class KartaService : IKartaService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public KartaService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Karta>> GetKarteAsync()
        {
            return await _context.Karte.ToListAsync();
        }

        public async Task<Karta> GetKartaAsync(int id)
        {
            return await _context.Karte.FindAsync(id);
        }

        public async Task CreateKartaAsync(Karta karta)
        {
            _context.Karte.Add(karta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKartaAsync(Karta karta)
        {
            _context.Entry(karta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKartaAsync(int id)
        {
            var karta = await _context.Karte.FindAsync(id);
            if (karta != null)
            {
                _context.Karte.Remove(karta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
