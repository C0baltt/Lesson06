using System;

namespace BankLibrary
{
    public class Put
    {
        public decimal Amount { get; set; }
        public int Id { get; set; }

        void Message(int _amount, int amount, string action)
        {
            Console.WriteLine($"current balance {_amount} you {action} {amount}");
        }
    }
}
