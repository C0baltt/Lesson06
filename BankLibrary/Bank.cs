using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private readonly List<Account> _accounts = new();

        public void OpenAccount(OpenAccountParameters parameters)
        {
            // TODO: check types compatibility
            CreateAccount(parameters.AccountCreated, () => parameters.Type == AccountType.Deposit 
                ? new DepositAccount(parameters.Amount) as T
                : new OnDemandAccount(parameters.Amount) as T);
        }

        private void CreateAccount(AccountCreated accountCreated, Func<T> creator)
        {
            var account = creator();
            account.Open();
            account.Created += accountCreated;
            _accounts.Add(account);
        }
    }
}