using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewLib
{
    public static class MyMath
    {
        public static int Fact(this int a)
        {
            return (a > 1) ? a * (Fact(a - 1)) : 1;
        }

        public static int Pow(this int a, int s)
        {
            int res = 1;
            for(int i = 0; i < s; i++)
            {
                res *= a;
            }
            return res;
        }
    }
}
