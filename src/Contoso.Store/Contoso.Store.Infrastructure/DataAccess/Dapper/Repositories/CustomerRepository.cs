using Contoso.Store.Application.Repositories.Dapper.Repositories;
using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using Contoso.Store.Infrastructure.DataAccess.Dapper.Context;
using Dapper;
using System;
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
        public CustomerDocumentQuery GetByDocument(string cpf) => _context
                .Connection
                .Query<CustomerDocumentQuery>(
                 @"SELECT Documento FROM [dbo].[Cliente] Where Documento = @Cpf",
                 param: new { Cpf = cpf })
                .FirstOrDefault();

        public void Save(Customer model, Guid? id)
        {
            if (id.HasValue) //Update
            {
                _context.Connection.ExecuteScalar(
                    "UPDATE Cliente SET Nome = @Nome, Documento = @Documento, Email = @Email, Telefone = @Telefone Where Id = @Id",
                    param: new { Id = id.Value.ToString().ToUpper(), Nome = model.Name.ToString(), Documento = model.Cpf.Number, Email = model.Email.Address, Telefone = model.Telefone }
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
