using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Domain.Contexts.Commands.Customer;
using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.ValueObjects;
using Contoso.Store.Domain.Abstractions;
using Contoso.Store.Domain.Implementations;
using FluentValidator;
using System;
using Contoso.Store.Application.Repositories.MongoDb;

namespace Contoso.Store.Application.Handlers.CustomerHandlers
{
    public class CustomerCommandHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<ChangeCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerMongoRepository _mongoRepository;
        public CustomerCommandHandler(
            ICustomerRepository repository,
            ICustomerMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
            _repository = repository;
        }
        public IResult Handle(CreateCustomerCommand command)
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
                return new ApiContract(false,
                    "Erro, corrija os seguintes problemas:",
                    Notifications);
            }

            try
            {
                _repository.Save(customer, null);

                _mongoRepository.Add(customer);
            }
            catch (Exception ex)
            {
                //TO-DO: implementar log real
                throw new Exception("Erro - Handler CustomerHandler" + ex.InnerException);
            }

            return new ApiContract(true, "Customer criado com sucesso", null);
        }

        public IResult Handle(ChangeCustomerCommand command)
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
                return new ApiContract(false,
                    "Erro, corrija os seguintes problemas:",
                    Notifications);
            }

            try
            {
                _repository.Save(customer, command.Id);
            }
            catch (Exception ex)
            {
                //TO-DO: implementar log real
                throw new Exception("Erro - Handler CustomerHandler" + ex.Message);
            }

            return new ApiContract(true, "Customer criado com sucesso", null);
        }

    }
}
