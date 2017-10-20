using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figures.Interfaces
{
    public interface ICanvas
    {
        void DrawLine(Point point1, Point point2);
        void DrawRound(Point point1, double radius);
        void DrawRect(Point point1, Point point2);
    }
}
