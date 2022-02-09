using DiscountCard.Services.Implementations;
using DiscountCard.Services.Interfaces;
using Xunit;

namespace DiscountCard.Tests
{
    public class DiscountServiceTests
    {
        private readonly IDiscountService _discountService;

        public DiscountServiceTests()
        {
            _discountService = new DiscountService();
        }

        [Theory]
        [InlineData(10, 0)]
        [InlineData(1000, 1)]
        [InlineData(2100, 3)]
        [InlineData(5100, 5)]
        [InlineData(10000, 7)]
        public void CalculateDiscountOnCardSuccess(decimal price, decimal discount)
        {
            // Act
            var discountCalculated = _discountService.CalculateDiscountOnCard(price);

            // Assert
            Assert.Equal(discount, discountCalculated);
        }

        [Fact]
        public void CalculateSumWithDiscountSuccess()
        {
            // Arrange
            var discount = 3;
            var price = 100;
            var expectedSum = 3;

            // Act
            var sumWithDiscount = _discountService.CalculateSumWithDiscount(discount, price);

            // Assert
            Assert.Equal(expectedSum, sumWithDiscount);
        }
    }
}
