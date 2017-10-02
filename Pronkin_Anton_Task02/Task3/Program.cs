using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleImage Image = new ConsoleImage2();
            Image.EnterCount();
            Image.PrintImage();

            Console.ReadKey();
        }
    }
}
