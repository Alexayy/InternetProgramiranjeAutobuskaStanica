using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class StajalisteService : IStajalisteService
    {
        private readonly AutobuskaStanicaDbContext _context;

        public StajalisteService(AutobuskaStanicaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stajaliste>> GetStajalistaAsync()
        {
            return await _context.Stajalista.ToListAsync();
        }

        public async Task<Stajaliste> GetStajalisteAsync(int id)
        {
            return await _context.Stajalista.FindAsync(id);
        }

        public async Task CreateStajalisteAsync(Stajaliste stajaliste)
        {
            _context.Stajalista.Add(stajaliste);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStajalisteAsync(Stajaliste stajaliste)
        {
            _context.Entry(stajaliste).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStajalisteAsync(int id)
        {
            var stajaliste = await _context.Stajalista.FindAsync(id);
            if (stajaliste != null)
            {
                _context.Stajalista.Remove(stajaliste);
                await _context.SaveChangesAsync();
            }
        }
    }
}
