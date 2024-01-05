using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinijaController : ControllerBase
    {
        private readonly ILinijaService _linijaService;

        public LinijaController(ILinijaService linijaService)
        {
            _linijaService = linijaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var linije = await _linijaService.GetLinijeAsync();
            return Ok(linije);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var linija = await _linijaService.GetLinijaAsync(id);
            if (linija == null)
                return NotFound();
            return Ok(linija);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Linija linija)
        {
            await _linijaService.CreateLinijaAsync(linija);
            return CreatedAtAction(nameof(Get), new { id = linija.ID }, linija);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Linija linija)
        {
            if (id != linija.ID)
                return BadRequest();
            await _linijaService.UpdateLinijaAsync(linija);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _linijaService.DeleteLinijaAsync(id);
            return NoContent();
        }

        [HttpGet("pretraga")]
        public async Task<IActionResult> Pretraga(string polazna, string dolazna)
        {
            var rezultati = await _linijaService.PretraziLinijeAsync(polazna, dolazna);
            if (rezultati == null || !rezultati.Any())
            {
                return Ok(new List<Linija>()); // Vraća prazan niz umesto 404 greške
            }
            return Ok(rezultati);
        }


    }
}
