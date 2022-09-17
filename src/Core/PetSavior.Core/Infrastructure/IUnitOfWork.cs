using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
