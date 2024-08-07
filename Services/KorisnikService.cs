﻿using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly ApplicationDbContext _context;

        public KorisnikService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Korisnik>> GetKorisniciAsync()
        {
            return await _context.Korisnici.ToListAsync();
        }

        public async Task<Korisnik> GetKorisnikAsync(string id)
        {
            return await _context.Korisnici.FindAsync(id);
        }

        public async Task CreateKorisnikAsync(Korisnik korisnik)
        {
            if (korisnik.Email != "aleksa.cakic@gmail.com")
                korisnik.Uloga = "KORISNIK";
            else
                korisnik.Uloga = "ADMIN";
            
            _context.Korisnici.Add(korisnik);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKorisnikAsync(Korisnik korisnik)
        {
            _context.Entry(korisnik).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKorisnikAsync(string id)
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
