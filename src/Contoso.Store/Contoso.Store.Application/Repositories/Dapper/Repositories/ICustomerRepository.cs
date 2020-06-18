using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using System;
using System.Collections.Generic;

namespace Contoso.Store.Application.Repositories.Dapper.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer model, Guid? id);
        CustomerDocumentQuery GetByDocument(string cpf);
        IEnumerable<AllCustomersQuery> AllCustomersQuery();

    }
}