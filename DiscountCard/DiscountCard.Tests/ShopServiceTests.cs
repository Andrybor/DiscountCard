using System;
using System.Linq;
using DiscountCard.Services;
using DiscountCard.Services.Implementations;
using DiscountCard.Services.Interfaces;
using Moq;
using Xunit;

namespace DiscountCard.Tests
{
    public class ShopServiceTests
    {
        private readonly IShopService _shopService;

        public ShopServiceTests()
        {
            var accountServiceMock = new Mock<IAccountService>();
            accountServiceMock.SetupGet(x => x.Accounts).Returns(
                new System.Collections.Generic.List<Models.Account>() { new Models.Account() });
            _shopService = new ShopService(accountServiceMock.Object, new DiscountService());
        }

        [Fact]
        public void AddNewProductSuccess()
        {
            // Arrange
            var name = "TV Philips";
            var price = 999;
            var count = 12;

            // Act
            _shopService.AddNewProduct(name, price, count);

            // Assert
            Assert.Single(_shopService.Shop.Products);
        }

        [Fact]
        public void AddSpecificProductSuccess()
        {
            // Arrange
            var name = "TV Philips";
            var price = 999;
            var count = 12;
            var countToAdd = 3;

            // Act
            var productId =_shopService.AddNewProduct(name, price, count);
            _shopService.AddSpecificProduct(productId, countToAdd);

            // Assert
            Assert.Equal(15 ,_shopService.Shop.Products.FirstOrDefault(x=> x.ProductId.Equals(productId)).Count);
        }

        [Fact]
        public void RemoveSingleItemOfProductSuccess()
        {
            // Arrange
            var name = "TV Philips";
            var price = 999;
            var count = 12;

            // Act
            var productId = _shopService.AddNewProduct(name, price, count);
            Assert.Single(_shopService.Shop.Products);

            _shopService.RemoveProduct(productId);

            // Assert
            Assert.Equal(11, _shopService.Shop.Products.FirstOrDefault(x => x.ProductId.Equals(productId)).Count);

        }

        [Fact]
        public void RemoveTheWholeProductSuccess()
        {
            // Arrange
            var name = "TV Philips";
            var price = 999;
            var count = 12;

            // Act
            var productId = _shopService.AddNewProduct(name, price, count);
            Assert.Single(_shopService.Shop.Products);

            _shopService.RemoveProduct(productId, true);

            // Assert
            Assert.Null(_shopService.Shop.Products.FirstOrDefault(x => x.ProductId.Equals(productId)));

        }

        [Fact]
        public void SellProductSuccessWithoutDiscountOnProduct()
        {
            // Arrange
            var name = "TV Philips";
            var price = 1999;
            var count = 12;

            // Act
            var productId = _shopService.AddNewProduct(name, price, count);
            Assert.Single(_shopService.Shop.Products);

            var account = _shopService.AccountService.Accounts.FirstOrDefault();
            account.Sum += 2000;

            _shopService.SellProduct(account.AccountId, productId);

            // Assert
            Assert.Equal(price, account.DiscountCard.Amount);
            Assert.Equal(1, account.DiscountCard.Discount);
            Assert.Equal(1, account.Sum);
        }

        [Fact]
        public void SellProductSuccessWithDiscountOnProduct()
        {
            // Arrange
            var name = "TV Philips";
            var price = 1999;
            var count = 12;
            var discountService = new DiscountService();

            // Act
            var productId = _shopService.AddNewProduct(name, price, count);
            Assert.Single(_shopService.Shop.Products);
            var product = _shopService.Shop.Products.FirstOrDefault(x => x.ProductId == productId);
            product.Discount = 10;
            

            var account = _shopService.AccountService.Accounts.FirstOrDefault();
            account.Sum += 2000;
            

            _shopService.SellProduct(account.AccountId, productId);

            // Assert
            Assert.Equal(price, account.DiscountCard.Amount);
            Assert.Equal(2000 - discountService.CalculateSumWithDiscount(10, price), account.Sum);
        }
    }
}
