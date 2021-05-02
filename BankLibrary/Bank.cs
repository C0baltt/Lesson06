using System;
using System.Collections.Generic;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        private const string KgkPassPhrase = "CleanUp";
        //private readonly List<Locker> _lockers = new();
        private readonly AccountsCollection _accounts = new();
        private readonly Dictionary<Locker, object> _lockers = new();
        
        public int AddLocker(int id, string keyword, object data)
        {
            var locker = new Locker(id, keyword);
            _lockers.Add(locker, data);
            return locker.Id;
        }

        public object GetLockerData(int id, string keyword)
        {
            foreach (KeyValuePair<Locker, object> locker in _lockers)
            {
                if (locker.Key.Matches(id, keyword))
                {
                    return $"Watch your data: {locker.Value}";
                }
                return $"This pair {id} - {keyword} does not exist";
            }

            throw new ArgumentOutOfRangeException(
                $"Cannot find locker with ID: {_lockers} or keyword does not match");
        }

        public TU GetLockerData<TU>(int id, string keyword)
        {
            return (TU)GetLockerData(id, keyword);
        }

        public void VisitKgk(string passPhrase)
        {
            if (passPhrase.Equals(KgkPassPhrase))
            {
                foreach (Locker key in _lockers.Keys)
                {
                    _lockers[key] = null;
                }
            }
        }

        private void CreateAccount(OpenAccountParameters parameters, Func<T> creator)
        {
            var account = creator();
            AddSubscriptions(parameters, account);

            account.Open();
            _accounts.Add(account);
        }

        private static void AddSubscriptions(OpenAccountParameters parameters, T account)
        {
            account.Created += parameters.AccountCreated;
            account.Closed += parameters.AccountClosed;
            account.PutMoney += parameters.MoneyPut;
            account.Withdrawn += parameters.MoneyWithdrawn;
        }

        private void AssertValidId(int id)
        {
            if (id < 0 || id >= _accounts.GetCount())
            {
                throw new InvalidOperationException("An account with this number does not exist");
            }
        }

        private static void AssertValidAccount
            (OpenAccountParameters parameters)
        {
            var bankType = typeof(T);

            if ((parameters.Type == AccountType.Deposit && typeof(OnDemandAccount) == bankType) ||
                (parameters.Type == AccountType.OnDemand && typeof(DepositAccount) == bankType))
            {
                throw new InvalidOperationException("An account with this type can not create");
            }
        }

        public void OpenAccount(OpenAccountParameters parameters)
        {
            AssertValidAccount(parameters);

            CreateAccount(parameters, () => parameters.Type == AccountType.Deposit
                   ? new DepositAccount(parameters.Amount, parameters.Percentage) as T
                   : new OnDemandAccount(parameters.Amount, parameters.Percentage) as T);
        }

        public void ClosedAccount(CloseAccountParameters parameters)
        {
            AssertValidId(parameters.Id);

            var account = _accounts.GetItem(parameters.Id);
            account.Close();
            //ClearSubscriptions(parameters, (T)account);
        }

        public void PutAmount(PutAccountParameters parameters)
        {
            AssertValidId(parameters.Id);

            var account = _accounts.GetItem(parameters.Id);
            account.Put(parameters.Amount);
        }

        public void WithdrawMoney(WithdrawAccountParameters parameters)
        {
            AssertValidId(parameters.Id);

            var account = _accounts.GetItem(parameters.Id);
            account.Withdraw(parameters.Amount);
        }

        public void IncrementDay()
        {
            for (int i = 0; i < _accounts.GetCount(); i++)
            {
                if (_accounts.GetItem(i).IsStateClosed())
                {
                    continue;
                } 
                _accounts.GetItem(i).IncrementDays();
                _accounts.GetItem(i).CalculatePercentage();
            }
        }
    }
}
