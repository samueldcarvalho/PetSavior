using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Commands
{
    public abstract class Command<TResult> : IRequest<CommandResponse<TResult>>
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
