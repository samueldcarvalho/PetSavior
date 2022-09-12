﻿using AdoteUmPet.Application.Models.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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

            return StatusCode(StatusCodes.Status201Created);
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

            return Ok();
        }
    }
}