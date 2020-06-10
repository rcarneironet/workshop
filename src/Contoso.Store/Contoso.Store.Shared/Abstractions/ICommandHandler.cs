using System;

namespace Contoso.Store.Shared.Abstractions
{
    public interface ICommandHandler<T> where T : ICommand
    {
        IResult Handle(T command);
    }

    public interface IQueryHandler<T>
    {
        IResult Handle(T query);
    }
}
