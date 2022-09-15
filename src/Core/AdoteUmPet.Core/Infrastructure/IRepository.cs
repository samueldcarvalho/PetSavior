using AdoteUmPet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
