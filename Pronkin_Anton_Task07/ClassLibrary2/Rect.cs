using Figures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figures
{
    public class Rect : Figure
    {
        private Point _point1;
        private Point _point2;

        public Rect(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
            if (_point1.X == _point2.X || _point1.Y == _point2.Y)
            {
                throw new Exception("Это не прямоугольник!");
            }
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawRect(_point1, _point2);
        }
    }
}
