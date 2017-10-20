using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.interfaces;

namespace Task4.GameFiles
{
    public class Player : MobileObject
    {
        static bool _isAlive;
        private int _score;

        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
        }
        public Player(int x, int y)
        {
            _x = x;
            _y = y;
            _isAlive = true;
            _score = 0;
        }
        public void AddScore(int value = 10)
        {
            _score += value;
        }

        public static void Kill()
        {
            _isAlive = false;
        }
    }
}
