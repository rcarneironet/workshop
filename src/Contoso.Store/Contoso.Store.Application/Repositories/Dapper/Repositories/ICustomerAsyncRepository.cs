using System.Collections.Generic;
using System.Threading.Tasks;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;

namespace Contoso.Store.Application.Repositories.Dapper.Repositories
{
    public interface ICustomerAsyncRepository
    {
        Task<IEnumerable<AllCustomersQuery>> AllCustomersQuery();
    }
}
