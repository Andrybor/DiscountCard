using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountCard.Models
{
    public class Shop
    {
        public Shop(List<Product> products)
        {
            Products = products;
        }

        public List<Product> Products { get; private set; }

        internal Guid AddProduct(
            string name,
            decimal amount,
            int count)
        {
            var product = new Product(name, amount, count);
            Products.Add(product);

            return product.ProductId;
        }

        internal void RemoveProduct(Guid productId, bool removeAll)
        {
            var productOnRemove = Products.FirstOrDefault(x => x.ProductId.Equals(productId));

            if(productOnRemove != null)
            {
                if (removeAll.Equals(true))
                {
                    Products.Remove(productOnRemove);
                }

                productOnRemove.Count--;
            }
        }
    }
}
