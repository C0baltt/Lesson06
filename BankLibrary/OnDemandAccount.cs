namespace BankLibrary
{
    public class OnDemandAccount : Account
    {
        public OnDemandAccount(decimal amount, decimal percentage)
            : base(amount, percentage)
        {
        }

        public override AccountType Type => AccountType.OnDemand;
    }
}
