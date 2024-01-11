using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije
{
    public class Korisnik : IdentityUser
    {
        [AllowNull] public string? Prezime { get; set; }
        [AllowNull] public string? Uloga { get; set; }
        [AllowNull] public string? SlikaKorisnika { get; set; }
    }
}
