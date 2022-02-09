using System;
using System.Collections.Generic;
using System.Linq;
using DiscountCard.Models;
using DiscountCard.Services.Interfaces;

namespace DiscountCard.Services.Implementations
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {
            Accounts = new List<Account>();
        }

        public List<Account> Accounts { get; }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void RemoveAccount(Guid accountId)
        {
            var account = Accounts.FirstOrDefault(x => x.AccountId.Equals(accountId));
            if (account != null)
                Accounts.Remove(account);
        }
    }
}