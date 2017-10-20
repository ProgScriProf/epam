using Figures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figures
{
    public class Round : Figure
    {
        protected Point _point;
        protected double _radius;

        public Round(Point point, double radius)
        {
            _point = point;
            _radius = radius;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawRound(_point, _radius);
        }
    }
}
