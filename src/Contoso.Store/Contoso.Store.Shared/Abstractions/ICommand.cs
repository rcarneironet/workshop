namespace Contoso.Store.Shared.Abstractions
{
    public interface ICommand
    {
        bool IsValid();
    }
}
