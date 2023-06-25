using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervacijaController : ControllerBase
    {
        private readonly IRezervacijaService _rezervacijaService;

        public RezervacijaController(IRezervacijaService rezervacijaService)
        {
            _rezervacijaService = rezervacijaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rezervacije = await _rezervacijaService.GetRezervacijeAsync();
            return Ok(rezervacije);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rezervacija = await _rezervacijaService.GetRezervacijaAsync(id);
            if (rezervacija == null)
                return NotFound();
            return Ok(rezervacija);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Rezervacija rezervacija)
        {
            await _rezervacijaService.CreateRezervacijaAsync(rezervacija);
            return CreatedAtAction(nameof(Get), new { id = rezervacija.ID }, rezervacija);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Rezervacija rezervacija)
        {
            if (id != rezervacija.ID)
                return BadRequest();
            await _rezervacijaService.UpdateRezervacijaAsync(rezervacija);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rezervacijaService.DeleteRezervacijaAsync(id);
            return NoContent();
        }
    }
}
