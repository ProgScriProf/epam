using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNewLib;
using System.Collections;

namespace Task1
{
    class Program 
    {
        static void Main(string[] args)
        {
            int a = 6;
            Console.WriteLine($"!{a} = {a.Fact()}");

            int b = 2, c = 11;
            Console.WriteLine($"{b} ^ {c} = {b.Pow(c)}");

            Console.ReadKey();
        }

    }
}
