using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static void PrintItemsMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Режим наблюдения");
            Console.WriteLine("2. Режим отката");
            Console.Write("Введите номер дейтвия: ");
        }

        public static void ShowMenu()
        {
            PrintItemsMenu();
            try
            {
                // Да да, плохо, но это просто для демонстрации..
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        new WatchFiles(Environment.CurrentDirectory);
                        Console.WriteLine("Аналз запущен");
                        break;
                    case 2:
                        RestoreFile r = new RestoreFile(Environment.CurrentDirectory);
                        Console.WriteLine("Выберите точку восстановления: ");
                        Console.WriteLine(r.GetBackup());
                        Console.WriteLine("Введите номер: ");
                        if (int.TryParse(Console.ReadLine(), out int n))
                        {
                            r.Restore(n);
                        }
                        Console.WriteLine("Файлы восстановлены");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Неверный номер команды. {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            ShowMenu();

            Console.ReadKey();
        }
    }
}
