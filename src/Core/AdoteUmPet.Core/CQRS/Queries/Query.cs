using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Queries
{
    public abstract class Query<TResult> : IRequest<QueryResponse<TResult>> { }
}
