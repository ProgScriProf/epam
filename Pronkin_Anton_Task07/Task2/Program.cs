using DemoApplication;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var gp = new GeomProgression(2, 2);
            InterfacesDemo.PrintSeries(gp);
            System.Console.ReadKey();
        }
    }
}
