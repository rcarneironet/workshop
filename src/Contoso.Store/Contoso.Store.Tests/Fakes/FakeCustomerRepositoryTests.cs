using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using System;
using System.Collections.Generic;

namespace Contoso.Store.Tests.Fakes
{
    public class FakeCustomerRepositoryTests : ICustomerRepository
    {
        public IEnumerable<AllCustomersQuery> AllCustomersQuery()
        {
            var customer1 = new AllCustomersQuery()
            {
                Nome = "Cliente1",
                Documento = "00000000",
                Email = "email@cliente.com",
                Telefone = "1199999999"
            };

            var customer2 = new AllCustomersQuery()
            {
                Nome = "Cliente2",
                Documento = "1111111111",
                Email = "email2@cliente.com",
                Telefone = "118888888888"
            };

            return new List<AllCustomersQuery> { customer1, customer2 };
        }

        public CustomerDocumentQuery GetByDocument(string cpf)
        {
            return new CustomerDocumentQuery()
            {
                Documento = "33311122256"
            };
        }

        public void Save(Customer model, Guid? id)
        {
        }
    }
}
