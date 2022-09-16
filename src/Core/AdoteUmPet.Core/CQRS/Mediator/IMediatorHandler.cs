using AdoteUmPet.Core.CQRS.Commands;
using AdoteUmPet.Core.CQRS.Queries;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Mediator
{
    public interface IMediatorHandler
    {
        Task<RequestResult<TResult>> SendCommand<TResult>(Command<TResult> command);
        Task<RequestResult<TResult>> SendQuery<TResult>(Query<TResult> query);
    }
}