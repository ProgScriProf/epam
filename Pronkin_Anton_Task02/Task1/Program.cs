using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        

        static void Main(string[] args)
        {

            Console.WriteLine("Программа для вычисления площади прямоугольника.");
            Rectangle Rect = new Rectangle();
            Rect.EnterWidth();
            Rect.EnterHeight();
            Rect.CalculateArea();
             
            Console.ReadKey();
        }
    }
}
