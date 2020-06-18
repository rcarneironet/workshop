using System;
using Contoso.Store.Domain.Contexts.ValueObjects;

namespace Contoso.Store.Domain.Contexts.Dtos
{
    public sealed class CustomerDto
    {
        public Guid Id { get; }
        public NameVo Name { get; }
        public CpfVo Cpf { get; }
        public Email Email { get; set; }
        public string Telefone { get; set; }

    }
}
