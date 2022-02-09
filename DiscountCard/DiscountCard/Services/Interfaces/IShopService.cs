using System;
using DiscountCard.Models;

namespace DiscountCard.Services.Interfaces
{
    /// <summary>
    /// Manage accounts, products and operations
    /// </summary>
    public interface IShopService
    {
        /// <summary>
        /// Add new product to the Shop
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public Guid AddNewProduct(string name, decimal price, int count);

        /// <summary>
        /// Add's specific product, count of product increased
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="count"></param>
        public void AddSpecificProduct(Guid productId, int count);

        /// <summary>
        /// Removes 
        /// </summary>
        /// <param name="productId"></param>
        public void RemoveProduct(Guid productId, bool removeAll = false);

        /// <summary>
        /// Selling product of the shop
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="productId"></param>
        public void SellProduct(Guid accountId, Guid productId);

        /// <summary>
        /// Service manage accounts
        /// </summary>
        public IAccountService AccountService { get; set; }

        /// <summary>
        /// Stores and manages shop products
        /// </summary>
        public Shop Shop { get; }
    }
}
