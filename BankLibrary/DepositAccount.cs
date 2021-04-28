using System;

namespace BankLibrary
{
    public class DepositAccount : Account
    {
        public DepositAccount(decimal amount) 
            : base(amount)
        {
        }

        public override AccountType Type => AccountType.Deposit;

        public new BankType BankType => BankType.DepositAccount;

        public override void Put(decimal amount)
        {
            CheckPastDays("Cannot put money.");
            base.Put(amount);
        }

        public override void CalculatePercentage()
        {
            CheckPastDays(string.Empty);
            base.CalculatePercentage();
        }

        public override void Withdraw(decimal amount)
        {
            int termOfDeposit = 30;
            if ((Days / termOfDeposit) == 0)
            {
                throw new InvalidOperationException("Cannot withdraw money.");
            }
            
            base.Withdraw(amount);
        }
    }
}
