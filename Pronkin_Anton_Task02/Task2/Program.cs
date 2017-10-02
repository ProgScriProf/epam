using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleImage Image = new ConsoleImage();
            Image.EnterCount();
            Image.PrintImage();

            Console.ReadKey();
        }
    }
}
