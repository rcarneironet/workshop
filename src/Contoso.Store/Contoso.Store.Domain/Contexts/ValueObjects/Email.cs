using FluentValidator;
using FluentValidator.Validation;

namespace Contoso.Store.Domain.Contexts.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O e-mail está inválido")
                );
        }
    }
}
