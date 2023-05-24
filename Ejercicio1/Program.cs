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

            #region entries
            bool booleanVar = bool.Parse(ValidateInput("boolean"));
            int intVar = int.Parse(ValidateInput("integer"));
            double decimalVar = double.Parse(ValidateInput("decimal"));
            char charVar = char.Parse(ValidateInput("char"));
            string textVar = ValidateInput("text");
            DateTime dateVar = DateTime.Parse(ValidateInput("date"));
            #endregion

            #region salidas
            Console.WriteLine($"Opposite value of the input boolean: {!booleanVar}");
            Console.WriteLine($"Division of the input integer by the input decimal: {intVar/decimalVar}");
            Console.WriteLine($"{charVar}({textVar}){charVar}");
            Console.WriteLine($"Second: {dateVar.Second}, Day: {dateVar.Day}, Month: {dateVar.Month}");

            Thread.Sleep(60000);
            #endregion
        }

        #region logicMethods

        /// <summary>
        /// Validates the input based on the specified type.
        /// </summary>
        /// <param name="type">The type of input to validate.</param>
        /// <returns>The validated input as a string.</returns>
        public static string ValidateInput(string type)
        {
            bool validation = false;
            string stringToValidate = string.Empty;

            while (!validation)
            {
                Console.WriteLine($"Introduce a {type} value: ");
                stringToValidate = Console.ReadLine();
                validation = ValidateType(type, stringToValidate);
                if(!validation) Console.WriteLine("Input value doesn´t match with the type required. Try again.");
            }

            Console.WriteLine("Correct type \n");

            return stringToValidate;
        }

        /// <summary>
        /// Validates the input based on the specified type.
        /// </summary>
        /// <param name="type">The type of input to validate.</param>
        /// <param name="stringToValidate">The input we have to validate as a string.</param>
        /// <returns>A boolean with the result of the validation.</returns>
        public static bool ValidateType(string type, string stringToValidate)
        {
            switch (type)
            {
                case "boolean":
                    if (bool.TryParse(stringToValidate, out _)) return true;
                    break;

                case "integer":
                    if (int.TryParse(stringToValidate, out _)) return true;
                    break;

                case "decimal":
                    if (decimal.TryParse(stringToValidate, out _)) return true;
                    break;

                case "char":
                    if (char.TryParse(stringToValidate, out _)) return true;
                    break;

                case "text":
                    if (!string.IsNullOrWhiteSpace(stringToValidate) && (!int.TryParse(stringToValidate, out _))) return true;
                    break;

                case "date":
                    if (DateTime.TryParse(stringToValidate, out _)) return true;
                    break;
            }

            return false;
        }
        #endregion

    }
}
