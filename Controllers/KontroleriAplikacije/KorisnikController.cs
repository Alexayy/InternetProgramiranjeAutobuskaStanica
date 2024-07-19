using AutobuskaStanicaInternetProgramiranje.Models;
using AutobuskaStanicaInternetProgramiranje.Models.ModeliAplikacije;
using AutobuskaStanicaInternetProgramiranje.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutobuskaStanicaInternetProgramiranje.Controllers.KontroleriAplikacije
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;

        public KorisnikController(IKorisnikService korisnikService, 
            UserManager<Korisnik> userManager, 
            SignInManager<Korisnik> signInManager)
        {
            _korisnikService = korisnikService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> GetKorisnici()
        {
            var korisnici = await _korisnikService.GetKorisniciAsync();
            return Ok(korisnici);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnik>> GetKorisnik(string id)
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Korisnik>> CreateKorisnik(Korisnik korisnik)
        {
            await _korisnikService.CreateKorisnikAsync(korisnik);
            return CreatedAtAction(nameof(GetKorisnik), new { id = korisnik.Id }, korisnik);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisnik(string id, Korisnik korisnik)
        {
            if (id != korisnik.Id)
            {
                return BadRequest();
            }
            await _korisnikService.UpdateKorisnikAsync(korisnik);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnik(string id)
        {
            await _korisnikService.DeleteKorisnikAsync(id);
            return NoContent();
        }

        [Route("signin-google")]
        public async Task<IActionResult> OnPostGoogleLogin(string returnUrl = null)
        {
            var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action("OnGetGoogleResponse", new { ReturnUrl = returnUrl }));
            return Challenge(authenticationProperties, "Google");
        }

        [HttpGet("OnGetGoogleResponse")]
        public async Task<IActionResult> OnGetGoogleResponse(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, "Došlo je do greške kod eksterne prijave.");
                return BadRequest(ModelState);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Došlo je do greške prilikom učitavanja informacija o eksternoj prijavi.");
                return BadRequest(ModelState);
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var name = info.Principal.FindFirstValue(ClaimTypes.Name);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new Korisnik
                {
                    UserName = name, 
                    Email = email,
                    Prezime = name.Substring(name.IndexOf(' ') + 1),
                    SlikaKorisnika = "",
                    Uloga = "korisnik"                             
                };
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl ?? "/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Došlo je do greške prilikom prijavljivanja.");
                return BadRequest(ModelState);
            }
        }


    }
}
