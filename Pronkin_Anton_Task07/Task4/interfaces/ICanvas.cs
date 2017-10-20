
namespace Task4.interfaces
{
    public interface ICanvas
    {
        void Init(int Height, int Width);
        void DrawMap(GameFiles.TypeObject[,] map);
        //void DrawItem(int x, int y, GameFiles.TypeObject[,] map);
    }
}
