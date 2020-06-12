using Contoso.Store.Domain.Contexts.Commands.Customer;
using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.ValueObjects;
using FluentValidator;
using NUnit.Framework;

namespace Contoso.Store.Tests.Commands
{
    public class CreateCustomerCommandTests : Notifiable
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateCustomerCommandTests_CreateOrder_ShouldBeValid()
        {
            var command = new CreateCustomerCommand();

            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("72092578022");
            var email = new Email("contato@academiadotnet.com.br");
            var customer = new Customer(name, cpf, email, command.Telefone);

            //Validar
            AddNotifications(name.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);

            Assert.AreEqual(true, !Invalid);
        }
    }
}
