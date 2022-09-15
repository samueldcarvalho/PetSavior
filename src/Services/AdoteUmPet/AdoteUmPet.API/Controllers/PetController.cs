using AdoteUmPet.Application.Commands.Pets;
using AdoteUmPet.Application.Models.InputModels;
using AdoteUmPet.Core.CQRS.Commands;
using AdoteUmPet.Core.CQRS.Mediator;
using AdoteUmPet.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdoteUmPet.API.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController()]
    public class PetController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PetController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Register a new Pet for user
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RequestResult<bool>>> Register([FromBody] RegisterPetInputModel register)
        {
            string userId = User.Identity.Name;

            RequestResult<Unit> requestResult = await _mediatorHandler
                .SendCommand(new RegisterPetCommand(register.Name, register.Description, register.CareTip, register.Weight, register.BreedId, register.Pedigree, userId));

            if (!requestResult.Success)
                return BadRequest(requestResult);

            return Ok(requestResult);
        } 
    }
}
