using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Queries
{
    public abstract class QueryHandler<TRequest, TResult> : IRequestHandler<TRequest, QueryResponse<TResult>> where TRequest : Query<TResult>
    {
        public abstract Task<QueryResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
