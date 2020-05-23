using Contoso.Store.Domain.Contexts.Entities;
using Contoso.Store.Domain.Contexts.Enums;
using Contoso.Store.Domain.Contexts.ValueObjects;
using NUnit.Framework;

namespace Contoso.Store.Tests.EntitiesTests
{
    public class OrderTests
    {
        private Product _teclado;
        private Product _mouse;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        [SetUp]
        public void Setup()
        {
            //simulando dados reais
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("88041300081");
            var email = new Email("contato@academiadotnet.com.br");

            _teclado = new Product("Teclado Microsoft", "Melhor teclado", "teclado.jpg", 10M, 10);
            _mouse = new Product("Mouse Microsoft", "Melhor mouse", "mouse.jpg", 5M, 10);
            _monitor = new Product("Monitor Dell", "Melhor monitor", "dell.jpg", 50M, 10);

            _customer = new Customer(name, cpf, email, "(11) 95555-5555");
            _order = new Order(_customer);
        }

        [Test]
        public void OrderTests_CreateOrder_WhenValid_ReturnTrue()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        [Test]
        public void OrderTests_CreateOrder_WhenCreated_Status_Is_Created()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [Test]
        public void OrderTests_CreateOrder_Order_Item_Must_be_2()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_teclado, 5);

            Assert.AreEqual(2, _order.Itens.Count);
        }

        [Test]
        public void OrderTests_AddItem_Should_Subtract_5_From_Stock()
        {
            _order.AddItem(_monitor, 5);

            Assert.AreEqual(5, _monitor.StockQuantity);
        }

        [Test]
        public void OrderTests_Create_Order_Should_Have_Two_Shiipings_If_Higher_Than_Five()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }
    }
}
