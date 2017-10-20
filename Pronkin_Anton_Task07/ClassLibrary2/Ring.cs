using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Figures.Interfaces;

namespace Figures
{
    public class Ring : Round
    {
        protected double _radius2;

        public Ring(Point point, double radius1, double radius2) : base(point, radius1)
        {
            _radius2 = radius2;
            if (_radius == _radius2)
            {
                throw new Exception("Радиусы должны быть разные!");
            }
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.DrawRound(_point, _radius2);
            canvas.DrawRound(_point, _radius);
        }
    }
}
