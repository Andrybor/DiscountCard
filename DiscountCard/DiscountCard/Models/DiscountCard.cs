namespace DiscountCard.Models
{
    /// <summary>
    /// Represents discount card of user
    /// </summary>
    public class DiscountCard
    {
        public DiscountCard(int discount)
        {
            Discount = discount;
        }

        public int Discount { get; set; }

        /// <summary>
        /// Total amount of money accumulated on the discount card
        /// </summary>
        public decimal Amount { get; set; }
    }
}
