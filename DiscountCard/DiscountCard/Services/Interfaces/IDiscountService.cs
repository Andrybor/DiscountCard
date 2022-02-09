namespace DiscountCard.Services.Interfaces
{
    /// <summary>
    /// Calculate discount for goods
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// Calculate discount for account discount card
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public int CalculateDiscountOnCard(decimal price);

        /// <summary>
        /// Calculate sum for goods with discount
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public decimal CalculateSumWithDiscount(int discount, decimal sum);
    }
}
