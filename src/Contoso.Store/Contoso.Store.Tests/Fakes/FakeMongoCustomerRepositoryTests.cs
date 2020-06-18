using System;
using System.Collections.Generic;
using Contoso.Store.Application.Repositories.MongoDb;
using Contoso.Store.Domain.Contexts.Entities;

namespace Contoso.Store.Tests.Fakes
{
    public class FakeMongoCustomerRepositoryTests : ICustomerMongoRepository
    {
        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
