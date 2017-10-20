using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.interfaces;

namespace Task4.GameFiles
{
    public class EnemyVert : Enemy
    {
        private sbyte dy;
        public EnemyVert(int x, int y)
        {
            dy = 1;
            _x = x;
            _y = y;
        }

        public override void MoveNext(TypeObject[,] map)
        {
            if (Game.IsCorrect(map, _x, _y + dy) && !Game.IsWall(map[_y + dy, _x]) && !Game.IsFood(map[_y + dy, _x]))
            {
                MoveTo(map, _x, _y + dy);
            }
            else if (Game.IsCorrect(map, _x, _y - dy) && !Game.IsWall(map[_y - dy, _x]) && !Game.IsFood(map[_y - dy, _x]))
            {
                this.MoveTo(map, _x, _y - dy);
                dy = (sbyte)-dy;
            }

            if (map[_y, _x] == TypeObject.PLAYER)
            {
                Player.Kill();
            }
        }
    }
}
