using System;
using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введте текст с HTML тегами: ");
            string str = Console.ReadLine();

            Regex re = new Regex("<[^>]+>");
            string newStr = re.Replace(str, "_");

            Console.WriteLine($"Текст после замены: {newStr}");

            Console.ReadKey();
        }
    }
}
