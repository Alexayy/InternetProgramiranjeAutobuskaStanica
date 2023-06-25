using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class RezervacijaService : IRezervacijaService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public RezervacijaService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rezervacija>> GetRezervacijeAsync()
        {
            return await _context.Rezervacije.ToListAsync();
        }

        public async Task<Rezervacija> GetRezervacijaAsync(int id)
        {
            return await _context.Rezervacije.FindAsync(id);
        }

        public async Task CreateRezervacijaAsync(Rezervacija rezervacija)
        {
            _context.Rezervacije.Add(rezervacija);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRezervacijaAsync(Rezervacija rezervacija)
        {
            _context.Entry(rezervacija).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRezervacijaAsync(int id)
        {
            var rezervacija = await _context.Rezervacije.FindAsync(id);
            if (rezervacija != null)
            {
                _context.Rezervacije.Remove(rezervacija);
                await _context.SaveChangesAsync();
            }
        }
    }
}
