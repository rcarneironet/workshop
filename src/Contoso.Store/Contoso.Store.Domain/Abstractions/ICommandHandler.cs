using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Store.Domain.Abstractions
{
    public interface ICommandHandler<T> where T : ICommand
    {
        IResult Handle(T command);
    }

    public interface IQueryHandler<T>
    {
        IResult Handle(T query);
    }
    public interface IQueryHandlerAsync<T>
    {
        Task<IResult> HandleAsync();
    }
}
