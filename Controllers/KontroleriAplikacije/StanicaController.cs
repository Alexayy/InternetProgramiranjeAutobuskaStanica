using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class StanicaController : ControllerBase
    {
        private readonly IStanicaService _stanicaService;

        public StanicaController(IStanicaService stanicaService)
        {
            _stanicaService = stanicaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stanice = await _stanicaService.GetStaniceAsync();
            return Ok(stanice);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var stanica = await _stanicaService.GetStanicaAsync(id);
            if (stanica == null)
                return NotFound();
            return Ok(stanica);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Stanica stanica)
        {
            await _stanicaService.CreateStanicaAsync(stanica);
            return CreatedAtAction(nameof(Get), new { id = stanica.ID }, stanica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Stanica stanica)
        {
            if (id != stanica.ID)
                return BadRequest();
            await _stanicaService.UpdateStanicaAsync(stanica);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stanicaService.DeleteStanicaAsync(id);
            return NoContent();
        }
    }
}
