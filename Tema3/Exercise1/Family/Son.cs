using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Family
{
    public class Son : Father
    {
        public string MySonProp1 { get; set; } = string.Empty;
        protected string MySonProp2 { get; set; } = string.Empty;
        private string MySonProp3 { get; set; } = string.Empty; 

        public Son()
        {
            MyGrandpaProp1 = "A";
            MyGrandpaProp2 = "A";
            SetMyGrandpaProp3("A");

            MyFatherProp1 = "A";
            MyFatherProp2 = "A";
            SetMyFatherProp3("A");

            MySonProp1 = "A";
            MySonProp2 = "A";
            MySonProp3 = "A";
        }

        /// <summary>
        /// Show all properties in console.
        /// </summary>
        public void ShowInConsole()
        {
            Console.WriteLine($"{MySonProp1}, {MySonProp2}, {MySonProp3}, {MyFatherProp1}, {MyFatherProp2}, {GetMyFatherProp3()}, {MyGrandpaProp1}, {MyGrandpaProp2}, {GetMyGrandpaProp3()}");
        }

        /// <summary>
        /// Validates the input based on the specified type.
        /// </summary>
        /// <param name="type">The type of input to validate.</param>
        /// <returns>The validated input as a string.</returns>
        public void ModifyValues()
        {
            Type tipo = typeof(Son);
            foreach (var prop in tipo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine($"Enter a value for {prop.Name}");
                prop.SetValue(this, Console.ReadLine());
            }

            Console.WriteLine($"Enter a value for MyFatherProp3");
            SetMyFatherProp3(Console.ReadLine());

            Console.WriteLine($"Enter a value for MyGrandpaProp3");
            SetMyGrandpaProp3(Console.ReadLine());

            ShowInConsole();
        }
    }
}
