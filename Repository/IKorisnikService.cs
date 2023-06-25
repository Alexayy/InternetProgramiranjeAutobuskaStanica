﻿using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Repository
{
    public interface IKorisnikService
    {
        Task<IEnumerable<Korisnik>> GetKorisniciAsync();
        Task<Korisnik> GetKorisnikAsync(int id);
        Task CreateKorisnikAsync(Korisnik korisnik);
        Task UpdateKorisnikAsync(Korisnik korisnik);
        Task DeleteKorisnikAsync(int id);
    }
}
