using AdoteUmPet.Core.Infrastructure;
using AdoteUmPet.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Interfaces
{
    public interface IPetRepository : IRepository<Pet> 
    {
        Task<PetBreed> FindBreedById(int id);
        Task<List<Pet>> GetAllWithPagination(int paginationNumber, int limit);
    }
}
