using System;
using BankLibrary;

namespace BankApplication
{
    class Program
    {
        private static Bank<Account> _bank = new Bank<Account>();

        static void Main(string[] args)
        {
            bool alive = true;
            while (alive)
            {
                //Console.Clear();
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Open Account \t 2. WithdrawAccountParameters sum \t 3. Add sum");
                Console.WriteLine("4. Close Account \t 5. Skip day \t 6. Exit program");
                Console.WriteLine("Enter the item number:");
                Console.ForegroundColor = color;
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            OpenAccount();
                            break;
                        case 2:
                            Withdraw();
                            break;
                        case 3:
                            Put();
                            break;
                        case 4:
                            CloseAccount();
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void NextDay()
        {
            _bank.IncrementDay();
        }

        private static void OpenAccount()
        {
            Console.WriteLine("Specify the sum to create an account: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Select an account type: \n 1. On-Demand \n 2. Deposit");
            var type = Enum.Parse<AccountType>(Console.ReadLine());

            Console.WriteLine("Enter percentage: ");
            decimal percentage = Convert.ToDecimal(Console.ReadLine());

            //var bankType = Enum.Parse<BankType>(_bank.GetType().GetGenericArguments()[0].Name);

            _bank.OpenAccount(new OpenAccountParameters
            {
                Amount = sum,
                Type = type,
                Percentage = percentage,
                AccountCreated = Notify,
                AccountClosed = Notify,
                MoneyPut = Notify,
                MoneyWithdrawn = Notify
            });
        }

        private static void Withdraw()
        {
            Console.WriteLine("Specify the sum to withdraw from the account: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter account id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _bank.WithdrawMoney(new WithdrawAccountParameters
            {
                Amount = sum,
                Id = id
            });
        }

        private static void Put()
        {
            Console.WriteLine("Specify the sum to put on the account: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter account id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _bank.PutAmount(new PutAccountParameters
            {
                Amount = sum,
                Id = id
            });
        }

        private static void CloseAccount()
        {
            Console.WriteLine("Enter the account id to close: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _bank.ClosedAccount(new CloseAccountParameters
            {
                Id = id - 1
            });
        }

        private static void Notify(string message)
        {
            Console.WriteLine(message);
        }

        /*private static void NotifyAccountCreated(string message)
        {
            Console.WriteLine(message);
        }

        private static void NotifyAccountClosed(string message)
        {
            Console.WriteLine(message);
        }

        private static void NotifyAccountWithdrawn(string message)
        {
            Console.WriteLine(message);
        }*/
    }
}

