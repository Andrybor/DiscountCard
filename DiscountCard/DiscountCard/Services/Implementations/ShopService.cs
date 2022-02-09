using System;
using System.Collections.Generic;
using System.Linq;
using DiscountCard.Models;
using DiscountCard.Services.Interfaces;

namespace DiscountCard.Services
{
    public class ShopService : IShopService
    {
        private readonly IDiscountService _discountService;

        public ShopService(
            IAccountService accountService,
            IDiscountService discountService)
        {
            Shop = new Shop(new List<Product>());
            AccountService = accountService;
            _discountService = discountService;
        }

        public Shop Shop { get; }
        public IAccountService AccountService { get; set; }

        public Guid AddNewProduct(
            string name,
            decimal price,
            int count)
        {
            return Shop.AddProduct(name, price, count);
        }

        public void AddSpecificProduct(Guid productId, int count)
        {
            var product = Shop.Products.FirstOrDefault(x=> x.ProductId.Equals(productId));
            product.Count += count;
        }

        public void RemoveProduct(Guid productId, bool removeAll = false)
        {
            Shop.RemoveProduct(productId, removeAll);
        }

        public void SellProduct(Guid accountId, Guid productId)
        {
            var account = AccountService.Accounts.FirstOrDefault(x => x.AccountId.Equals(accountId));
            var product = Shop.Products.FirstOrDefault(x => x.ProductId.Equals(productId));

            if(account != null && product != null)
            {
                decimal finalSum;
                if (!product.Discount.Equals(default))
                {
                    finalSum = _discountService.CalculateSumWithDiscount(product.Discount, product.Price);
                    
                }
                else
                {
                    finalSum = _discountService.CalculateSumWithDiscount(account.DiscountCard.Discount, product.Price);
                }

                if (finalSum > account.Sum)
                    return;

                account.Sum -= finalSum;
                account.DiscountCard.Amount += product.Price;
                account.DiscountCard.Discount = _discountService.CalculateDiscountOnCard(account.DiscountCard.Amount);
                RemoveProduct(product.ProductId);
            }
        }
    }
}
