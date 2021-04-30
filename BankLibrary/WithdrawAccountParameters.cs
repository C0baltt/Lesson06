namespace BankLibrary

{
    public delegate void AccountWithdrawn(string messege);
    public class WithdrawAccountParameters
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public MoneyWithdrawn MoneyWithdrawn { get; set; }
    }
}
