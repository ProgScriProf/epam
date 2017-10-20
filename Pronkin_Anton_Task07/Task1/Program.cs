using ConsoleUI;
using Figures;
using Figures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task1
{
    class Program
    {
        public static Point RandomPoint()
        {
            Point res = new Point();
            res.X = randomGenerator.Next(-10, 10);
            res.Y = randomGenerator.Next(-10, 10);
            return res;
        }

        public static double RandomRadius()
        {
            return randomGenerator.Next(-10, 10);
        }

        static Random randomGenerator = new Random();

        static void Main(string[] args)
        {
            Figure[] fig = new Figure[10];
            

            for (int i = 0; i < fig.Length; i++)
            {
                switch (randomGenerator.Next(4))
                {
                    case 0:
                        fig[i] = new Line(RandomPoint(), RandomPoint());
                        break;
                    case 1:
                        fig[i] = new Round(RandomPoint(), RandomRadius());
                        break;
                    case 2:
                        fig[i] = new Ring(RandomPoint(), RandomRadius(), RandomRadius());
                        break;
                    case 3:
                        fig[i] = new Figures.Rect(RandomPoint(), RandomPoint());
                        break;
                }
            }

            Canvas console = new Canvas();

            for (int i = 0; i < fig.Length; i++)
            {
                fig[i].Draw(console);
            }
            Console.ReadKey();

        }
    }
}
