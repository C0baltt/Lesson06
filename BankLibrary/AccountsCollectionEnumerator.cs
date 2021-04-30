using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class AccountsCollectionEnumerator : IEnumerator<Account>
    {
        private readonly List<Account> _accounts;
        private int position = -1;

        public AccountsCollectionEnumerator(List<Account> accounts)
        {
            _accounts = accounts;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= _accounts.Count)
                    throw new InvalidOperationException();
                return _accounts[position];
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (position < _accounts.Count)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        Account IEnumerator<Account>.Current
        {
            get
            {
                if (position == -1 || position >= _accounts.Count)
                    throw new InvalidOperationException();
                return _accounts[position];
            }
        }
    }
}
