using Contoso.Store.Application.Handlers.CustomerHandlers;
using Contoso.Store.Domain.Contexts.Commands.Customer;
using Contoso.Store.Domain.Contexts.ValueObjects;
using Contoso.Store.Tests.Fakes;
using NUnit.Framework;

namespace Contoso.Store.Tests.Handlers
{
    public class CustomerHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CustomerHandlerTests_CreateCustomer_Should_Be_Valid()
        {
            var command = new CreateCustomerCommand();
            command.Nome = "Ray";
            command.Sobrenome = "Carneiro";
            command.Documento = "72092578022";
            command.Email = "contato@academiadotnet.com.br";
            command.Telefone = "";

            var handler = new CustomerCommandHandler(new FakeCustomerRepositoryTests());

            Assert.AreEqual(true, handler.IsValid);
        }

        [Test]
        public void CustomerHandlerTests_CreateCustomer_Should_Create_Successfully()
        {
            var command = new CreateCustomerCommand();
            command.Nome = "Ray";
            command.Sobrenome = "Carneiro";
            command.Documento = "72092578022";
            command.Email = "contato@academiadotnet.com.br";
            command.Telefone = "";

            var handler = new CustomerCommandHandler(new FakeCustomerRepositoryTests());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
        }
    }
}
