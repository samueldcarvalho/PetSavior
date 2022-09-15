using AdoteUmPet.Application.Commands.Pets;
using AdoteUmPet.Application.Models.InputModels;
using AdoteUmPet.Core.CQRS.Commands;
using AdoteUmPet.Core.CQRS.Mediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdoteUmPet.API.Controllers
{
    [Route("/api/v1/[controller]")]
    [Authorize]
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
        public async Task<ActionResult<CommandResponse<bool>>> Register([FromBody] RegisterPetInputModel register)
        {
            CommandResponse<Unit> commandResponse = await _mediatorHandler
                .SendCommand(new RegisterPetCommand(register.Name, register.Description, register.CareTip, register.Weight, register.BreedId, register.Pedigree));

            if (!commandResponse.Success)
                return BadRequest(commandResponse.ValidationResult);

            return Ok(commandResponse.ValidationResult);
        } 
    }
}
