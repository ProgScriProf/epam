using System;
using System.Windows;
using Figures.Interfaces;

namespace ConsoleUI
{
    public class Canvas : ICanvas
    {
        public void DrawLine(Point point1, Point point2)
        {
            Console.WriteLine($"Рисуем линию ({point1.X}, {point1.Y}) ({point2.X}, {point2.Y})");
        }

        public void DrawRect(Point point1, Point point2)
        {
            Console.WriteLine($"Рисуем прямоугольник ({point1.X}, {point1.Y}), ({point2.X}, {point2.Y})");
        }

        public void DrawRound(Point point1, double radius)
        {
            Console.WriteLine($"Рисуем круг в ({point1.X}, {point1.Y}) с радиусом {radius}");
        }
    }
}
