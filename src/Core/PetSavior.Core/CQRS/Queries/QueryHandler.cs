using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Queries
{
    public abstract class QueryHandler<TRequest, TResult> : IRequestHandler<TRequest, RequestResult<TResult>> where TRequest : Query<TResult>
    {
        public ValidationResult ValidationResult { get; private set; } = new ValidationResult();

        public abstract Task<RequestResult<TResult>> Handle(TRequest request, CancellationToken cancellationToken);

        public RequestResult<TResult> CreateRequestResult(bool success, TResult result = default)
        {
            return new RequestResult<TResult>(ValidationResult, success, result);
        }
    }
}
