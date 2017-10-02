using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleImage Image = new ConsoleImage3();
            Image.EnterCount();
            Image.PrintImage();

            Console.ReadKey();
        }
    }
}
