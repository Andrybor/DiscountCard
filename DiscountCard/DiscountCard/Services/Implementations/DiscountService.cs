using DiscountCard.Services.Interfaces;

namespace DiscountCard.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        public int CalculateDiscountOnCard(decimal price)
        {
            if(price >= 1000 && price <= 1999)
            {
                return 1;
            }
            else if(price >= 2000 && price <= 4999)
            {
                return 3;
            }
            else if(price >= 5000 && price <= 9999)
            {
                return 5;
            }
            else if(price > 9999)
            {
                return 7;
            }

            return default;
        }

        public decimal CalculateSumWithDiscount(int discount, decimal sum)
        {
            if (discount.Equals(default))
                return sum;

            return discount * sum / 100;
        }
    }
}
