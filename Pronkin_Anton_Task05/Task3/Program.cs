using System;
using BasicLib;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] a = new float[3]; // Длины сторон
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Введите длину {i+1} стороны:");
                a[i] = ConvertFloat.GetFloatValue();
            }

            try
            {
                Triangle tr = new Triangle(a[0], a[1], a[2]);
                Console.WriteLine($"Периметр = {tr.Perimeter()}");
                Console.WriteLine($"Площадь = {tr.Square()}");
            }
            catch(TriangleException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
