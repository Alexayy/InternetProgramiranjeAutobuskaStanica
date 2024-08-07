﻿using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutobusController : ControllerBase
    {
        private readonly IAutobusService _autobusService;

        public AutobusController(IAutobusService autobusService)
        {
            _autobusService = autobusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autobus>>> GetAutobusi()
        {
            var autobusi = await _autobusService.GetAutobusiAsync();
            return Ok(autobusi);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autobus>> GetAutobus(int id)
        {
            var autobus = await _autobusService.GetAutobusAsync(id);
            if (autobus == null)
            {
                return NotFound();
            }
            return Ok(autobus);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Autobus>> CreateAutobus(Autobus autobus)
        {
            if (await _autobusService.AutobusExistsAsync(autobus.ID))
            {
                return Conflict("Autobus sa datim ID-jem već postoji.");
            }
            await _autobusService.CreateAutobusAsync(autobus);
            return CreatedAtAction(nameof(GetAutobus), new { id = autobus.ID }, autobus);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAutobus(int id, Autobus autobus)
        {
            if (id != autobus.ID)
            {
                return BadRequest();
            }
            await _autobusService.UpdateAutobusAsync(autobus);
            Console.WriteLine(autobus.ToString());
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAutobus(int id)
        {
            await _autobusService.DeleteAutobusAsync(id);
            return NoContent();
        }
    }
}
