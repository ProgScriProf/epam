using System;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static float AverageLen(string[] str)
        {
            int count = 0;
            int size = 0;
            for (int i = 0; i < str.Length; i++) 
            {
                if (str[i].Length > 0)
                {
                    count++;
                    size += str[i].Length;
                }
            }
            return (float)size / count;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();

            Regex re = new Regex("[^a-zA-Zа-яА-Я]");

            string[] newStr = re.Split(str);

            Console.Write("Средняя длина слов: {0:0.00}", AverageLen(newStr));
            Console.ReadKey();
        }
    }
}
