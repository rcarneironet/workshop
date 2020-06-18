using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Application.Repositories.MongoDb;
using Contoso.Store.Domain.Abstractions;
using Contoso.Store.Domain.Contexts.Enums;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using Contoso.Store.Domain.Contexts.ValueObjects;
using Contoso.Store.Domain.Implementations;
using FluentValidator;
using System;
using System.Threading.Tasks;

namespace Contoso.Store.Application.Handlers.CustomerHandlers
{
    public class CustomerQueryHandler :
        Notifiable,
        IQueryHandler<CustomerDocumentQuery>,
        IQueryHandlerAsync<CustomerDocumentQuery>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerAsyncRepository _repositoryAsync;
        private readonly ICustomerMongoRepository _mongoRepository;

        public CustomerQueryHandler(
            ICustomerRepository repository,
            ICustomerAsyncRepository repositoryAsync,
            ICustomerMongoRepository mongoRepository)
        {
            _repository = repository;
            _repositoryAsync = repositoryAsync;
            _mongoRepository = mongoRepository;
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

        public IResult Handle(EDataSourceType source)
        {
            try
            {
                //to-do: achar uma forma melhor de passar o parametro
                if (source == EDataSourceType.MongoDb)
                    return new ApiContract(true, string.Empty, _mongoRepository.GetAll());

                return new ApiContract(true, string.Empty, _repository.AllCustomersQuery());

            }
            catch (Exception ex)
            {
                throw new Exception("Erro - Handler CustomerHandler" + ex.Message);
            }
        }

        public async Task<IResult> HandleAsync()
        {
            var data = await _repositoryAsync.AllCustomersQuery();
            return new ApiContract(true, string.Empty, data);
        }
    }
}
