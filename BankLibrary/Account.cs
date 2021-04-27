using System;

namespace BankLibrary
{
    public delegate void AccountCreated(string message);

    public delegate void AccountOpened(string messege);

    public delegate void AccountClosed(string messege);

    public delegate void AccountPut(string messege);

    public delegate void AccountWithdrawn(string messege);

    public abstract class Account
    {
        private static int _counter = 0;
        private decimal _amount;
        private int _id;
        private int _days = 0;
        private AccountState _state;

        public event AccountCreated Created;

        public event AccountOpened Opened;

        public event AccountClosed Closed;

        public event AccountPut Puted;

        public event AccountWithdrawn Withdrawn;

        public Account(decimal amount)
        {
            _amount = amount;
            _state = AccountState.Created;
            _id = ++_counter;
        }

        public virtual void Open()
        {
            AssertValidState(AccountState.Created);

            _state = AccountState.Opened;
            IncrementDays();
            Created?.Invoke($"Account created. Your account id {Id}");
        }
        
        public virtual void Close()
        {
            AssertValidState(AccountState.Opened);
    
            _state = AccountState.Closed;

            Closed?.Invoke("Account closed.");
        }
        
        public virtual void Put(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            _amount += amount;

            Puted?.Invoke($"Amount {amount} credited. The amount of money in your account {_amount}.");
        }
        
        public virtual void Withdraw(decimal amount)
        {
            AssertValidState(AccountState.Opened);

            if (_amount < amount)
            {
                throw new InvalidOperationException("Not enough money");
            }

            _amount -= amount;

            Withdrawn?.Invoke($"Amount {amount} withdrawn. The amount of money in your account {_amount}.");
        }
        
        public abstract AccountType Type { get; }

        private void AssertValidState(AccountState validState)
        {
            if (_state != validState)
            {
                throw new InvalidOperationException($"Invalid account state: {_state}");
            }
        }

        protected int Days => _days;
        public int Id => _id;

        public void IncrementDays()
        {
            _days++;
        }
    }
}
