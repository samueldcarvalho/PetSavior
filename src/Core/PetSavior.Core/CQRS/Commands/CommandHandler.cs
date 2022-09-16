using AdoteUmPet.Core.Infrastructure;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Commands
{
    public abstract class CommandHandler<TRequest, TResult> : IRequestHandler<TRequest, RequestResult<TResult>> where TRequest : Command<TResult>
    {
        public ValidationResult ValidationResult { get; private set; } = new ValidationResult();
        public abstract Task<RequestResult<TResult>> Handle(TRequest request, CancellationToken cancellationToken);

        public CommandHandler<TRequest, TResult> AddError(string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure() { ErrorMessage = errorMessage });
            return this;
        }

        public CommandHandler<TRequest, TResult> AddError(string propertyName, string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
            return this;
        }

        public CommandHandler<TRequest, TResult> AddError(string propertyName, string errorMessage, string errorCode)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage) { ErrorCode = errorCode });
            return this;
        }

        public RequestResult<TResult> CreateRequestResult(bool success, TResult result = default)
        {
            return new RequestResult<TResult>(ValidationResult, success, result);
        }

        public Task CommitChanges(IUnitOfWork unitOfWork)
        {
            return unitOfWork.Commit();
        }
    }
}
