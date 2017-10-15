using System;
using BasicLib;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            MyString str = new MyString(Console.ReadLine());

            Console.Write("Введите вторую строку: ");
            MyString str2 = new MyString(Console.ReadLine());

            Console.WriteLine($"Сложение строк: {str + str2}");
            Console.WriteLine($"Вычитание строк строк: {str - str2}");
            Console.WriteLine($"Равенство строк: {(str == str2).ToString()}");

            Console.ReadKey();
        }
    }
}
