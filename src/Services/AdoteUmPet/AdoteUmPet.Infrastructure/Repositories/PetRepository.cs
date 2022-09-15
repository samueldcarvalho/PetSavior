using AdoteUmPet.Core.Infrastructure;
using AdoteUmPet.Domain.Interfaces;
using AdoteUmPet.Domain.Pets;
using AdoteUmPet.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbConnection _dbConnection;

        public IUnitOfWork UnitOfWork { get; set; }

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbConnection = context.Database.GetDbConnection();

            UnitOfWork = context;  
        }

        public void Add(Pet entity)
        {
            _context.Pets.Add(entity);
        }

        public Task<List<Pet>> GetAll()
        {
            return _context.Pets.ToListAsync();
        }

        public Task<Pet> GetById(int id)
        {
            return _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Pet entity)
        {
            _context.Pets.Update(entity);
        }

        public Task<PetBreed> FindBreedById(int id)
        {
            return _context.PetBreeds.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
