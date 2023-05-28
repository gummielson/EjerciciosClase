using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiuser3.Models;

namespace Multiuser3
{
    public class Program
    {
        static List<User> users = new List<User>()
        {
            new User
            {
                AccountNumber = "1111",
                Pin = 1234,
                Balance = 1000,
                Movements = new List<decimal> { 100, -50, 200 }
            },
            new User
            {
                AccountNumber = "2222",
                Pin = 4321,
                Balance = 500,
                Movements = new List<decimal> { -50, 300, -100 }
            },
            new User
            {
                AccountNumber = "3333",
                Pin = 5555,
                Balance = 1500,
                Movements = new List<decimal> { 200, -100, 400 }
            }
        };
        static void Main(string[] args)
        {
            decimal income = 0;
            decimal outcome = 0;
            int index = 0;
            bool init = false;
            int pin = 0;
            User currentUser = new User();
            bool exit = false;

            while (!init)
            {
                Console.WriteLine("Enter your account number: ");
                string accountNumber = Console.ReadLine();
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

                if (users.Where(user => user.AccountNumber == accountNumber && user.Pin == pin).Any())
                {
                    currentUser = users.Where(user => user.AccountNumber == accountNumber && user.Pin == pin).FirstOrDefault();
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
                            currentUser.Balance += income;
                            currentUser.Movements.Add(income);
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
                            currentUser.Balance -= outcome;
                            currentUser.Movements.Add(-outcome);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input number.");
                            break;
                        }
                    case "3":
                        Console.WriteLine("List all movements.");
                        foreach (var movement in currentUser.Movements) { Console.WriteLine(movement); }
                        break;
                    case "4":
                        Console.WriteLine("List of incomes.");
                        foreach (var income1 in currentUser.Movements.Where(movement => movement > 0))
                        {
                            Console.WriteLine(income1);
                        };
                        break;
                    case "5":
                        Console.WriteLine("List outcomes.");
                        foreach (var outcome1 in currentUser.Movements.Where(movement => movement < 0))
                        {
                            Console.WriteLine(outcome1);
                        };
                        break;
                    case "6":
                        Console.WriteLine($"Balance: {currentUser.Balance}$");
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
                        Console.WriteLine(currentUser.Balance);
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

