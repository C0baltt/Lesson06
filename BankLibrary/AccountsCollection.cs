using System.Collections;
using System.Collections.Generic;

namespace BankLibrary
{
    public class AccountsCollection : IEnumerable<Account>
    {
        private readonly List<Account> _accounts;

        public AccountsCollection()
        {
            _accounts = new();
        }

        public IEnumerator GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        public int GetCount()
        {
            return _accounts.Count;
        }

        public void Add(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetItem(int id)
        {
            return _accounts[id];
        }

        IEnumerator<Account> IEnumerable<Account>.GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }
    }
}
