using System;

namespace Contoso.Store.Shared.Abstractions
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
