namespace BankLibrary
{
    public class OpenAccountParameters
    {
        public AccountType Type { get; set; }

        public BankType BankType { get; set; }

        public decimal Amount { get; set; }
        
        public AccountCreated AccountCreated { get; set; }

        public decimal Percentage { get; set; }
    }
}
