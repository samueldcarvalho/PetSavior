using AdoteUmPet.API.Configurations;
using AdoteUmPet.Application.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AdoteUmPet.API.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettingsModel _appSettings;

        public AuthController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettingsModel> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="registerInput"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserInputModel registerInput)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = registerInput.Email,
                Email = registerInput.Email,
                EmailConfirmed = true,
            };

            IdentityResult createResult = await _userManager.CreateAsync(user, registerInput.Password);

            if (!createResult.Succeeded)
                return BadRequest(createResult.Errors);

            await _signInManager.SignInAsync(user, false);

            return StatusCode(StatusCodes.Status201Created, await CreateJWT(user.Email));
        }

        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserInputModel loginInput)
        {
            SignInResult loginResult = await _signInManager.PasswordSignInAsync(loginInput.Email, loginInput.Password, false, false);

            if (!loginResult.Succeeded)
                return BadRequest("Invalid email or password");

            return Ok(await CreateJWT(loginInput.Email));
        }

        private async Task<string> CreateJWT(string email)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emitter,
                Audience = _appSettings.AllowedHost,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}