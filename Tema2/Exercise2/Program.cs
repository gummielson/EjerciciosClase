using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ex1

            //Declare the different types of variables
            int[] arrayType = new int[5];
            List<string> listType;
            Dictionary<string, int> dictType = new Dictionary<string, int>();

            Console.WriteLine("Hello World!");

            //Add some values to our variables
            for (int i = 1; i < 6; i++) { arrayType[i - 1] = i; }
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
            foreach (var dict in dictType) { Console.WriteLine(dict); }
            Thread.Sleep(6000);
            #endregion

            #region ex2
            State state = new State();
            state = State.Initial;
            Console.WriteLine("Starting program. Enter a variable of any type: ");
            var response = Console.ReadLine();

            if(response != null)
            {
                state = State.Running;
            }

            Console.WriteLine("introduce a number: ");
            dynamic response2 = Console.ReadLine();

            response2 = response;
            #endregion

        }

        public enum State
        {
            Initial,
            Running,
            Completed
        }
    }
}
