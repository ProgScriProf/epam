using Task4.GameFiles;
using Task4.interfaces;

namespace Task4.GameFiles
{
    public enum TypeObject { NONE, WALL, PLAYER, ENEMY_VERT, FOOD_APPLE};

    public abstract class GameObject
    {
        protected ICanvas _canvas;
        protected int _x;
        protected int _y;
        private bool _isExist;

        public GameObject()
        {
            _isExist = true;
        }

        public bool IsExist
        {
            get
            {
                return _isExist;
            }
        }

        public int X
        {
            get
            {
                return _x;
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }
        }

        public void Destroy()
        {
            _isExist = false;
        }
    }
}
