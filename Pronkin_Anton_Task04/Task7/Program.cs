using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            do
            {
                Console.WriteLine("Введите пример со временем: ");
                str = Console.ReadLine();

                int count = Regex.Matches(str, @"([^\w]|^)(([[01]?[0-9])|([2]?[0-4])):(([0-5]?[0-9]([^\w]|$)))").Count;
                Console.WriteLine($"Время встречается {count} раз(а)\n");

            } while (str != "");

            Console.ReadKey();

        }
    }
}
