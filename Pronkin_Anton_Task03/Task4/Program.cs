using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
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
        static int EnterSizeArray(int num)
        {
            Console.Write("Введите размер (" + num.ToString() +
                ") массива (не менее 1 и не более 50): ");

            int arraySize;
            while (true)
            {
                arraySize = EnterInt();
                if (arraySize <= 0 || arraySize > 50)
                    Console.Write("Ошибка ввода. Неверный диапазон. Повторите ввод: ");
                else
                    break; // Ну, можно и без него обойтись, используя цикл с постусловием
            }
            return arraySize;
        }

        static void PrintArray(int[,] arr)
        {
            StringBuilder str = new StringBuilder("", arr.Length * 4);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    str.Append(arr[i, j].ToString() + "\t");
                str.Append("\n");
            }

            Console.WriteLine(str);
        }

        static int SumEven(int[,] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = i & 1; j < arr.GetLength(1); j += 2)
                    result += arr[i, j];
            return result;
        }
        static void Main(string[] args)
        {
            var arr = new int[EnterSizeArray(1), EnterSizeArray(2)];

            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = rnd.Next(-99, 99);

            Console.WriteLine("Сгенерированый массив:");
            PrintArray(arr);

            Console.WriteLine("Сумма элементов, стоящих на четных позициях = " + SumEven(arr));

            Console.ReadKey();
        }
    }
}
