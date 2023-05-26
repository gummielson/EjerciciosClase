using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Family
{
    public class Son : Father
    {
        public int MySonProp1 { get; set; }
        protected int MySonProp2 { get; set; }
        private int MySonProp3 { get; set; }

        public Son()
        {
            MyGrandpaProp1 = 0;
            MyGrandpaProp2 = 0;
            //MyGrandpaProp3 = 0;

            MyFatherProp1 = 0;
            MyFatherProp2 = 0;
            //MyFatherProp3 = 0;

            MySonProp1 = 0;
            MySonProp2 = 0;
            MySonProp3 = 0;
        }

        /// <summary>
        /// Show all properties in console.
        /// </summary>
        public void ShowInConsole()
        {
            Console.WriteLine($"{MySonProp1}, {MySonProp2}, {MySonProp3}, {MyFatherProp1}, {MyFatherProp2}, {MyGrandpaProp1}, {MyGrandpaProp2}");
        }

        /// <summary>
        /// Validates the input based on the specified type.
        /// </summary>
        /// <param name="type">The type of input to validate.</param>
        /// <returns>The validated input as a string.</returns>
        public void ModifyValues(string propToModify, int valueToModify)
        {
            Type tipo = typeof(Son);
            var property = tipo.GetProperty(propToModify);
            property.SetValue(this, valueToModify);
            ShowInConsole();
        }
    }
}
