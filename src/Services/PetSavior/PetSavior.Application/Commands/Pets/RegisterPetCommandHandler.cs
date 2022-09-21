using AdoteUmPet.Core.CQRS;
using AdoteUmPet.Core.CQRS.Commands;
using AdoteUmPet.Domain.Interfaces;
using AdoteUmPet.Domain.Pets;
using AdoteUmPet.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PetSavior.Core.Identity;
using PetSavior.Domain.Pets.Enums;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Commands.Pets
{
    public class RegisterPetCommandHandler : CommandHandler<RegisterPetCommand, Unit>
    {
        private readonly IPetRepository _petRepository;
        private readonly IApplicationUserService<User> _applicationUserService;

        public RegisterPetCommandHandler(IPetRepository petRepository, UserManager<User> userManager, IApplicationUserService<User> applicationUserService)
        {
            _petRepository = petRepository;
            _applicationUserService = applicationUserService;
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

            User user = await _applicationUserService.GetUser();

            if (user == null)
            {
                AddError("User cannot be found");
                return CreateRequestResult(false);
            }

            SexEnum sex = (SexEnum)request.Sex;

            Pet pet = new(request.Name, request.Description, request.CareTip, request.Weight, breed.Id, request.Pedigree, sex, user.Id);

            _petRepository.Add(pet);

            await CommitChanges(_petRepository.UnitOfWork);

            return CreateRequestResult(true);
        }
    }
}
