using System;

namespace BankLibrary
{
    public class PutAccountParameters
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        
        public MoneyPutted MoneyPutted { get; set; }

    }
}
