using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class StajalisteController : ControllerBase
    {
        private readonly IStajalisteService _stajalisteService;

        public StajalisteController(IStajalisteService stajalisteService)
        {
            _stajalisteService = stajalisteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stajalista = await _stajalisteService.GetStajalistaAsync();
            return Ok(stajalista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var stajaliste = await _stajalisteService.GetStajalisteAsync(id);
            if (stajaliste == null)
                return NotFound();
            return Ok(stajaliste);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Stajaliste stajaliste)
        {
            await _stajalisteService.CreateStajalisteAsync(stajaliste);
            return CreatedAtAction(nameof(Get), new { id = stajaliste.ID }, stajaliste);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Stajaliste stajaliste)
        {
            if (id != stajaliste.ID)
                return BadRequest();
            await _stajalisteService.UpdateStajalisteAsync(stajaliste);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stajalisteService.DeleteStajalisteAsync(id);
            return NoContent();
        }
    }
}
