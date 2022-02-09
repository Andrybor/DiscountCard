using System;
using System.Collections.Generic;
using DiscountCard.Models;

namespace DiscountCard.Services.Interfaces
{
    /// <summary>
    /// Manages and stores user accounts
    /// </summary>
    public interface IAccountService
    {
        public void AddAccount(Account account);

        public void RemoveAccount(Guid accountId);

        public List<Account> Accounts { get; }
    }
}
