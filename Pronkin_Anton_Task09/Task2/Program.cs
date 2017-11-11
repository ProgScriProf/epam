using System;

namespace Task2
{
    class Program
    {
        static void Print<T>(DynamicArray<T> arr) where T : new()
        {
            Console.WriteLine($"Capacity = {arr.Capacity}, Length = {arr.Length}:");
            foreach(var item in arr)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Создаем пустую коллекцию:");
            var arr = new DynamicArray<int>();
            Print(arr);


            Console.WriteLine("Добавляем 12 чисел:");
            for(int i = 0; i < 12; i++)
            {
                arr.Add(i);
            }
            Print(arr);

            Console.WriteLine("Добавляем массив чисел:");
            arr.AddRange(new int[] { 9, 8, 7, 6, 5, 4, 3 });
            Print(arr);

            Console.WriteLine("Удаляем элемент со значением 2:");
            arr.Remove(2);
            Print(arr);

            Console.WriteLine("Удаляем элемент со значением 5:");
            arr.Remove(5);
            Print(arr);

            Console.WriteLine("Удаляем элемент со значением 9:");
            arr.Remove(9);
            Print(arr);


            Console.WriteLine("Добавляем элемент -1 на 2 позицию:");
            arr.Insert(-1, 2);
            Print(arr);

            Console.WriteLine("Добавляем элемент -1 на 10 позицию:");
            arr.Insert(-1, 10);
            Print(arr);

            Console.WriteLine("Добавляем элемент -1 на 10 позицию:");
            arr.Insert(-1, 10);
            Print(arr);

            Console.WriteLine("Добавляем элемент -1 на 10 позицию:");
            arr.Insert(-1, 10);
            Print(arr);

            Console.WriteLine("Добавляем элемент в начало:");
            arr.Insert(-100, 0);
            Print(arr);


            Console.ReadKey();

        }
    }
}
