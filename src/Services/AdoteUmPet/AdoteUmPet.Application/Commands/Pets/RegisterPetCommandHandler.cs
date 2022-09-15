using AdoteUmPet.Core.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Commands.Pets
{
    public class RegisterPetCommandHandler : CommandHandler<RegisterPetCommand, Unit>
    {
        public override async Task<CommandResponse<Unit>> Handle(RegisterPetCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return new CommandResponse<Unit>(request.ValidationResult, Unit.Value, false);

            return new CommandResponse<Unit>(request.ValidationResult, Unit.Value, true);
        }
    }
}
