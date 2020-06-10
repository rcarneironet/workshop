using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using Contoso.Store.Domain.Contexts.ValueObjects;
using Contoso.Store.Shared.Abstractions;
using Contoso.Store.Shared.Implementations;
using FluentValidator;
using System;

namespace Contoso.Store.Application.Handlers.CustomerHandlers
{
    public class CustomerQueryHandler :
        Notifiable,
        IQueryHandler<CustomerDocumentQuery>
    {
        private readonly ICustomerRepository _repository;
        public CustomerQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public IResult Handle(CustomerDocumentQuery query)
        {
            var cpf = new CpfVo(query.Documento);
            AddNotifications(cpf.Notifications);

            if (Invalid)
            {
                return new ApiContract(false,
                    "Erro, corrija os seguintes problemas:",
                    Notifications);
            }

            try
            {
                return new ApiContract(true, string.Empty, _repository.GetByDocument(query.Documento));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro - Handler CustomerHandler" + ex.Message);
            }
        }

        public IResult Handle()
        {
            try
            {
                return new ApiContract(true, string.Empty, _repository.AllCustomersQuery());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro - Handler CustomerHandler" + ex.Message);
            }
        }
    }
}
