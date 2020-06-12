using Contoso.Store.Domain.BaseEntity;

namespace Contoso.Store.Domain.Contexts.Entities
{
    public class Product : Entity
    {
        public Product(
            string title,
            string description,
            string image,
            decimal price,
            int stockQuantity)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public void WidthdrawStockQuantity(int quantity)
        {
            StockQuantity -= quantity;
        }

    }
}
