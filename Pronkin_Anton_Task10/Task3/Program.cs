using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public delegate bool TypeComparer(string str1, string str2);

        public static event EventHandler EndSort;

        static bool LenghtAndABC(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                if (str1.CompareTo(str2) > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

        public static void RunMySort(string[] str, TypeComparer typeComparer)
        {
            Console.WriteLine("Запуск сортировки.");
            MySort(str, typeComparer);
            EndSort?.Invoke(str, EventArgs.Empty);
            
        }

        static void Main(string[] args)
        {           
            const int n = 1000;
            string[] str = new string[n];
            for(int i = 0; i < n; i++)
            {
                str[i] = i.ToString();
            }

            EndSort += SortFinish;
            Thread sortThread = new Thread(() => RunMySort(str, LenghtAndABC));
            sortThread.Start();

            Console.ReadKey();
        }

        static public void SortFinish(object obj, EventArgs e)
        {
            Console.WriteLine("Конец сортировки.");
        }
    }
}
