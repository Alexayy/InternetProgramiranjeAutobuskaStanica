using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;

        public KorisnikController(IKorisnikService korisnikService)
        {
            _korisnikService = korisnikService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> GetKorisnici()
        {
            var korisnici = await _korisnikService.GetKorisniciAsync();
            return Ok(korisnici);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnik>> GetKorisnik(int id)
        {
            var korisnik = await _korisnikService.GetKorisnikAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            return Ok(korisnik);
        }

        [HttpGet("trenutnikorisnik")]
        [Authorize]
        public IActionResult GetTrenutniKorisnik()
        {
            var korisnickoIme = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(new { korisnickoIme = korisnickoIme });
        }

        [HttpPost]
        public async Task<ActionResult<Korisnik>> CreateKorisnik(Korisnik korisnik)
        {
            await _korisnikService.CreateKorisnikAsync(korisnik);
            return CreatedAtAction(nameof(GetKorisnik), new { id = korisnik.ID }, korisnik);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisnik(int id, Korisnik korisnik)
        {
            if (id != korisnik.ID)
            {
                return BadRequest();
            }
            await _korisnikService.UpdateKorisnikAsync(korisnik);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnik(int id)
        {
            await _korisnikService.DeleteKorisnikAsync(id);
            return NoContent();
        }
    }
}
