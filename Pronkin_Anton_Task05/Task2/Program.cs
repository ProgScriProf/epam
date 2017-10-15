using System;
using BasicLib;

namespace Task2
{
    class Program
    {
        static void PrintInfo(Round round)
        {
            Console.WriteLine($"При радиусе r = {round.Radius}: l = {round.Length}, S = {round.Square}");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.Write("Введите радиус: ");
            float r = ConvertFloat.GetFloatValue();

            Round round;
            try
            {
                round = new Round(r);
            }
            catch (RoundException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
                Console.ReadKey();
                return;
            }

            PrintInfo(round);
        }
    }
}
