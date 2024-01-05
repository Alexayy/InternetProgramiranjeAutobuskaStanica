using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models;
using AutobuskaStanicaInternetProgramiranje.Repository;
using AutobuskaStanicaInternetProgramiranje.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutobuskaStanicaInternetProgramiranje.Auxiliary;
using Duende.IdentityServer.Validation;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
})
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseNpgsql(connectionString));

builder.Services.AddDbContext<AutobuskaStanicaDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IAutobusService, AutobusService>();
builder.Services.AddScoped<IKorisnikService, KorisnikService>();
builder.Services.AddScoped<IKartaService, KartaService>();
builder.Services.AddScoped<IKorisnikKartaService, KorisnikKartaService>();
builder.Services.AddScoped<ILinijaService, LinijaService>();
builder.Services.AddScoped<IRezervacijaService, RezervacijaService>();
builder.Services.AddScoped<IStajalisteService, StajalisteService>();
builder.Services.AddScoped<IStanicaService, StanicaService>();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddCors(options => { 
    options.AddDefaultPolicy(builder => { 
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); 
    });
});

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
//app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");


//if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var services = scope.ServiceProvider;

//        try
//        {
//            var context = services.GetRequiredService<AutobuskaStanicaDbContext>();
//            if (!context.Korisnici.Any())
//            {
//                GenerateFakeData(context);
//            }
//        }
//        catch (Exception ex)
//        {
            
//        }
//    }
//}

app.Run();

void GenerateFakeData(AutobuskaStanicaDbContext context)
{
    var generator = new FakeDataGenerator();

    // Generisanje lažnih podataka za sve entitete
    var korisnici = generator.GenerateFakeKorisnici(100);
    var autobusi = generator.GenerateFakeAutobusi(150);
    var linije = generator.GenerateFakeLinije(200);
    var stanice = generator.GenerateFakeStanice(300);
    var rezervacije = generator.GenerateFakeRezervacije(400, linije, korisnici);
    var karte = generator.GenerateFakeKarte(400);
    var stajalista = generator.GenerateFakeStajalista(500, linije, stanice);
    var korisnikKarte = generator.GenerateFakeKorisnikKarte(400, korisnici, karte);

    // Dodavanje generisanih podataka u bazu
    context.Korisnici.AddRange(korisnici);
    context.Autobusi.AddRange(autobusi);
    context.Linije.AddRange(linije);
    context.Stanice.AddRange(stanice);
    context.Rezervacije.AddRange(rezervacije);
    context.Karte.AddRange(karte);
    context.Stajalista.AddRange(stajalista);
    context.KorisnikKarta.AddRange(korisnikKarte);

    context.SaveChanges();
}
