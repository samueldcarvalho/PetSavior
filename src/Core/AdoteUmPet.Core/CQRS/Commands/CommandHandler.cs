using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Commands
{
    public abstract class CommandHandler<TRequest, TResult> : IRequestHandler<TRequest, CommandResponse<TResult>> where TRequest : Command<TResult>
    {
        public abstract Task<CommandResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
