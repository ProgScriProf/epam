using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.GameFiles;
using Task4.interfaces;
using Task4.UI;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            ICanvas UI = new ConsoleUI();

            Game game = new Game(UI, 25);
            game.Start();

            Console.ReadKey();
        }
    }
}
