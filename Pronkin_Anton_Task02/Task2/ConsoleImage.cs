using System;

namespace Task2
{
    class ConsoleImage
    {
        protected int _countString;
        public ConsoleImage(int countString)
        {
            _countString = countString;
        }
        public ConsoleImage() : this(0) 
        { }
        public void EnterCount()
        {
            Console.Write("Введите количество строк: ");
            int count = int.Parse(Console.ReadLine());
            while (count <= 0)
            {
                Console.Write("Ошибка! Повторите ввод: ");
                count = int.Parse(Console.ReadLine());
            }
            _countString = count;
        }
        virtual public void PrintImage() // Вывод изображения
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < _countString; i++)
            {
                for (int j = 0; j < i + 1; j++)
                    Console.Write('*');
                Console.WriteLine();
            }

            Console.ForegroundColor = oldColor;
        }
    }
}
