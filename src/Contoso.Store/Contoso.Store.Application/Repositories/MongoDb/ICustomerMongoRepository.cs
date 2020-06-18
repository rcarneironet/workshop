using Contoso.Store.Domain.Contexts.Dtos;
using Contoso.Store.Domain.Contexts.Entities;
using System;
using System.Collections.Generic;

namespace Contoso.Store.Application.Repositories.MongoDb
{
    public interface ICustomerMongoRepository
    {
        void Add(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(Guid id);
    }
}
