using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class AccountsCollectionEnumerator : IEnumerator<Account>
    {
        private readonly List<Account> _accounts;
        private int _position = -1;

        public AccountsCollectionEnumerator(List<Account> accounts)
        {
            _accounts = accounts;
        }

        public object Current
        {
            get
            {
                if (_position == -1 || _position >= _accounts.Count)
                    throw new InvalidOperationException();
                return _accounts[_position];
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_position < _accounts.Count)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = -1;
        }

        Account IEnumerator<Account>.Current
        {
            get
            {
                if (_position == -1 || _position >= _accounts.Count)
                    throw new InvalidOperationException();
                return _accounts[_position];
            }
        }
    }
}
