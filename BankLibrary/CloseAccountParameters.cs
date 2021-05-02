using System;
namespace BankLibrary
{
    public class CloseAccountParameters
    {
        public int Id { get; set; }
        public Action<string> AccountCreated { get; set; }
        public Action<string> MoneyWithdrawn { get; set; }
        public Action<string> AccountClosed { get; set; }
        public Action<string> MoneyPut { get; set; }
    }
}
