using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using AutobuskaStanicaInternetProgramiranje.Models;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;

namespace AutobuskaStanicaInternetProgramiranje.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<Korisnik>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }

    public DbSet<Korisnik> Korisnici { get; set; }
}
