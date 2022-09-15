using AdoteUmPet.Core.CQRS.Commands;
using AdoteUmPet.Core.CQRS.Queries;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Mediator
{
    public interface IMediatorHandler
    {
        Task<CommandResponse<TResult>> SendCommand<TResult>(Command<TResult> command);
        Task<QueryResponse<TResult>> SendQuery<TResult>(Query<TResult> query);
    }
}