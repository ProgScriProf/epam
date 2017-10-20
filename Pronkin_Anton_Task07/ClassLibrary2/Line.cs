using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Figures.Interfaces;

namespace Figures
{
    public class Line : Figure
    {
        private Point _point1;
        private Point _point2;

        public Line(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawLine(_point1, _point2);
        }
    }
}
