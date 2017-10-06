using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
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

        static void PrintArray(int[,,] arr)
        {
            StringBuilder str = new StringBuilder("", arr.Length * 3);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                        str.Append(arr[i, j, k].ToString() + "\t");
                    str.Append("\n");
                }
                str.Append("\n");
            }

            Console.WriteLine(str);
        }

        static void ChangeArray(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    for (int k = 0; k < arr.GetLength(2); k++)
                        if (arr[i, j, k] > 0)
                            arr[i, j, k] = 0;
        }
        static void Main(string[] args)
        {
            int sizeX, sizeY, sizeZ;
            sizeX = EnterSizeArray(1);
            sizeY = EnterSizeArray(2);
            sizeZ = EnterSizeArray(3);

            var arr = new int[sizeX, sizeY, sizeZ];

            Random rnd = new Random();
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    for (int k = 0; k < sizeZ; k++)
                        arr[i, j, k] = rnd.Next(-99, 99);


            Console.WriteLine("Сгенерированый массив:");
            PrintArray(arr);

            ChangeArray(arr);

            Console.WriteLine("После замены всех положительнх элементов на нули:");
            PrintArray(arr);

            Console.ReadKey();
        }
    }
}
