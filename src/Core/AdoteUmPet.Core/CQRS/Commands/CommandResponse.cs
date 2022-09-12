using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Commands
{
    public class CommandResponse<TResult>
    {
        public ValidationResult ValidationResult { get; private set; }
        public TResult Result { get; private set; }
        public bool Success { get; private set; }

        public CommandResponse(ValidationResult validationResult, TResult result, bool success)
        {
            ValidationResult = validationResult;
            Result = result;
            Success = success;
        }
    }
}
