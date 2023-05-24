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
            bool exit = false;
            int balance = 0;
            List<int> incomes = new List<int>();
            List<int> outcomes = new List<int>();
            int income = 0;
            int outcome = 0;

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
                            balance += income;
                            incomes.Add(income);
                            exit = FinalChoice(balance);
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
                            balance -= outcome;
                            outcomes.Add(outcome);
                            exit = FinalChoice(balance);
                            break;
                        }
                        catch
                        {
                            break;
                        }
                    case "3":
                        Console.WriteLine("List all movements.");
                        foreach (var outcome1 in outcomes) { Console.WriteLine($"-{outcome1}"); }
                        foreach (var income1 in incomes) { Console.WriteLine(income1); }
                        exit = FinalChoice(balance);
                        break;
                    case "4":
                        Console.WriteLine("List incomes.");
                        foreach (var income1 in incomes) { Console.WriteLine(income1); }
                        exit = FinalChoice(balance);
                        break;
                    case "5":
                        Console.WriteLine("List outcomes.");
                        foreach (var outcome1 in outcomes) { Console.WriteLine($"-{outcome1}"); }
                        exit = FinalChoice(balance);
                        break;
                    case "6":
                        Console.WriteLine($"Balance: {balance}$");
                        exit = FinalChoice(balance);
                        break;
                    case "7":
                        break;

                    default:
                        Console.WriteLine("Invalid operation.");
                        exit = FinalChoice(balance);
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
