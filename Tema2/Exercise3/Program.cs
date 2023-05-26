using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> accountNumbers = new List<string>()
            {
                "account1",
                "account2",
                "account3"
            };

            List<int> pins = new List<int>()
            {
                1111,
                2222,
                3333
            };

            bool exit = false;

            List<decimal> balances = new List<decimal>()
            {
                0,
                0,
                0
            };

            List<List<decimal>> movements = new List<List<decimal>>()
            {
                new List<decimal>() {},
                new List<decimal>() {},
                new List<decimal>() {}
            };

            decimal income = 0;
            decimal outcome = 0;

            int index = 0;

            string accountNumber = string.Empty;
            int pin = 0;
            bool init = false;

            while (!init)
            {
                Console.WriteLine("Enter your account number: ");
                accountNumber = Console.ReadLine();
                Console.WriteLine("Enter your pin: ");

                bool pinValid = false;
                while (!pinValid)
                {
                    if (!int.TryParse(Console.ReadLine(), out pin))
                    {
                        Console.WriteLine("You have to enter integer values");
                    }
                    else
                    {
                        pinValid = true;
                    }
                }

                if (!string.IsNullOrEmpty(accountNumbers.Find(x => x == accountNumber)))
                {
                    if (pin == pins[accountNumbers.IndexOf(accountNumber)])
                    {
                        index = accountNumbers.IndexOf(accountNumber);
                        init = true;
                        Console.WriteLine("You have acces the account correctly.");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect credentials.");
                        exit = true;
                        init = true;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect credentials.");
                    exit = true;
                    init = true;
                };
            }

            while (!exit)
            {
                Console.WriteLine("Choice an option:");
                Console.WriteLine("1. Money income");
                Console.WriteLine("2. Money outcome");
                Console.WriteLine("3. List all movements");
                Console.WriteLine("4. List incomes");
                Console.WriteLine("5. List outcomes");
                Console.WriteLine("6. Show current money");
                Console.WriteLine("7. Exit");


                Console.Write("Choose the number of the option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter the quantity off money yo want to income.");
                        try
                        {
                            income = int.Parse(Console.ReadLine());
                            balances[index] += income;
                            movements[index].Add(income);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input number.");
                            break;
                        }
                    case "2":
                        Console.WriteLine("Enter the quantity off money yo want to outcome.");
                        try
                        {
                            outcome = int.Parse(Console.ReadLine());
                            balances[index] -= outcome;
                            movements[index].Add(-outcome);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input number.");
                            break;
                        }
                    case "3":
                        Console.WriteLine("List all movements.");
                        foreach (var movement in movements[index]) { Console.WriteLine(movement); }
                        break;
                    case "4":
                        Console.WriteLine("List of incomes.");
                        foreach(var income1 in movements[index].Where(movement => movement > 0))
                        {
                            Console.WriteLine(income1);
                        };
                        break;
                    case "5":
                        Console.WriteLine("List outcomes.");
                        foreach(var outcome1 in movements[index].Where(movement => movement < 0))
                        {
                            Console.WriteLine(outcome1);
                        };
                        break;
                    case "6":
                        Console.WriteLine($"Balance: {balances[index]}$");
                        break;
                    case "7":
                        break;

                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }

                Console.Write("Do you want to make other operation? Write 'Yes' if you eant to make another operation. Write 'No' if you dont wnat to make other operation.");
                switch (Console.ReadLine())
                {
                    case "Yes":
                        break;
                    case "No":
                        Console.WriteLine(balances[index]);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            Console.WriteLine("Write a key to end the program.");
            Console.ReadLine();
        }

    }
}
