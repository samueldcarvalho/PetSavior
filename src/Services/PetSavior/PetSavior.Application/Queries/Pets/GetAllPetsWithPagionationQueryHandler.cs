using AdoteUmPet.Application.Extensions;
using AdoteUmPet.Application.Models.ViewModels;
using AdoteUmPet.Core.CQRS;
using AdoteUmPet.Core.CQRS.Queries;
using AdoteUmPet.Domain.Interfaces;
using AdoteUmPet.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Queries.Pets
{
    public class GetAllPetsWithPagionationQueryHandler : QueryHandler<GetAllPetsWithPagionationQuery, IEnumerable<PetViewModel>>
    {
        private readonly IPetRepository _petRepository;

        public GetAllPetsWithPagionationQueryHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public override async Task<RequestResult<IEnumerable<PetViewModel>>> Handle(GetAllPetsWithPagionationQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Pet> pets = await _petRepository.GetAllWithPagination(request.PaginationNumber, request.Limit);

            if (!pets.Any())
                return CreateRequestResult(true, null);

            IEnumerable<PetViewModel> petsViewModel = pets.Select(p => p.ToViewModel());

            return CreateRequestResult(true, petsViewModel);
        }
    }
}
