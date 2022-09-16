using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS
{
    public class RequestResult<TResult>
    {
        public ValidationResult ValidationResult { get; private set; }
        public TResult Result { get; private set; }
        public bool Success { get; private set; }

        public RequestResult(ValidationResult validationResult, bool success, TResult result = default)
        {
            ValidationResult = validationResult;
            Result = result;
            Success = success;
        }
    }
}
