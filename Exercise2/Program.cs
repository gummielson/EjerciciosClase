using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ex1

            //Declare the different types of variables
            int[] arrayType = { };
            List<string> listType;
            Dictionary<string, int> dictType = new Dictionary<string, int>();

            //Add some values to our variables
            for (int i = 0; i < 5; i++) { arrayType.Append(i); }
            listType = new List<string>
            {
                "monday",
                "tuesday",
                "wednesday",
                "thursday",
                "friday"
            };

            for (int i = 0; i < arrayType.Length; i++) { dictType.Add(listType[i], arrayType[i]); }

            //Show the values in screen
            foreach (var day in arrayType) { Console.WriteLine(day); }
            foreach (var day in listType) { Console.WriteLine(day); }
            foreach (var dict in dictType.Keys) { Console.WriteLine(dict); }
            #endregion

        }
    }
}
