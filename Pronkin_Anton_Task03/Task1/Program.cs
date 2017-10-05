using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static int EnterInt() // Ввод числа
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

        static int EnterSizeArray() // Ввод размера массива
        {
            Console.Write("Введите размер массива (не менее 1 и не более 50): ");
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
        

        static void PrintArray(int[] arr) // Вывод элементов массива
        {          
            StringBuilder str = new StringBuilder("", arr.Length * 3);

            for (int i = 0; i < arr.Length; i++)
                str.Append(arr[i].ToString() + " ");

            Console.WriteLine(str);
        }

        static int MinElement(int[] arr) // Поиск минимального элемента
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] < min)
                    min = arr[i];
            return min;
        }

        static int MaxElement(int[] arr) // Поиск максимального элемента
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max)
                    max = arr[i];
            return max;
        }

        static void FastSort(ref int[] arr, int left, int right) // Быстрая сортировка
        {
            int oldLeft = left;
            int oldRight = right;
            int op = arr[(left + right) / 2]; // Значение опорного элемента (из середины)
            while (left <= right)
            {
                while (arr[left] < op) // Ищем крайний слева, больший опорного
                    left++;

                while (arr[right] > op) // Крайний справа, меньший опорного
                    right--;

                if (left <= right) // Если не перешли границы
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }      
            }

            if (oldLeft < right)
                FastSort(ref arr, oldLeft, right);

            if (oldRight > left)
                FastSort(ref arr, left, oldRight);
        }
        static void Main(string[] args)
        {
            int[] arr = new int[EnterSizeArray()];

            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(0, 50);

            Console.WriteLine("Сгенерированый массив:");
            PrintArray(arr);

            Console.WriteLine("Минимальное  значение = " + MinElement(arr).ToString());
            Console.WriteLine("Максимальное значение = " + MaxElement(arr).ToString());

            FastSort(ref arr, 0, arr.Length - 1);

            Console.WriteLine("\nСортированный массив:");
            PrintArray(arr);

            Console.ReadKey();
        }
    }
}
