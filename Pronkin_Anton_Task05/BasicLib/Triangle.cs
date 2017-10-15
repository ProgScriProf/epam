using System;

namespace BasicLib
{
    public class TriangleException : Exception
    {
        public TriangleException(string message) : base(message)
        {

        }
    }
    public class Triangle
    {
        private float _a;
        private float _b;
        private float _c;

        public Triangle(float a, float b, float c)
        {
            SetLength(a, b, c);
        }
        public void SetLength(float a, float b, float c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))
                {
                    _a = a;
                    _b = b;
                    _c = c;
                }
                else
                {
                    throw new TriangleException("Треугольника с данными сторонами не существует!");
                }
            }
            else
            {
                throw new TriangleException("Длина стороны должна быть положительным числом!");
            }
        }
        public float Square()
        {
            float p = (_a + _b + _c) / 2; // Полупериметр
            return (float)(Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c))); // Формула Герона (вроде)
        }
        public float Perimeter()
        {
            return _a + _b + _c;
        }
    }
}
