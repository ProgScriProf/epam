using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static int EnterInt()
        {
            string str = Console.ReadLine();
            int result;
            while (!int.TryParse(str, out result))
            {
                Console.Write("Ошибка ввода. Повторите ввод: ");
                str = Console.ReadLine();
            }
            return result;
        }

        static int EnterSizeArray()
        {
            Console.Write("Введите размер массива (не менее 1 и не более 50): ");
            int arraySize;
            while (true)
            {
                arraySize = EnterInt();
                if (arraySize <= 0 || arraySize > 50)
                    Console.Write("Ошибка ввода. Неверный диапазон. Повторите ввод: ");
                else
                    return arraySize;
            }      
        }

        static void PrintArray(int[] arr)
        {
            StringBuilder str = new StringBuilder("", arr.Length * 4);

            for (int i = 0; i < arr.Length; i++)
                str.Append(arr[i].ToString() + "\t");

            Console.WriteLine(str);
        }

        static int SumPositive(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > 0)
                    sum += arr[i];
            return sum;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[EnterSizeArray()];

            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(-99, 99);

            Console.WriteLine("Сгенерированый массив:");
            PrintArray(arr);

            Console.WriteLine("Сумма неотрицательных элементов = " + SumPositive(arr));
            Console.ReadKey();
        }
    }
}
