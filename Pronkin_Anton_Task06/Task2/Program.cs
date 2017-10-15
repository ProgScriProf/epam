using System;
using BasicLib;

namespace Task2
{
    class Program
    {
        static void PrintInfo(Ring ring)
        {
            Console.WriteLine($"При радиусах r1 = {ring.Radius} и r2 = {ring.Radius2}:\n" +
                $"l = {ring.Length}, S = {ring.Square}");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.Write("Введите радиус 1: ");
            float r = ConvertFloat.GetFloatValue();

            Console.Write("Введите радиус 2: ");
            float r2 = ConvertFloat.GetFloatValue();

            Ring ring;
            try
            {
                ring = new Ring(r, r2);
            }
            catch (RingException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
                Console.ReadKey();
                return;
            }

            PrintInfo(ring);
        }
    }
}
