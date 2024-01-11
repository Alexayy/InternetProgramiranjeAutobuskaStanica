using AutobuskaStanicaInternetProgramiranje.Data;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikKartaController : ControllerBase
    {
        private readonly IKorisnikKartaService _korisnikKartaService;
        private readonly AutobuskaStanicaDbContext _context;
        private readonly ApplicationDbContext _appDbContext;

        public KorisnikKartaController(IKorisnikKartaService korisnikKartaService,
            AutobuskaStanicaDbContext context,
            ApplicationDbContext appDbContext)
        {
            _korisnikKartaService = korisnikKartaService;
            _context = context;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var korisnikKarte = await _korisnikKartaService.GetKorisnikKarteAsync();
            return Ok(korisnikKarte);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var korisnikKarta = await _korisnikKartaService.GetKorisnikKartaAsync(id);
            if (korisnikKarta == null)
                return NotFound();
            return Ok(korisnikKarta);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KorisnikKarta model)
        {
            var korisnik = await _appDbContext.Korisnici.FindAsync(model.KorisnikID);
            var karta = await _context.Karte.FindAsync(model.KartaID);

            if (korisnik == null || karta == null)
            {
                return NotFound("Korisnik ili karta nije pronađen");
            }

            var korisnikKarta = new KorisnikKarta
            {
                KorisnikID = model.KorisnikID,
                KartaID = model.KartaID
            };

            Console.WriteLine("aaaaaa ", korisnikKarta.ToString());

            await _korisnikKartaService.CreateKorisnikKartaAsync(korisnikKarta);
            return CreatedAtAction(nameof(Get), new { id = korisnikKarta.ID }, korisnikKarta);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, KorisnikKarta korisnikKarta)
        {
            if (id != korisnikKarta.ID)
                return BadRequest();
            await _korisnikKartaService.UpdateKorisnikKartaAsync(korisnikKarta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _korisnikKartaService.DeleteKorisnikKartaAsync(id);
            return NoContent();
        }
    }
}

