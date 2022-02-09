using System.Linq;
using DiscountCard.Services.Implementations;
using DiscountCard.Services.Interfaces;
using Xunit;

namespace DiscountCard.Tests
{
    public class AccountServiceTests
    {
        private readonly IAccountService _accountService;

        public AccountServiceTests()
        {
            _accountService = new AccountService();
            _accountService.AddAccount(new Models.Account());
        }

        [Fact]
        public void AddAccountSuccess()
        {
            // Assert
            var count = _accountService.Accounts.Count;
            Assert.Equal(1, count);
        }

        [Fact]
        public void RemoveAccountSuccess()
        {
            var count = _accountService.Accounts.Count;
            Assert.Equal(1, count);

            // Action
            var accountId = _accountService.Accounts.FirstOrDefault().AccountId;
            _accountService.RemoveAccount(accountId);

            // Assert
            var countAfterRemove = _accountService.Accounts.Count;
            Assert.Equal(0, countAfterRemove);
        }
    }
}
