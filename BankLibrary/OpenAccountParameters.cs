namespace BankLibrary
{
    public class OpenAccountParameters
    {
        public AccountType Type { get; set; }

        public decimal Amount { get; set; }

        public decimal Percentage { get; set; }

        public Action<string> AccountCreated { get; set; }

        public Action<string> MoneyWithdrawn { get; set; }

        public Action<string> AccountClosed { get; set; }

        public Action<string> MoneyPut { get; set; }
    }
}
