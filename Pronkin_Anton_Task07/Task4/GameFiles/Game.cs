using System;
using System.IO;
using System.Threading;
using Task4.interfaces;
using Task4.UI;

namespace Task4.GameFiles
{
    // Элементы карты
    public class Game
    {
        private TypeObject[,] _map;
        private ICanvas _canvas; // UI отрисовки

        private Player _player;
        private Enemy[] _enemies;
        private Food[] _food;

        private bool _change;

        public Game(ICanvas UI, int Size = 20)
        {
            _map = new TypeObject[Size, Size];
            _canvas = UI;
            _change = true;
        }

        public void Change()
        {
            _change = true;
        }
        public void Loop()
        {

            while (true)
            {
                if (_change)
                {
                    _canvas.DrawMap(_map);
                    _change = false;
                }
      
            }

        }
        public void Start()
        {
            GenerateMap();
            GeneratePlayer();
            GenerateEnemies();
            GenerateFood();

            // Создаем поток для ходьбы монстров
            Thread moveEnemy = new Thread(MoveEnemy);
            moveEnemy.Start();

            // Создаем поток для ходьбы игроком
            Thread movePlayer = new Thread(MovePlayer);
            movePlayer.Start();

            _canvas.Init(_map.GetLength(0), _map.GetLength(1));
           // _canvas.DrawMap(_map);

            Loop();
        }

        private void MoveEnemy()
        {
            while (_player.IsAlive)
            {
                Thread.Sleep(200);
                
                foreach(var enemy in _enemies)
                {
                    enemy.MoveNext(_map);
                }
                Change();
            }
        }

        private void MovePlayer()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Actions(key);
                Change();
            }
        }

        private void Actions(ConsoleKey key)
        {
            int newX = _player.X;
            int newY = _player.Y;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    newX++;
                    break;
                case ConsoleKey.UpArrow:
                    newY--;
                    break;
                case ConsoleKey.DownArrow:
                    newY++;
                    break;
            }

            if (IsCorrect(_map, newX, newY))
            {
                if (_map[newY, newX] == TypeObject.NONE)
                {
                    _player.MoveTo(_map, newX, newY);
                }
                else if (IsEnemy(_map[newY, newX]))
                {
                    Player.Kill();
                }
                else if (IsFood(_map[newY, newX]))
                {
                    _player.AddScore();

                    foreach (var food in _food)
                    {
                        if (food.IsExist && food.X == newX && food.Y == newY)
                        {
                            food.Destroy();
                        }
                    }
                    _player.MoveTo(_map, newX, newY);
                }
            }
        }
        static Random rnd = new Random();
        public static bool GetRandomNullItem(TypeObject[,] map, out int X, out int Y)
        {          
            do
            {
                X = rnd.Next(map.GetLength(1));
                Y = rnd.Next(map.GetLength(0));
                if (!IsWall(map[Y, X]))
                {
                    return true;
                }
            } while (true);
        }
        public static bool IsCorrect(TypeObject[,] map, int X, int Y)
        {
            return (X >= 0 && X < map.GetLength(1) &&
                Y >= 0 && Y < map.GetLength(0));
        }
        public static bool IsWall(TypeObject item)
        {
            if (item == TypeObject.WALL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsEnemy(TypeObject item)
        {
            if (item == TypeObject.ENEMY_VERT)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsFood(TypeObject item)
        {
            if (item == TypeObject.FOOD_APPLE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GenerateMap()
        {
            Random rnd = new Random();
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for(int j = 0; j < _map.GetLength(1); j++)
                {
                    if ((i == 0) || (i == _map.GetLength(0) - 1) ||
                        (j == 0) || (j == _map.GetLength(1) - 1))
                    {
                        // Добавляем стены вокруг карты
                        _map[i, j] = TypeObject.WALL;
                    }
                    else
                    {
                        // С вероятностью 0.1 создаем стену посредине
                        if ((int)rnd.Next(0, 10) == 0)
                        {
                            _map[i, j] = TypeObject.WALL;
                        }
                        else
                        {
                            _map[i, j] = TypeObject.NONE;
                        }
                    }
                }
            }
        }
        private void GeneratePlayer()
        {
            GetRandomNullItem(_map, out int X, out int Y);
            _player = new Player(X, Y);
            _map[Y, X] = TypeObject.PLAYER;
        }
        private void GenerateEnemies()
        {
            //_enemies = new Enemy[_map.GetLength(0) / 8];
            
            _enemies = new Enemy[3];
            for (int i = 0; i < _enemies.Length; i++)
            {
                GetRandomNullItem(_map, out int X, out int Y);
                _enemies[i] = new EnemyVert(X, Y);
                _map[Y, X] = TypeObject.ENEMY_VERT;
            }
            
        }
        private void GenerateFood()
        {
            _food = new Food[3];
            for (int i = 0; i < _food.Length; i++)
            {
                GetRandomNullItem(_map, out int X, out int Y);
                _food[i] = new FoodApple(X, Y);
                _map[Y, X] = TypeObject.FOOD_APPLE;
            }

        }
    }
}
