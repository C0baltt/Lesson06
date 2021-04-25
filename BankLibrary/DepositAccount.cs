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
