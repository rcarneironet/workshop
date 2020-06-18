using Contoso.Store.Application.Repositories.MongoDb;
using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Infrastructure.DataAccess.MongoDb.Context;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Contoso.Store.Infrastructure.DataAccess.MongoDb.Repository
{
    public class CustomerMongoRepository : ICustomerMongoRepository
    {
        private readonly MongoDbContext _context;

        public CustomerMongoRepository(MongoDbContext context)
        {
            if (context == null)
                throw new NotImplementedException("Context not found!");

            _context = context;
        }
        public void Add(Customer customer) =>
            _context
                .Customers
                .InsertOne(customer);

        public IEnumerable<Customer> GetAll() =>
            _context
                .Customers
                .AsQueryable()
                .ToList();

        public Customer GetById(Guid id) =>
            _context
                .Customers
                .AsQueryable()
                .Where(item => item.Id == id)
                .FirstOrDefault();
    }
}
