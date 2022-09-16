using AdoteUmPet.Application.Commands.Pets;
using AdoteUmPet.Application.Models.InputModels;
using AdoteUmPet.Application.Models.ViewModels;
using AdoteUmPet.Application.Queries.Pets;
using AdoteUmPet.Core.CQRS;
using AdoteUmPet.Core.CQRS.Mediator;
using AdoteUmPet.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        /// <summary>
        /// Get all pets with pagination
        /// </summary>
        /// <param name="paginationNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<RequestResult<IEnumerable<PetViewModel>>>> GetAll([FromQuery] int paginationNumber, int limit)
        {
            RequestResult<IEnumerable<PetViewModel>> requestResult = await _mediatorHandler
                .SendQuery(new GetAllPetsWithPagionationQuery(paginationNumber, limit));

            if (!requestResult.Success)
                return BadRequest(requestResult);

            return Ok(requestResult);
        }
    }
}
