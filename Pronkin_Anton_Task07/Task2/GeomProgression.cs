using DemoApplication;
using System;

namespace Task2
{
    public class GeomProgression : ISeries
    {
        private float _start;
        private float _znam;
        private float _current;

        public GeomProgression(float start, float znam)
        {
            if (start == 0 || znam == 0)
            {
                throw new Exception("Первый член прогрессии и знаменатель должны быть не нулевыми!");
            }
            else
            {
                _start = start;
                _znam = znam;
            }
        }

        public double GetCurrent()
        {
            return _current;
        }
        public bool MoveNext()
        {
            _current *= _znam;
            return true;
        }
        public void Reset()
        {
            _current = _start;
        }
    }
}
