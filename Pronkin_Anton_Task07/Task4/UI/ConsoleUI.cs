using System;
using Task4.GameFiles;
using Task4.interfaces;

namespace Task4.UI
{
    public class ConsoleUI : ICanvas
    {
      //  public static object locker;

        public void Init(int Height, int Width)
        {
            Console.CursorVisible = false;
            Console.Title = "My first game";
            Console.WindowHeight = Height + 1;
            Console.WindowWidth = Width * 2;
            Console.BufferHeight = Console.WindowHeight +1;
            Console.BufferWidth = Console.WindowWidth + 1;
        }

        private string GetChar(TypeObject item)
        {
            switch (item)
            {
                case TypeObject.NONE:
                    return "  ";
                case TypeObject.WALL:
                    return "░░";
                case TypeObject.PLAYER:
                    return "><";
                case TypeObject.ENEMY_VERT:
                    return "↑↓";
                case TypeObject.FOOD_APPLE:
                    return "**";
            }
            return "  ";
        }

        public void DrawMap(TypeObject[,] map)
        {
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(GetChar(map[i, j]));
                }

                if (i < map.GetLength(0))
                {
                    Console.WriteLine();
                }
            }
        }
        /*
        public void DrawItem(int x, int y, TypeObject[,] map)
        {     
            /*
            lock (locker)
            {
                Console.set
                Console.SetCursorPosition(x * 2, y);
                Console.Write(GetChar(map[y, x]));
                Console.SetCursorPosition(map.GetLength(1) + 1, map.GetLength(0));
            }
           
        }
    */
    }
}
