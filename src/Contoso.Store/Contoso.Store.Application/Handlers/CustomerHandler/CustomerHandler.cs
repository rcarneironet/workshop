using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Domain.Contexts.Commands.Customer;
using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.ValueObjects;
using Contoso.Store.Shared.Abstractions;
using Contoso.Store.Shared.Implementations;
using FluentValidator;
using System;

namespace Contoso.Store.Application.Handlers.CustomerHandler
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Criar ValueObjects
            var name = new NameVo(command.Nome, command.Sobrenome);
            var cpf = new CpfVo(command.Documento);
            var email = new Email(command.Email);
            //Criar
            var customer = new Customer(name, cpf, email, command.Telefone);

            //Validar
            AddNotifications(name.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);

            if (Invalid)
            {
                return new CommandResult(false,
                    "Erro, corrija os seguintes problemas:",
                    Notifications);
            }

            try
            {
                _repository.Save(customer, 0);
            }
            catch (Exception ex)
            {
                //TO-DO: implementar log real
                throw new Exception("Erro - Handler CustomerHandler" + ex.InnerException);
            }

            return new CommandResult(true, "Customer criado com sucesso", null);
        }
    }
}
