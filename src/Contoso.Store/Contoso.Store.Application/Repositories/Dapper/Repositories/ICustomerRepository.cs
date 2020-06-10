using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using System;

namespace Contoso.Store.Application.Repositories.Dapper.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer model, Guid? id);
        GetCustomerQueryResult GetByCpf(string cpf);
    }
}
