using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using Contoso.Store.Infrastructure.DataAccess.Dapper.Context;
using Dapper;
using System.Linq;

namespace Contoso.Store.Infrastructure.DataAccess.Dapper.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }
        public GetCustomerQueryResult GetByCpf(string cpf) => _context
                .Connection
                .Query<GetCustomerQueryResult>(
                 @"SELECT Nome, Documento FROM [dbo].[Cliente] Where Documento = @Cpf",
                 param: new { Cpf = cpf })
                .FirstOrDefault();

        public void Save(Customer model, int id)
        {
            if (id > 0) //Update
            {
                _context.Connection.ExecuteScalar(
                    "UPDATE Cliente SET Nome = @Nome, Documento = @Documento, Email = @Email, Telefone = @Telefone Where Id = @Id",
                    param: new { Id = id, Nome = model.Name, Documento = model.Cpf.Number, Email = model.Email.Address, Telefone = model.Telefone }
                );
            }
            else //insert
            {
                _context.Connection.ExecuteScalar(
                "INSERT INTO Cliente (Id, Nome, Documento, Email, Telefone) VALUES (@Id, @Nome, @Documento, @Email, @Telefone);",
                param: new { Id = model.Id, Nome = model.Name.ToString(), Documento = model.Cpf.Number, Email = model.Email.Address, Telefone = model.Telefone }
                );
            }
        }
    }
}
