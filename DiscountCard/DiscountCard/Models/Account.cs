using System;

namespace DiscountCard.Models
{
    /// <summary>
    /// Represents User's account
    /// </summary>
    public class Account
    {
        public Account()
        {
            AccountId = Guid.NewGuid();
            DiscountCard = new DiscountCard(default);
        }

        public Guid AccountId { get; }
        public DiscountCard DiscountCard { get; set; }
        public decimal Sum { get; set; }
    }
}
