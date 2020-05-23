using FluentValidator;
using FluentValidator.Validation;

namespace Contoso.Store.Domain.Contexts.ValueObjects
{
    public class NameVo : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public NameVo(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O FirstName deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 20, "FirstName", "O FirstName deve conter no máximo 20 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O FirstName deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 20, "LastName", "O FirstName deve conter no máximo 20 caracteres")
                );
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
