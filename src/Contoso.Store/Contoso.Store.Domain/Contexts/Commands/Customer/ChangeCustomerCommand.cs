using Contoso.Store.Domain.Abstractions;
using FluentValidator;
using FluentValidator.Validation;
using System;

namespace Contoso.Store.Domain.Contexts.Commands.Customer
{
    public class ChangeCustomerCommand : Notifiable, ICommand
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        bool ICommand.IsValid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Nome, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 40, "Nome", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(Sobrenome, 3, "Sobrenome", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Sobrenome, 40, "Sobrenome", "O sobrenome deve conter no máximo 40 caracteres")
                .HasMinLen(Telefone, 3, "Telefone", "O Telefone deve conter pelo menos 3 caracteres")
                .HasMaxLen(Telefone, 40, "Telefone", "O Telefone deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O E-mail é inválido")
            );
            return IsValid;
        }
    }
}
