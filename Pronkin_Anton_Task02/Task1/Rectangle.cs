using System;

namespace Task1
{
    class Rectangle
    {
        int _width; // Ширина прмоугольника
        int _height; // Высота прямоугольника

        public Rectangle()
        {
            _width = 0;
            _height = 0;
        }
        int EnterSize(string nameOfSize) // Считывание размеров прямоугольника
        {
            Console.WriteLine("Введите " + nameOfSize + " прямоугольника: ");
            int size = int.Parse(Console.ReadLine());
            while (size <= 0)
            {
                Console.WriteLine("Ошибка! Повторите ввод: ");
                size = int.Parse(Console.ReadLine());
            }
            return size;
        }
        public void EnterWidth()
        {
            _width = EnterSize("ширину"); // Ввод ширины прямоугольника
        }
        public void EnterHeight()
        {
            _height = EnterSize("высоту"); // Ввод высоты прямоугольника
        }
        public void CalculateArea()
        {
            int area = _width * _height;
            if (area > 0)
                Console.WriteLine("Площадь прямоугольника со сторонами " +
                    _width + " и " + _height + " равна " + area);
            else
                Console.WriteLine("Недостаточно данных для вычисления площади");
        }
    }
}
