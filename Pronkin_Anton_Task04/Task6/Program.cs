using System;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            do
            {
                Console.WriteLine("Введите число: ");
                str = Console.ReadLine();

                if (Regex.Match(str, @"-?\d+([.,]?\d+)?[eеEЕ][-+]?\d+([.,]?\d+)?").Value == str)
                {
                    Console.WriteLine("Научная натация");
                }
                else if (Regex.Match(str, @"-?\d+[.,]?\d+").Value == str)
                {
                    Console.WriteLine("Обычная натация");
                }
                else
                {
                    Console.WriteLine("Не число");
                }
                Console.WriteLine();
            } while (str != "");


            Console.ReadKey();
        }
    }
}
