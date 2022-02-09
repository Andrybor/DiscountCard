using System;

namespace DiscountCard.Models
{
    /// <summary>
    /// Represents a product of shop
    /// </summary>
    public class Product
    {
        public Product(
            string name,
            decimal price,
            int count)
        {
            ProductId = Guid.NewGuid();
            Price = price;
            Name = name;
            Count = count;
        }

        public Guid ProductId { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
    }
}
