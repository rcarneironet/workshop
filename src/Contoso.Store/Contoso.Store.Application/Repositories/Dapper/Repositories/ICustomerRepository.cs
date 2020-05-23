using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;

namespace Contoso.Store.Application.Repositories.Dapper.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer model, int id);
        GetCustomerQueryResult GetByCpf(string cpf);
    }
}
