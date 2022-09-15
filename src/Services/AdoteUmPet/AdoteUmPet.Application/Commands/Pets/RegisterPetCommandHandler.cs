using AdoteUmPet.Core.CQRS.Commands;
using AdoteUmPet.Domain.Interfaces;
using AdoteUmPet.Domain.Pets;
using AdoteUmPet.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Commands.Pets
{
    public class RegisterPetCommandHandler : CommandHandler<RegisterPetCommand, Unit>
    {
        private readonly IPetRepository _petRepository;
        private readonly UserManager<User> _userManager;

        public RegisterPetCommandHandler(IPetRepository petRepository, UserManager<User> userManager)
        {
            _petRepository = petRepository;
            _userManager = userManager;
        }

        public override async Task<RequestResult<Unit>> Handle(RegisterPetCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return new RequestResult<Unit>(request.ValidationResult, false);

            PetBreed breed = await _petRepository.FindBreedById(request.BreedId);
            
            if(breed == null)
            {
                AddError("Breed cannot be found");
                return CreateRequestResult(false);
            }

            User user = await _userManager.FindByIdAsync(request.UserId);

            if(user == null)
            {
                AddError("User cannot be found");
                return CreateRequestResult(false);
            }

            Pet pet = new Pet(request.Name, request.Description, request.CareTip, request.Weight, breed.Id, request.Pedigree, user);

            _petRepository.Add(pet);

            await CommitChanges(_petRepository.UnitOfWork);

            return CreateRequestResult(true);
        }
    }
}
