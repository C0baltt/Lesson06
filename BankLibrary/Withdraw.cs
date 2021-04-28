namespace BankLibrary

{
    public delegate void AccountWithdrawn(string messege);
    public class Withdraw
    {
        public event AccountWithdrawn Withdrawn;

        public decimal Amount { get; set; }
        public int Id { get; set; }
    }
}
