using System;
using System.Collections.Generic;
using Contoso.Store.Domain.Contexts.Entities;

namespace Contoso.Store.Application.Repositories.MongoDb
{
    public interface ICustomerMongoRepository
    {
        void Add(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(Guid id);
    }
}
