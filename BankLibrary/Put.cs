using System;

namespace BankLibrary
{
    public class Put
    {
        public decimal Amount { get; set; }
        public int Id { get; set; }

        public MoneyPutted MoneyPutted { get; set; }

        void Message(int _amount, int amount, string action)
        {
            Console.WriteLine($"Current balance {_amount} you {action} {amount}");
        }
    }
}
