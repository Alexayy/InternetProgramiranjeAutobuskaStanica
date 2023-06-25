using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class KorisnikKartaService : IKorisnikKartaService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public KorisnikKartaService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KorisnikKarta>> GetKorisnikKarteAsync()
        {
            return await _context.KorisnikKarta.ToListAsync();
        }

        public async Task<KorisnikKarta> GetKorisnikKartaAsync(int id)
        {
            return await _context.KorisnikKarta.FindAsync(id);
        }

        public async Task CreateKorisnikKartaAsync(KorisnikKarta korisnikKarta)
        {
            _context.KorisnikKarta.Add(korisnikKarta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKorisnikKartaAsync(KorisnikKarta korisnikKarta)
        {
            _context.Entry(korisnikKarta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKorisnikKartaAsync(int id)
        {
            var korisnikKarta = await _context.KorisnikKarta.FindAsync(id);
            if (korisnikKarta != null)
            {
                _context.KorisnikKarta.Remove(korisnikKarta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
