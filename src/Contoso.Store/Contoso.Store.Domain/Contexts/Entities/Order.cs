using Contoso.Store.Domain.Contexts.Enums;
using Contoso.Store.Shared.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Store.Domain.Contexts.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _itens;
        private readonly IList<Delivery> _deliveries;

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreationDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Itens => _itens.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public Order(Customer customer)
        {
            Customer = customer;
            CreationDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _itens = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        //adiciona item
        public void AddItem(Product product, int quantity)
        {
            if (quantity > product.StockQuantity)
                AddNotification("OrderItem", $"Produto {product.Title} does not have {quantity} itens in stock!");

            var item = new OrderItem(product, quantity);
            _itens.Add(item);
        }

        //cria uma pedido
        public void Create()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_itens.Count == 0)
            {
                AddNotification("Order", "This order does not have itens");
            }
        }

        //Pagar
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        //Enviar
        public void Ship()
        {
            var deliveries = new List<Delivery>();
            var count = 1;

            //Se tiver mais que 5 itens, quebrar em entregas
            foreach (var item in _itens)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Envia todas as entregas
            deliveries.ForEach(x => x.Send());

            //Adiciona entregas aos pedidos
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        //Cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

    }
}
