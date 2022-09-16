using AdoteUmPet.Application.Models.ViewModels;
using AdoteUmPet.Core.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Queries.Pets
{
    public class GetAllPetsWithPagionationQuery : Query<IEnumerable<PetViewModel>>
    {
        public int PaginationNumber { get; set; }
        public int Limit { get; set; }

        public GetAllPetsWithPagionationQuery(int paginationNumber, int limit)
        {
            PaginationNumber = paginationNumber;
            Limit = limit;
        }
    }
}
