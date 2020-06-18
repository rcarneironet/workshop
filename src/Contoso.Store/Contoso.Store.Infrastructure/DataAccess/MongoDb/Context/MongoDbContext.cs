using Contoso.Store.Domain.Contexts.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Contoso.Store.Infrastructure.DataAccess.MongoDb.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public MongoDbContext(IConfiguration configuration)
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            var client = new MongoClient(configuration.GetSection("MongoDb:ConnectionString").Value);
            _mongoDatabase = client.GetDatabase(configuration.GetSection("MongoDb:Database").Value);
        }

        public IMongoCollection<Customer> Customers =>
            _mongoDatabase.GetCollection<Customer>("Sales");

    }
}
