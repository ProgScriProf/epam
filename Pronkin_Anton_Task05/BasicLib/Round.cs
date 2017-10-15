using System;
using System.Windows;

namespace BasicLib
{
    public class RoundException : Exception
    {
        public RoundException(string message) : base(message)
        {

        }
    }

    public class Round
    {
        private Point _point;
        private float _r;
        public Round(float radius)
        {
            Radius = radius;
            _point.X = 0;
            _point.Y = 0;
        }
        public Round(float radius, Point point) : this(radius)
        {
            _point = point;
        }
        public Round(float radius, float x, float y) : this(radius)
        {
            _point.X = x;
            _point.Y = y;
        }

        public float Radius
        {
            get
            {
                return _r;
            }
            set
            {
                if (value > 0)
                {
                    _r = value;
                }
                else
                {
                    throw new RoundException("Радиус должен являться положительным числом!");
                }
            }
        }
        public float Length
        {
            get
            {
                return (float)(2 * Math.PI * _r);
            }
        }
        public float Square
        {
            get
            {
                return (float)(Math.PI * _r * _r);
            }
        }
    }
}
