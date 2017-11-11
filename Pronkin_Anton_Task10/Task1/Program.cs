using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public delegate bool TypeComparer(string str1, string str2);

        static bool LenghtAndABC(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                return str1.CompareTo(str2) > 0;
            }
            return str1.Length < str2.Length;

        }

        static void MySort(string[] str, TypeComparer isRight)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length - 1; j++)
                {
                    if (!isRight(str[j], str[j + 1])) 
                    {
                        string Tmp = str[j];
                        str[j] = str[j + 1];
                        str[j + 1] = Tmp;
                    }
                }
            }
                    
        }

        static void Main(string[] args)
        {
            const int n = 6;
            var str = new string[n];

            Console.WriteLine($"Введите {n} строк:");
            for(int i = 0; i < 6; i++)
            {
                str[i] = Console.ReadLine();
            }

            MySort(str, LenghtAndABC);

            Console.WriteLine("Результат сортровки: ");
            foreach(var s in str)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
