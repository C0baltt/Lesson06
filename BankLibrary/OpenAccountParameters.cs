namespace BankLibrary
{
    public class OpenAccountParameters
    {
        public AccountType Type { get; set; }
        
        public decimal Amount { get; set; }

        public AccountCreated AccountCreated { get; set; }

        public AccountOpened AccountOpened { get; set; }

        public AccountClosed AccountClosed { get; set; }

        public AccountPut AccountPuted { get; set; }

        public AccountWithdrawn AccountWithdrawn { get; set; }

        //добавить opened, closed, put, Withdraw.
    }
}
