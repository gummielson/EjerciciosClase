using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balance = 0;
            BankOperations(balance);
            Console.WriteLine("Do you want to realize another operation?");
            switch (Console.ReadLine())
            {
                case "Yes":
                    BankOperations(balance);
                    break;
                case "No":
                    Console.WriteLine(balance);
                    break;
                default: 
                    Console.WriteLine("Invalid response");
                    break;
            }

        }

        static void BankOperations(int balance)
        {
            bool exit = false;
            List<int> incomes = new List<int>();
            List<int> outcomes = new List<int>();
            int income = 0;
            int outcome = 0;


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
                        balance += income;
                        incomes.Add(income);
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
                    break;
                case "4":
                    Console.WriteLine("List incomes.");
                    foreach (var income1 in incomes) { Console.WriteLine(income1); }
                    break;
                case "5":
                    Console.WriteLine("List outcomes.");
                    foreach (var outcome1 in outcomes) { Console.WriteLine($"-{outcome1}"); }
                    break;
                case "6":
                    Console.WriteLine($"Balance: {balance}$");
                    break;
                case "7":
                    break;

                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
