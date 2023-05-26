using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region entryVariables

            bool boolEntry = false;
            int intVar = 0;
            decimal decimalVar = 0;
            char charVar = new char();
            string textVar = string.Empty;
            DateTime dateVar = new DateTime();
            #endregion

            #region entries

            int tries = 0;
            int maxNumberOfTries = 4;

            Console.WriteLine($"Introduce a boolean value ('true' and 'false' are the accepted values): ");
            bool validationBool = false;
            while (!validationBool && (tries < maxNumberOfTries))
            {
                if (!bool.TryParse(Console.ReadLine(), out boolEntry))
                { 
                    tries++;
                    if(tries < maxNumberOfTries) 
                        Console.WriteLine("Input value doesn´t match with the type required. Try again.");
                }
                else
                {
                    validationBool = true;
                }
            }

            tries = 0;
            Console.WriteLine($"Introduce a number: ");
            bool validationInt = false;
            while (!validationInt && (tries < maxNumberOfTries))
            {
                if (!int.TryParse(Console.ReadLine(), out intVar))
                {
                    if (tries < maxNumberOfTries)
                        Console.WriteLine("Input value doesn´t match with the type required. Try again.");
                }
                else
                {
                    validationInt = true;
                }
            }

            tries = 0;
            Console.WriteLine($"Introduce a decimal number: ");
            bool validationDec = false;
            while (!validationDec && (tries < maxNumberOfTries))
            {
                if (!decimal.TryParse(Console.ReadLine(), out decimalVar))
                {
                    if (tries < maxNumberOfTries)
                        Console.WriteLine("Input value doesn´t match with the type required. Try again.");
                }
                else
                {
                    validationDec = true;
                }
            }

            tries = 0;
            Console.WriteLine($"Introduce a character: ");
            bool validationChar = false;
            while (!validationChar && (tries < maxNumberOfTries))
            {
                if (!char.TryParse(Console.ReadLine(), out charVar))
                {
                    if (tries < maxNumberOfTries)
                        Console.WriteLine("Input value doesn´t match with the type required. Try again.");
                }
                else
                {
                    validationChar = true;
                }
            }

            tries = 0;
            Console.WriteLine($"Introduce a text: ");
            bool validationText = false;
            while (!validationText && (tries < maxNumberOfTries))
            {
                textVar = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(textVar) || (int.TryParse(textVar, out _)))
                {
                    if (tries < maxNumberOfTries)
                        Console.WriteLine("Input value doesn´t match with the type required. Try again.");
                }
                else
                {
                    validationText = true;
                }
            }

            tries = 0;
            Console.WriteLine($"Introduce a date (DD/MM/AAAA): ");
            bool validationDate = false;
            while (!validationDate && (tries < maxNumberOfTries))
            {
                if (!DateTime.TryParse(Console.ReadLine(), out dateVar))
                {
                    if (tries < maxNumberOfTries)
                        Console.WriteLine("Input value doesn´t match with the type required. Try again.");
                }
                else
                {
                    validationDate = true;
                }
            }
            #endregion

            #region salidas

            Console.WriteLine($"Opposite value of the input boolean: {!boolEntry}");

            if(decimalVar == 0)
            {
                Console.WriteLine($"Division of the input integer by the input decimal: {intVar / decimalVar}");
            }
            else 
            {
                Console.WriteLine($"Can´t make the operation because the input decimal is 0.");
            }

            Console.WriteLine($"{charVar}({textVar}){charVar}");

            Console.WriteLine($"Second: {dateVar.Second}, Day: {dateVar.Day}, Month: {dateVar.Month}");

            Console.WriteLine("Introduce a tecla to close the program.");
            Console.ReadLine();
            #endregion
        }



    }
}
