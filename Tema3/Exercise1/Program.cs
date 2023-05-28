using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise1.Family;

namespace Exercise1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Son son = new Son();

            son.ShowInConsole();
            son.ModifyValues();
            Console.ReadLine();
        }
    }
}
