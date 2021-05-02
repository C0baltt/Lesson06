using System;

namespace BankLibrary
{
    public class DepositAccount : Account
    {
        private void CheckPastDays(string message)
        {
            int termOfDeposit = 30;
            if (Days / termOfDeposit == 0)
            {
                throw new InvalidOperationException(message);
            }
        }

        public DepositAccount(decimal amount, decimal percentage) 
            : base(amount, percentage)
        {
        }

        public override AccountType Type => AccountType.Deposit;

        public override void Put(decimal amount)
        {
            CheckPastDays("Cannot put money.");
            base.Put(amount);
        }

        public override void Withdraw(decimal amount)
        {
            CheckPastDays("Cannot withdraw money.");
            base.Withdraw(amount);
        }

        public override void CalculatePercentage()
        {
            CheckPastDays(string.Empty);
            base.CalculatePercentage();
        }
    }
}
