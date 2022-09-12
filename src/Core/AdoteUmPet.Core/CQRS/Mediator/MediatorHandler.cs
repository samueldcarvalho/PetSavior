using AdoteUmPet.Core.CQRS.Commands;
using AdoteUmPet.Core.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CommandResponse<TResult>> SendCommand<TResult>(Command<TResult> command)
        {
            return _mediator.Send(command);
        }

        public Task<QueryResponse<TResult>> SendQuery<TResult>(Query<TResult> query)
        {
            return _mediator.Send(query);
        }
    }
}
