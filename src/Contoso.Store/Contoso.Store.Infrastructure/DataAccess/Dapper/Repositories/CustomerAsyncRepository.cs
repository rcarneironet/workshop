using System.Collections.Generic;
using System.Threading.Tasks;
using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using Contoso.Store.Infrastructure.DataAccess.Dapper.Context;
using Dapper;

namespace Contoso.Store.Infrastructure.DataAccess.Dapper.Repositories
{
    public class CustomerAsyncRepository : ICustomerAsyncRepository
    {
        private readonly DapperContext _context;
        public CustomerAsyncRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AllCustomersQuery>> AllCustomersQuery() =>
            await _context
                .Connection
                .QueryAsync<AllCustomersQuery>("SELECT Nome, Documento, Email, Telefone FROM [dbo].[Cliente] with (nolock)");
    }
}
