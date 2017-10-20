using System;
using System.Windows;

namespace BasicLib
{
    public class RingException : RoundException
    {
        public RingException(string message) : base(message)
        {

        }
    }

    public class Ring : Round
    {
        private float _r2; // Второй радиус

        public override float Radius
        {
            get
            {
                return _r;
            }
            set
            {
                if (value != Radius2)
                {
                    Radius = value;
                }
                else
                {
                    throw new RingException("Радиус не дожен равняться другому радиусу!");
                }
            }
        }
        public float Radius2
        {
            get
            {
                return _r2;
            }
            set
            {
                if (value > 0 && value != Radius)
                {
                    _r2 = value;
                }
                else
                {
                    throw new RingException("Радиус должен являться положительным числом и не дожен равняться другому радиусу!");
                }
            }
        }

        public Ring(float radius1, float radius2) : base(radius1)
        {
            Radius2 = radius2;
        }
        public Ring(float radius1, float radius2, Point point) : this(radius1, radius2)
        {
            _point = point;
        }
        public Ring(Round round1, Round round2) : this(round1.Radius, round2.Radius, round1.Centre)
        {

        }
        public Ring(Round round, float radius2) : this(round.Radius, radius2)
        {

        }

        public float MinRadius
        {
            get
            {
                return (Radius < Radius2) ? Radius : Radius2;
            }
        }
        public float MaxRadius
        {
            get
            {
                return (Radius > Radius2) ? Radius : Radius2;
            }
        }

        public override float Length
        {
            get
            {
                return (float)(2 * Math.PI * (Radius + Radius2));
            }
        }
        public override float Square
        {
            get
            {
                return (float)(Math.PI * Math.Abs(Radius * Radius - Radius2 * Radius2));
            }
        }
    }

    /*
class Ring : Round
{
    //private float _radius2; // Меньший радиус
    private Round _round;

    public Ring(float radius1, float radius2) : base(radius1)
    {
        _round = new Round(radius2);
        _round.Centre = new Point(0, 0);
    }
    public Ring(float radius1, float radius2, Point point) : this(radius1, radius2)
    {
        _round.Centre = point;
    }
    public Ring(Round round1, Round round2) : this(round1.Radius, round2.Radius, round1.Centre)
    {

    }

    public override float Length
    {
        get
        {
            return (float)(2 * Math.PI * (Radius + _round.Radius));
        }
    }
    public override float Square
    {
        get
        {
            return (float)(Math.PI * (Radius * Radius + _round.Radius * _round.Radius));
        }
    }
}
*/

}
