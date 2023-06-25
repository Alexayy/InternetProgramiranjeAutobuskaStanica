using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikKartaController : ControllerBase
    {
        private readonly IKorisnikKartaService _korisnikKartaService;

        public KorisnikKartaController(IKorisnikKartaService korisnikKartaService)
        {
            _korisnikKartaService = korisnikKartaService;
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
        public async Task<IActionResult> Post(KorisnikKarta korisnikKarta)
        {
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

