using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public KorisnikService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Korisnik>> GetKorisniciAsync()
        {
            return await _context.Korisnici.ToListAsync();
        }

        public async Task<Korisnik> GetKorisnikAsync(int id)
        {
            return await _context.Korisnici.FindAsync(id);
        }

        public async Task CreateKorisnikAsync(Korisnik korisnik)
        {
            _context.Korisnici.Add(korisnik);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKorisnikAsync(Korisnik korisnik)
        {
            _context.Entry(korisnik).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKorisnikAsync(int id)
        {
            var korisnik = await _context.Korisnici.FindAsync(id);
            if (korisnik != null)
            {
                _context.Korisnici.Remove(korisnik);
                await _context.SaveChangesAsync();
            }
        }
    }
}
