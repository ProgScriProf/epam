
using Task4.interfaces;

namespace Task4.GameFiles
{
    public class MobileObject : GameObject
    {

        public void MoveTo(TypeObject[,] map, int newX, int newY)
        {
            TypeObject old = map[_y, _x];
            map[_y, _x] = TypeObject.NONE;
            //_canvas.DrawItem(_x, _y, map);

            _x = newX;
            _y = newY;

            map[_y, _x] = old;
          //  _canvas.DrawItem(_x, _y, map);
        }

        public bool IsNULL(TypeObject[,] map, int x, int y)
        {
            return map[y, x] == TypeObject.NONE;
        }
    }
}
