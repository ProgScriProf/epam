using DemoApplication;
using System;

namespace Task3
{
    class Program
    {
        static public void PrintFirstOddIndex(IIndexable arr, int count)
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine(arr[i * 2 + 1]);
        }

        static void Main(string[] args)
        {
            double[] arr = new double[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List list = new List(arr);
            PrintFirstOddIndex(list, 4);
            Console.ReadKey();
        }
    }
}
