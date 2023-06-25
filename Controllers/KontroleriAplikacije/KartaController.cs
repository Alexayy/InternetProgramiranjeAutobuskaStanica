using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class KartaController : ControllerBase
    {
        private readonly IKartaService _kartaService;

        public KartaController(IKartaService kartaService)
        {
            _kartaService = kartaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var karte = await _kartaService.GetKarteAsync();
            return Ok(karte);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var karta = await _kartaService.GetKartaAsync(id);
            if (karta == null)
                return NotFound();
            return Ok(karta);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Karta karta)
        {
            await _kartaService.CreateKartaAsync(karta);
            return CreatedAtAction(nameof(Get), new { id = karta.ID }, karta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Karta karta)
        {
            if (id != karta.ID)
                return BadRequest();
            await _kartaService.UpdateKartaAsync(karta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _kartaService.DeleteKartaAsync(id);
            return NoContent();
        }
    }
}
