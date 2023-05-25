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
            List<string> countNumbers = new List<string>()
            {
                "count1",
                "count2",
                "count3"
            };

            List<int> pins = new List<int>()
            {
                1111,
                2222,
                3333
            };

            bool exit = false;
            List<int> balances = new List<int>()
            {
                0,
                0,
                0
            };

            List<List<int>> incomes = new List<List<int>>()
            {
                new List<int>() {}, 
                new List<int>() {},
                new List<int>() {}  
            };

            List<List<int>> outcomes = new List<List<int>>()
            {
                new List<int>() {},
                new List<int>() {},
                new List<int>() {}
            };

            int income = 0;
            int outcome = 0;

            int index = 0;

            string countNumber = string.Empty;
            int pin = 0;
            bool init = false;

            while (!init)
            {
                Console.WriteLine("Enter your count number: ");
                countNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(countNumbers.Find(x => x == countNumber)))
                {
                    Console.WriteLine("Wrong count number");
                }
                else
                {
                    bool pinValid = false;
                    while (!pinValid)
                    {
                        Console.WriteLine("Enter your pin: ");
                        if(int.TryParse(Console.ReadLine(), out pin)) pinValid = true;
                        if (!pinValid) Console.WriteLine("You have to enter integer values");
                    }
                    if (pin == pins[countNumbers.IndexOf(countNumber)])
                    {
                        index = countNumbers.IndexOf(countNumber);
                        init = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong ping");
                    }
                };
            }

            while (!exit)
            {
                string input = Options();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter the quantity off money yo want to income.");
                        try
                        {
                            income = int.Parse(Console.ReadLine());
                            balances[index] += income;
                            incomes[index].Add(income);
                            exit = FinalChoice(balances[index]);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid number.");
                            break;
                        }
                    case "2":
                        Console.WriteLine("Enter the quantity off money yo want to outcome.");
                        try
                        {
                            outcome = int.Parse(Console.ReadLine());
                            balances[index] -= outcome;
                            outcomes[index].Add(outcome);
                            exit = FinalChoice(balances[index]);
                            break;
                        }
                        catch
                        {
                            break;
                        }
                    case "3":
                        Console.WriteLine("List all movements.");
                        foreach (var outcome1 in outcomes[index]) { Console.WriteLine($"-{outcome1}"); }
                        foreach (var income1 in incomes[index]) { Console.WriteLine(income1); }
                        exit = FinalChoice(balances[index]);
                        break;
                    case "4":
                        Console.WriteLine("List incomes.");
                        foreach (var income1 in incomes[index]) { Console.WriteLine(income1); }
                        exit = FinalChoice(balances[index]);
                        break;
                    case "5":
                        Console.WriteLine("List outcomes.");
                        foreach (var outcome1 in outcomes[index]) { Console.WriteLine($"-{outcome1}"); }
                        exit = FinalChoice(balances[index]);
                        break;
                    case "6":
                        Console.WriteLine($"Balance: {balances[index]}$");
                        exit = FinalChoice(balances[index]);
                        break;
                    case "7":
                        break;

                    default:
                        Console.WriteLine("Invalid operation.");
                        exit = FinalChoice(balances[index]);
                        break;
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Choose the option you want to realize.
        /// </summary>
        /// <returns>The option input as a string.</returns>
        static string Options()
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
            return Console.ReadLine();
        }

        /// <summary>
        /// Option given at the end of another.
        /// </summary>
        /// <param name="balance">The amount of money.</param>
        /// <returns>The boolean value with the final choice decision.</returns>
        static bool FinalChoice(int balance)
        {
            Console.Write("Do you want to make other operation? ");
            switch (Console.ReadLine())
            {
                case "Yes": 
                    return false;
                case "No": 
                    Console.WriteLine(balance);
                    Thread.Sleep(6000);
                    return true;
                default: 
                    return true;
            }
        }

    }
}
